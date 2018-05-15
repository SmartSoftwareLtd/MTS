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
    public class MYardController : Controller
    {
        //
        // GET: /MYard/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveYard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllYard()
        {
            dynamic list = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    MYardServiceClient service = new MYardServiceClient();
                    list = service.GetAllYard();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "something went wrong");
                list = null;
                throw e;

            }
           
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveYard(MYardModel yardData)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    MYardServiceClient service = new MYardServiceClient();
                    status = service.SaveYard(yardData);
                    return RedirectToAction("Index");
                }
               
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "something went wrong");
                status = false;
                throw ex;
            }
            return null;
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    MYardServiceClient service = new MYardServiceClient();
                    status = service.Delete(id);
                    //return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", "something went wrong");
                status = false;
                throw ex;
            }
            return Json(status,JsonRequestBehavior.AllowGet);
        }
	}
}