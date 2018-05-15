using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventory.Models;
using AuctionInventory.Services;
using AuctionInventoryDAL.Entity;
using AuctionInventory.MyRoleProvider;

namespace AuctionInventory.Controllers
{
     [Permissions(Permissions.View)]
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAccountListData()
        {
            dynamic accountList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    AccountServiceClient service = new AccountServiceClient();

                    accountList = service.GetAccountListData();

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

        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEdit(AccountModel acntModel)
        {
            bool status = true;
            try
            {
                if (ModelState.IsValid)
                {
                    AccountServiceClient service = new AccountServiceClient();
                    status = service.SaveEdit(acntModel);

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
        public ActionResult Delete(int id)
        {
            bool status = true;
            try
            {
                if (id > 0 && id != null)
                {
                    AccountServiceClient service = new AccountServiceClient();
                    status = service.Delete(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                status = false;
                throw e;
            }
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowPartyName()
        {
            AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            var partyList = auctionContext.AccountParties.ToList();
            //var partyName = partyList.Select(a => a.strFirstName).ToList();
            return Json(partyList, JsonRequestBehavior.AllowGet);

        }
    }
}