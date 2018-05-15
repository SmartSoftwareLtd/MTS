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
    public class DOController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        //
        // GET: /DO/
        public ActionResult Index()
        {
            ViewBag.PageName = "Create Delivery Order";
            return View();
        }

        public ActionResult DOList()
        {
            ViewBag.PageName = "Delivery Order List";
            return View();
        }


        public ActionResult GetAllDOrders()
        {
            dynamic AllDOrders = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    DOServiceClient service = new DOServiceClient();

                    AllDOrders = service.GetAllDOrders();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                AllDOrders = null;
                throw e;

            }
            return Json(AllDOrders, JsonRequestBehavior.AllowGet);

        }


        #region DO Customer Restriction To Print
        [HttpPost]
        public JsonResult CheckCustomerIsBlockOrNotForDO(string chassisNum)
        {
            bool status = false;

            try
            {
                if (ModelState.IsValid)
                {
                    DOServiceClient ServiceClient = new DOServiceClient();
                    status = ServiceClient.CheckCustomerIsBlockOrNotForDO(chassisNum);


                    //if (purchase.Count == 0 || purchase == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                status = false;
                throw e;
            }

            //return Json(purchaseReportByDate, JsonRequestBehavior.AllowGet);
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);

        }

        #endregion


        [HttpPost]
        public JsonResult GetCustomerDetails(string prefix)
        {
            dynamic customers = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    DOServiceClient service = new DOServiceClient();
                    customers = service.GetCustomerDetails(prefix);
                  
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
        public ActionResult SaveDeliveryOrder(DeliveryOrderModel doModel)
        {
            bool status = true;
            try
            {
                if (ModelState.IsValid)
                {
                    DOServiceClient service = new DOServiceClient();
                    status = service.SaveEdit(doModel);

                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            //return RedirectToAction("Index");
            //return View();
            return new JsonResult { Data = new { status = status } };
        }



        [HttpPost]
        public ActionResult DeleteDO(int ID)
        {
            bool status = true;
            try
            {
                if (ModelState.IsValid)
                {
                    DOServiceClient service = new DOServiceClient();
                    status = service.DeleteDO(ID);

                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            //return RedirectToAction("Index");
            //return View();
            return new JsonResult { Data = new { status = status } };
        }
    }
}