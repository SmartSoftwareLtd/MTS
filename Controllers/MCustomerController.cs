using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.Repositories;
using AuctionInventory.Services;
using AuctionInventory.Models;
using AuctionInventory.Helpers;
using AuctionInventory.MyRoleProvider;
namespace AuctionInventory.Controllers
{
    [Permissions(Permissions.View)]
    public class MCustomerController : Controller
    {
        AuctionInventoryEntities db = new AuctionInventoryEntities();
        // GET: MCustomer
        public ActionResult Index()
        {
            ViewBag.PageName = "Customer List";
            return View();
        }

        #region CRUD
        
        public ActionResult GetAllCustomers()
        {
            dynamic customer = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetAllCustomers();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                customer = null;
                throw e;

            }
            return Json(customer, JsonRequestBehavior.AllowGet);

        }


        public ActionResult GetAllShowRoomCustomers()
        {
            dynamic customer = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetAllShowRoomCustomers();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                customer = null;
                throw e;

            }
            return Json(customer, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(String ID)
        {
            int id = 0;
            if (ID != "0")
            {
                id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            }
            Customer customer = new Customer();

            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();
                    customer = customerServiceClient.GetCustomer(id);
                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customer.iCountry);
                    var countryList = db.MCities.Where(x => x.iCountry == customer.iCountry).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", customer.iCity);

                    ViewBag.CutomerType = new SelectList(db.MCutomerTypes, "iCutomerTypeID", "strCutomerTypeName", customer.iCutomerTypeID);

                    ViewBag.CreditCategory = new SelectList(db.CreditCategories, "iCreditCategoryID", "strCategory", customer.iCreditCategoryID);
                    
                    ViewBag.PageName = "Create Customer";
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                customer = null;
                throw e;
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customers)
        {
            bool status = false;
            ViewBag.CutomerType = new SelectList(db.MCutomerTypes, "iCutomerTypeID", "strCutomerTypeName", customers.iCutomerTypeID);

            ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customers.iCountry);
            ViewBag.City = new SelectList(db.MCities, "iCity", "strCityName", customers.iCity);
            ViewBag.CreditCategory = new SelectList(db.CreditCategories, "iCreditCategoryID", "strCategory", customers.iCreditCategoryID);
                   

            try
            {
                if (ModelState.IsValid)
                {
                    HttpPostedFileBase fileIDCopy = Request.Files["IDCopyImageData"];
                    HttpPostedFileBase fileVisaCopy = Request.Files["VisaCopyImageData"];
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();


                    status = customerServiceClient.SaveData(customers, fileIDCopy, fileVisaCopy);

                    ViewBag.CutomerType = new SelectList(db.MCutomerTypes, "iCutomerTypeID", "strCutomerTypeName", customers.iCutomerTypeID);

                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customers.iCountry);
                    ViewBag.City = new SelectList(db.MCities, "iCity", "strCityName", customers.iCity);


                    return RedirectToAction("Index","MCustomer");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            return View(customers);
            // return new JsonResult { Data = new { status = status } };
        }


        [HttpPost]
        public ActionResult GenerateIDProof(String ID)
        {
            int id = 0;
            if (ID != "0")
            {
                id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            }
            Customer customer = new Customer();

            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();
                    customer = customerServiceClient.GetCustomer(id);
             }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                customer = null;
                throw e;
            }
            //return View(customer);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCity(string countryID)
        {

            // ViewBag.City = new SelectList(db.MCities, "iCity", "strCityName", customers.iCity);


            int countryId;
            List<SelectListItem> cityNames = new List<SelectListItem>();

            //ViewBag.City = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(countryID))
            {
                countryId = Convert.ToInt32(countryID);
                List<MCity> cityLists = db.MCities.Where(x => x.iCountry == countryId).ToList();
                cityLists.ForEach(x =>
                {
                    cityNames.Add(new SelectListItem { Text = x.strCityName, Value = x.iCity.ToString() });
                });
            }
            ViewBag.City = cityNames;
            return Json(ViewBag.City, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Delete(String ID)
        {
            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            Customer customer = new Customer();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetCustomer(id);
                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customer.iCountry);
                    var countryList = db.MCities.Where(x => x.iCountry == customer.iCountry).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", customer.iCity);
                    ViewBag.CutomerType = new SelectList(db.MCutomerTypes, "iCutomerTypeID", "strCutomerTypeName", customer.iCutomerTypeID);

                    ViewBag.CreditCategory = new SelectList(db.CreditCategories, "iCreditCategoryID", "strCategory", customer.iCreditCategoryID);
               

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                customer = null;
                throw e;
            }
            //return View("Save", customer);
            return View(customer);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCustomers(String ID)
        {
            int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();
                    status = customerServiceClient.Delete(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            return View("Index");
            // return new JsonResult { Data = new { status = status } };

        }

        #endregion


        #region Customer Account

        public ActionResult CustomerAccount()
        {
            ViewBag.PageName = "Customer Account";
            return View();
        }


        [HttpPost]
        public JsonResult GetShowRoomCustomerAccount(string prefix)
        {
            dynamic customers = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerServiceClient service = new CustomerServiceClient();
                    customers = service.GetShowRoomCustomerAccount(prefix);
                    //return Json(customers, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                customers = null;
                throw ex;
            }
            return Json(customers, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GetDirectCustomerAccount(string prefix)
        {
            dynamic customers = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerServiceClient service = new CustomerServiceClient();
                    customers = service.GetDirectCustomerAccount(prefix);
                    //return Json(customers, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                customers = null;
                throw ex;
            }
            return Json(customers, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult GetCustomerVehicles(int  custid)
        {
            dynamic vehicles = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    CustomerServiceClient service = new CustomerServiceClient();
                    vehicles = service.GetCustomerVehicles(custid);
                    //return Json(customers, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                vehicles = null;
                throw ex;
            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);

        }

        #endregion
    }
}