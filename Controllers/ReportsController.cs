using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventory.Services;
using AuctionInventory.MyRoleProvider;
namespace AuctionInventory.Controllers
{
      [Permissions(Permissions.View)]
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VehicleDetailsReport()
        {
            dynamic vehicleList = 0;
            try
            {
                if(ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    vehicleList = service.VehicleDetailsReport();
                }
            }
            catch(Exception ex)
            {
               
                ModelState.AddModelError("error","Something went Wrong");
                vehicleList = null;
                throw ex;
               
            }
            return Json(vehicleList,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetVehiclesBySupplierName(string prefix)
        {
            dynamic vehicles = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
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
        public ActionResult GetVehiclesBySupplierID(int id)
        {
            dynamic vehicleList = 0;
            try
            {
                if(ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    vehicleList = service.GetVehiclesBySupplierID(id);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("error","Something went wrong");
                vehicleList = null;
                throw ex;
            }
            return Json(vehicleList,JsonRequestBehavior.AllowGet);
        }
        #region dailySalesReport
        public ActionResult DailySalesReport()
        {
            ViewBag.PageName = "Daily Sales Report";
            return View();
        }


        [HttpPost]
        public ActionResult GetDailySalesData(DateTime date)
        {
            dynamic salesList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    salesList = service.GetDailySalesData(date);
                    //return Json(vehicleList, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                salesList = null;
                throw ex;
            }
            return Json(salesList, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region RecievableReport
        public ActionResult RecievableReport()
        {
            ViewBag.PageName = "Daily Recievable Report"; 
            return View();
        }


        [HttpPost]
        public ActionResult GetRecievableReportData(DateTime fromDate,DateTime toDate)
        {
            dynamic salesList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    salesList = service.GetRecievableReportData(fromDate, toDate);
                    //return Json(vehicleList, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                salesList = null;
                throw ex;
            }
            return Json(salesList, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region dailyBalanceReport
        public ActionResult DailyBalanceReport()
        {
            ViewBag.PageName = "Daily Balance Report"; 
            return View();
        }


        [HttpPost]
        public ActionResult GetDailyBalanceData(DateTime date)
        {
            dynamic salesList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    salesList = service.GetDailyBalanceData(date);
                    //return Json(vehicleList, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                salesList = null;
                throw ex;
            }
            return Json(salesList, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region CashSummaryReport
        public ActionResult CashSummaryReport()
        {
            ViewBag.PageName = "Cash Summary Report";
            return View();
        }


        [HttpPost]
        public ActionResult GetCashSummaryData(DateTime date)
        {
            dynamic salesList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    salesList = service.GetCashSummaryData(date);
                    //return Json(vehicleList, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                salesList = null;
                throw ex;
            }
            return Json(salesList, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region VehicleDeliveryReport
        public ActionResult VehicleDeliveryReport()
        {
            ViewBag.PageName = "Vehicle Delivery Report"; 
            return View();
        }


        [HttpPost]
        public ActionResult GetVehicleDeliveryData(DateTime fromDate, DateTime toDate)
        {
            dynamic salesList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    salesList = service.GetVehicleDeliveryData(fromDate, toDate);
                    //return Json(vehicleList, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something Went Wrong");
                salesList = null;
                throw ex;
            }
            return Json(salesList, JsonRequestBehavior.AllowGet);


        }
        #endregion

        #region ExpenseReport
        public ActionResult VehicleExpenseReportList()
        {
            ViewBag.PageName = "Vehicle Expense Report"; 
            return View();
        }

        [HttpGet]
        public ActionResult SingleVehicleExpenseReport()
        {
            dynamic vehicleList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    vehicleList = service.SingleVehicleExpenseReport();
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something went Wrong");
                vehicleList = null;
                throw ex;

            }
            return Json(vehicleList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AllVehicleExpenseReport(DateTime fromDate, DateTime toDate)
        {
            dynamic vehicleList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    vehicleList = service.AllVehicleExpenseReport(fromDate, toDate);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something went Wrong");
                vehicleList = null;
                throw ex;

            }
            return Json(vehicleList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region BuyerList

        public ActionResult BuyerListReport()
        {
            return View();
        }

        public ActionResult GetAllCustomers()
        {
            dynamic customer = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetAllCustomers();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                customer = null;
                throw e;

            }
            return Json(customer, JsonRequestBehavior.AllowGet);

        }

        //FOR ALL SHOWROOM CUSTOMERS
        public ActionResult GetAllSRCustomers()
        {
            dynamic customer = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.CustomerServiceClient customerServiceClient = new Services.CustomerServiceClient();

                    customer = customerServiceClient.GetAllSRCustomers();
                    //if (customer.Count == 0 || customer == null)
                    //{
                    //    ModelState.AddModelError("error", "No Record Found");
                    //}


                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                customer = null;
                throw e;

            }
            return Json(customer, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region SupplierList

        public ActionResult SupplierListReport()
        {
            return View();
        }

        public ActionResult GetAllSuppliers()
        {
            dynamic listSupplier = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    Services.SupplierServiceClient supplierServiceClient = new Services.SupplierServiceClient();
                    listSupplier = supplierServiceClient.GetAllSuppliers();
                    //ViewBag.ImageData = listSupplier.SupplierPhoto;
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Wrong");
                listSupplier = null;
                throw e;

            }
            return Json(listSupplier, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region deposit_RefundReport_developer1

        public ActionResult DepositRefundReport()
        {
            ViewBag.PageName = "Deposit Refund Report";
            return View();
        }


        [HttpPost]
        public ActionResult GetDepositRefundData(DateTime fromDate, DateTime toDate)
        {
            dynamic accountList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();

                    accountList = service.GetDepositeRefundData(fromDate, toDate);

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
        #endregion

        #region PrintYardData
        public ActionResult YardData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YardDataReport()
        {
            dynamic YardDataList = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    ReportsServiceClient service = new ReportsServiceClient();
                    YardDataList = service.YardDataReport();
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error", "Something went Wrong");
                YardDataList = null;
                throw ex;

            }
            return Json(YardDataList, JsonRequestBehavior.AllowGet);
        }
        #endregion
	}
}