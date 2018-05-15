using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventory.Models;
using AuctionInventory.Services;
using AuctionInventory.MyRoleProvider;

namespace AuctionInventory.Controllers
{
      [Permissions(Permissions.View)]
    public class AccountPartyController : Controller
    {
        //
        // GET: /AccountParty/
        public ActionResult Index()
        {
            ViewBag.PageName = "Account Party List";
            return View();
        }
        public ActionResult GetAccountListData()
        {
            dynamic accountList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    AccountPartyServiceClient service = new AccountPartyServiceClient();

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
            ViewBag.PageName = "Create Account Party";
            return View();
        }

        [HttpPost]
        public ActionResult SaveEdit(AccountPartyModel acntPartyModel)
        {
            bool status = true;
            try
            {
                if (ModelState.IsValid)
                {
                    AccountPartyServiceClient service = new AccountPartyServiceClient();
                    status = service.SaveEdit(acntPartyModel);

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
                    AccountPartyServiceClient service = new AccountPartyServiceClient();
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
	}
}