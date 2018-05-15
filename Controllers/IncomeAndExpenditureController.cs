using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventory.Models;
using AuctionInventoryDAL.Entity;
using AuctionInventory.Services;
using AuctionInventory.MyRoleProvider;
namespace AuctionInventory.Controllers
{
      [Permissions(Permissions.View)]
    public class IncomeAndExpenditureController : Controller
    {
      
        //
        // GET: /IncomeAndExpenditure/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllSaleByLot()
        {
            dynamic listSalesByLot = 0;
            try
            {
                if(ModelState.IsValid)
                {
                    IncomeAndExpenditureServiceClient service = new IncomeAndExpenditureServiceClient();
                    listSalesByLot = service.GetAllSaleByLot();
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error", "SomethingWrong");
                listSalesByLot = 0;
                throw ex;
            }
            return Json(listSalesByLot, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllPurchaseByLot()
        {
            dynamic listPurchaseByLot = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    IncomeAndExpenditureServiceClient service = new IncomeAndExpenditureServiceClient();
                    listPurchaseByLot = service.GetAllPurchaseByLot();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "SomethingWrong");
                listPurchaseByLot = 0;
                throw ex;
            }
            return Json(listPurchaseByLot, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetAllClearingChargesByLot()
        {
            dynamic listClearingChargesByLot = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    IncomeAndExpenditureServiceClient service = new IncomeAndExpenditureServiceClient();
                    listClearingChargesByLot = service.GetAllClearingChargesByLot();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "SomethingWrong");
                listClearingChargesByLot = 0;
                throw ex;
            }
            return Json(listClearingChargesByLot, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public ActionResult GetAllRepairingChargesByLot()
        {
            dynamic listRepairingChargesByLot = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    IncomeAndExpenditureServiceClient service = new IncomeAndExpenditureServiceClient();
                    listRepairingChargesByLot = service.GetAllRepairingChargesByLot();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "SomethingWrong");
                listRepairingChargesByLot = 0;
                throw ex;
            }
            return Json(listRepairingChargesByLot, JsonRequestBehavior.AllowGet);
        }

        

              
        [HttpGet]
        public ActionResult GetAllImportDutyByLot()
        {
            dynamic listImportDutyByLot = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    IncomeAndExpenditureServiceClient service = new IncomeAndExpenditureServiceClient();
                    listImportDutyByLot = service.GetAllImportDutyByLot();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "SomethingWrong");
                listImportDutyByLot = 0;
                throw ex;
            }
            return Json(listImportDutyByLot, JsonRequestBehavior.AllowGet);
        }
	}
}