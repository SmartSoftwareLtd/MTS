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
    public class PapersController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
        //
        // GET: /Papers/

        public ActionResult Index()
        {
            ViewBag.PageName = "Create Deposit";
            return View();
        }

        public ActionResult DepositList()
        {
            ViewBag.PageName = "Deposit List";
            return View();
        }

        public ActionResult PartyAccountTransaction()
        {
            ViewBag.PageName = "Party Account Transaction";
            return View();
        }

        [HttpPost]
        public ActionResult GetPartyAccountTransaction(int partyID,DateTime fromDate, DateTime toDate)
        {
            dynamic PartyAccountList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient service = new PapersServiceClient();

                    PartyAccountList = service.GetPartyAccountTransaction(partyID,fromDate, toDate);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Wrong");
                PartyAccountList = null;
                throw ex;
            }
            return Json(PartyAccountList, JsonRequestBehavior.AllowGet);
            //return Json(null, JsonRequestBehavior.AllowGet);
            // return Json(listVehicles, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public ActionResult GetDepositListData(DateTime fromDate, DateTime toDate)
        {
            dynamic depositList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient service = new PapersServiceClient();

                    depositList = service.GetDepositListData(fromDate, toDate);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Wrong");
                depositList = null;
                throw ex;
            }
            return Json(depositList, JsonRequestBehavior.AllowGet);
            //return Json(null, JsonRequestBehavior.AllowGet);
            // return Json(listVehicles, JsonRequestBehavior.AllowGet);

        }
        public ActionResult PapersList()
        {
            ViewBag.PageName = "Documentation List";
            return View();
        }

        [HttpPost]
        public ActionResult UpdateImportIndex(PaperDetailsImportModel impUpdateModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.UpdateImportData(impUpdateModel);
                    //return RedirectToAction("Index");
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
        public ActionResult UpdateExportIndex(PaperDetailsExportModel expUpdateModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.UpdateExportData(expUpdateModel);
                    //return RedirectToAction("Index");
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


        [HttpGet]
        public ActionResult GetImportData()
        {
            dynamic importData = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient papersServiceClient = new PapersServiceClient();
                    importData = papersServiceClient.GetImportData();

                    //return Json(new { importData }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                importData = null;
                throw e;
            }
            return Json(importData, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public ActionResult SaveImport(List<PaperDetailsImportModel> importModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.SaveImportData(importModel);
                    //return RedirectToAction("Index");
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



        [HttpGet]
        public ActionResult GetExportData()
        {
            dynamic exportData = 0;

            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient papersServiceClient = new PapersServiceClient();
                    exportData = papersServiceClient.GetExportData();

                    //return Json(new { exportData }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                exportData = null;
                throw e;
            }
            return Json(exportData, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public ActionResult SaveExport(List<PaperDetailsExportModel> exportModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient services = new PapersServiceClient();
                    status = services.SaveExportData(exportModel);
                    //return RedirectToAction("Index");
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
        public JsonResult GetSalesVehicleByPapertype(int paperTypeID)
        {
            dynamic vehiclePaperByType = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient papersServiceClient = new PapersServiceClient();
                    vehiclePaperByType = papersServiceClient.GetSalesVehicleByPapertype(paperTypeID);

                    //return Json(new { vehiclePaperByType }, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                vehiclePaperByType = null;
                throw e;
            }
            return Json(new { vehiclePaperByType }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetCustomerDetails(string prefix)
        {
            dynamic customers = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient service = new PapersServiceClient();
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
        public ActionResult GetAccountListData(string chassisNum)
        {
            dynamic accountList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient service = new PapersServiceClient();

                    accountList = service.GetAccountListData(chassisNum);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "Something Wrong");
                accountList = null;
                throw ex;
            }
            return Json(accountList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDeductionAmount(string strChassisNum)
        {
            dynamic amount = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    PapersServiceClient service = new PapersServiceClient();
                    amount = service.GetDeductionAmount(strChassisNum);
                    //return Json(customers, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                amount = null;
                throw ex;
            }
            return Json(amount, JsonRequestBehavior.AllowGet);

        }

        #region DeleteImport
        [HttpPost]
        public ActionResult DeleteImportPaperDetails(long id)
        {
            //int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {

                    PapersServiceClient services = new PapersServiceClient();
                    status = services.DeleteImportPaperDetails(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            //return View("Index");
            return new JsonResult { Data = new { status = status } };

        }

        #endregion



        #region DeleteExport
        [HttpPost]
        public ActionResult DeleteExportPaperDetails(long id)
        {
            //int id = Convert.ToInt32(Helpers.CommonMethods.Decrypt(HttpUtility.UrlDecode(ID)));
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {

                    PapersServiceClient services = new PapersServiceClient();
                    status = services.DeleteExportPaperDetails(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }
            //return View("Index");
            return new JsonResult { Data = new { status = status } };

        }

        #endregion
    }
}