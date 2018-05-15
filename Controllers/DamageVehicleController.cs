using AuctionInventory.Models;
using AuctionInventory.MyRoleProvider;
using AuctionInventory.Services;
using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionInventory.Controllers
{
      [Permissions(Permissions.View)]
    public class DamageVehicleController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        //
        // GET: /DamageVehicle/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DamageVehicleSave()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllDamageVehicles()
        {
            dynamic vehicles = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    DamageVehiclesServiceClient service = new DamageVehiclesServiceClient();
                    vehicles = service.GetAllDamageVehicles();
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
        [HttpPost]
        public JsonResult GetVehicles(string prefix)
        {
            dynamic vehicles = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    DamageVehiclesServiceClient service = new DamageVehiclesServiceClient();
                    vehicles = service.GetVehicles(prefix);
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

        [HttpPost]
        public JsonResult GetDamageVehicles(int vehicleID)
        {
            dynamic vehicles = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    DamageVehiclesServiceClient service = new DamageVehiclesServiceClient();
                    vehicles = service.GetDamageVehicles(vehicleID);
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

        [HttpGet]
        public ActionResult ShowYardName()
        {
            var yardList = auctionContext.MYards.ToList();
            //var partyName = partyList.Select(a => a.strFirstName).ToList();
            return Json(yardList, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Save(DamageVehicleModel damageVehicle)
        {
            
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    DamageVehiclesServiceClient damageVehicleServiceClient = new DamageVehiclesServiceClient();

                    status = damageVehicleServiceClient.SaveDamageVehicles(damageVehicle);
                    
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
                status = false;
                throw e;

            }
          
             return new JsonResult { Data = new { status = status } };
        }
	}
}