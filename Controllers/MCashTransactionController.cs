using AuctionInventory.Models;
using AuctionInventory.Services;
using AuctionInventoryDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionInventory.Controllers
{
    public class MCashTransactionController : Controller
    {
        //
        // GET: /MCashTransaction/
        public ActionResult Index()
        {
            ViewBag.PageName = "Journal Transaction List"; 
            return View();
        }

        public ActionResult Save()
        {
            ViewBag.PageName = "Create Journal Transaction"; 
            return View();
        }

        public ActionResult GetAllCash()
        {
            dynamic transactions = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    cashTransactionServiceClient service = new cashTransactionServiceClient();

                    transactions = service.GetAllCash();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                transactions = null;
                throw e;

            }
            return Json(transactions, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetAllTransactions()
        {
            dynamic transactions = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    cashTransactionServiceClient service = new cashTransactionServiceClient();

                    transactions = service.GetAllTransactions();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                transactions = null;
                throw e;

            }
            return Json(transactions, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetAllTransactionsByDate(DateTime fromDate,DateTime toDate)
        {
            dynamic transactions = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    cashTransactionServiceClient service = new cashTransactionServiceClient();

                    transactions = service.GetAllTransactionsByDate(fromDate, toDate);
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                transactions = null;
                throw e;

            }
            return Json(transactions, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ShowPartyName()
        {
            AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            var partyList = auctionContext.AccountParties.ToList();
            //var partyName = partyList.Select(a => a.strFirstName).ToList();
            return Json(partyList, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult SaveEdit(CashTransactionModel cashModel)
        {
            bool status = true;
            try
            {
                if (ModelState.IsValid)
                {
                    cashTransactionServiceClient service = new cashTransactionServiceClient();
                    status = service.SaveEdit(cashModel);

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
        public ActionResult DeleteTransaction(int ID)
        {

            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    cashTransactionServiceClient Service = new cashTransactionServiceClient();

                    status = Service.Delete(ID);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong");
              
                throw e;
            }
            return View("Index");
        }
	}
}