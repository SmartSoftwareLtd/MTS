using AuctionInventory.MyRoleProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionInventory.Controllers
{
      [Permissions(Permissions.View)]
    public class VehicleStatusController : Controller
    {
        //
        // GET: /VehicleStatus/
        public ActionResult Index()
        {
            ViewBag.PageName = "Vehicles Status List";
            return View();
        }

        #region developer1
        //Get All Sold Vehicles Present in Yard
        public ActionResult GetSoldVehiclesInYard(DateTime fromDate, DateTime ToDate)
        {


            dynamic vehicles = 0;

            try
            {
                if (ModelState.IsValid)
                {

                    Services.VehicleStatusServiceClient VehicleStatusServiceClient = new Services.VehicleStatusServiceClient();
                    vehicles = VehicleStatusServiceClient.GetSoldVehiclesInYard(fromDate, ToDate);
                    //if (currency.Count == 0 || currency == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehicles = null;
                throw e;

            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);

        }

        //Get All Sold Vehicles
      [HttpPost]
        public ActionResult GetSoldVehicles(DateTime fromDate, DateTime ToDate)
        {


            dynamic vehicles = 0;

            try
            {
                if (ModelState.IsValid)
                {

                    Services.VehicleStatusServiceClient VehicleStatusServiceClient = new Services.VehicleStatusServiceClient();
                    vehicles = VehicleStatusServiceClient.GetSoldVehicles(fromDate, ToDate);
                    //if (currency.Count == 0 || currency == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehicles = null;
                throw e;

            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);

        }

        //Get All Remaining Vehicles Present in a list
           [HttpPost]
      public ActionResult GetRemainingVehicles(DateTime fromDate, DateTime ToDate)
        {


            dynamic vehicles = 0;

            try
            {
                if (ModelState.IsValid)
                {

                    Services.VehicleStatusServiceClient VehicleStatusServiceClient = new Services.VehicleStatusServiceClient();
                    vehicles = VehicleStatusServiceClient.GetRemainingVehicles(fromDate, ToDate);
                    //if (currency.Count == 0 || currency == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehicles = null;
                throw e;

            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);

        }

        
        //Get All Remaining Vehicles Present in a list
           public ActionResult GetPendingCars(DateTime fromDate, DateTime ToDate)
        {
            dynamic vehicles = 0;

            try
            {
                if (ModelState.IsValid)
                {

                    Services.VehicleStatusServiceClient VehicleStatusServiceClient = new Services.VehicleStatusServiceClient();
                    vehicles = VehicleStatusServiceClient.GetPendingCars(fromDate, ToDate);
                    //if (currency.Count == 0 || currency == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}

                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehicles = null;
                throw e;

            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}