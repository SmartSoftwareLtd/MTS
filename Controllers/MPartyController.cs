using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AuctionInventoryDAL.Entity;
using AuctionInventory.Models;
using AuctionInventory.MyRoleProvider;

namespace AuctionInventory.Controllers
{
    [Permissions(Permissions.View)]
    public class MPartyController : Controller
    {
        AuctionInventoryEntities db = new AuctionInventoryEntities();
        // GET: MParty
        public ActionResult Index()
        {
            ViewBag.PageName = "Party List";
            return View();
        }

        #region CRUD

        public ActionResult GetAllParties()
        {
            dynamic party = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.PartyServiceClient service = new Services.PartyServiceClient();

                    party = service.GetAllParties();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                party = null;
                throw e;

            }
            return Json(party, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            PartyModel party = new PartyModel();

            try
            {
                if (ModelState.IsValid)
                {
                    Services.PartyServiceClient service = new Services.PartyServiceClient();
                    party = service.GetParty(id);
                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", party.iCountry);
                    var countryList = db.MCities.Where(x => x.iCountry == party.iCountry).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", party.iCity);
                    ViewBag.PageName = "Create Party";
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                party = null;
                throw e;
            }
            return View(party);
        }

        [HttpPost]
        public ActionResult Save(PartyModel partyModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.PartyServiceClient service = new Services.PartyServiceClient();
                    status = service.SaveData(partyModel);

                    //ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", customers.iCountry);
                    //ViewBag.City = new SelectList(db.MCities, "iCity", "strCityName", customers.iCity);


                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
            return View(partyModel);
            // return new JsonResult { Data = new { status = status } };
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
        public ActionResult Delete(int id)
        {
            PartyModel partyModel = new PartyModel();
            try
            {
                if (ModelState.IsValid)
                {

                    Services.PartyServiceClient service = new Services.PartyServiceClient();

                    partyModel = service.GetParty(id);
                    ViewBag.Country = new SelectList(db.MCountries, "iCountry", "strCountryName", partyModel.iCountry);
                    var countryList = db.MCities.Where(x => x.iCountry == partyModel.iCountry).ToList();

                    ViewBag.City = new SelectList(countryList, "iCity", "strCityName", partyModel.iCity);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                partyModel = null;
                throw e;
            }
            //return View("Save", customer);
            return View(partyModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCustomers(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.PartyServiceClient service = new Services.PartyServiceClient();
                    status = service.Delete(id);
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
    }
}