using AuctionInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.Repositories;
using AuctionInventory.MyRoleProvider;

namespace AuctionInventory.Controllers
{
    [Authorize]
    //[Permissions(Permissions.View)]
    public class HomeController : Controller
    {
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public ActionResult DashBoard()
        {
            ViewBag.PageName = "DashBoard";
            return View();
        }
        public ActionResult SupplierDashBoard()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WrongPage()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
        #region CRUD

        public ActionResult GetEmployees()
        {
            List<AuctionInventoryDAL.Entity.Employee> listEmployee = new List<AuctionInventoryDAL.Entity.Employee>();
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    listEmployee = employeeRepository.GetAll();
                    if (listEmployee.Count == 0 || listEmployee == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }

                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                listEmployee = null;
                throw e;
            }

            return Json(new { data = listEmployee }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            AuctionInventoryDAL.Entity.Employee employee = new AuctionInventoryDAL.Entity.Employee();
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (employee == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                    employee = employeeRepository.Get(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                employee = null;
                throw e;
            }
            return View(employee);


        }

        [HttpPost]
        public ActionResult Save(AuctionInventoryDAL.Entity.Employee emp)
        {

            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (emp == null)
                    {
                        ModelState.AddModelError("error", "Record Can not be null");
                    }
                    status = employeeRepository.SaveEdit(emp);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            AuctionInventoryDAL.Entity.Employee employee = new AuctionInventoryDAL.Entity.Employee();
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (employee == null)
                    {
                        ModelState.AddModelError("error", "No Record Found");
                    }
                    employee = employeeRepository.Get(id);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                employee = null;
                throw e;
            }

            return View(employee);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {

            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository employeeRepository = new EmployeeRepository();
                    if (id == 0)
                    {
                        ModelState.AddModelError("error", "Record Can not be Zero");
                    }
                    status = employeeRepository.DeleteEmployee(id);
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("error", "Something Went Wrong!");
                status = false;
                throw e;
            }

            return new JsonResult { Data = new { status = status } };

        }

        #endregion

        public ActionResult WrongPassword()
        {
            return View();
        }

        //this action is used for update satatus in sales payment only
        //public ActionResult TestForSalesPayment()
        //{
        //    var amount = (
        //                   from t2 in auctionContext.Sales
        //                   join AM in auctionContext.SalesPayments on t2.iSaleID equals AM.iSaleID  
        //                  //from AM in auctionContext.SalesPayments.Where(AM => AM.iSaleID == t2.iSaleID).DefaultIfEmpty()
        //                  select new
        //                  {
        //                      ysnPaymentStatusFromSales = AM.ysnPaymentStatusFromSales,
        //                      iSaleID = AM.iSaleID,

        //                  }).OrderBy(a=>a.iSaleID).ToList();

        //    var dailyBalanceReportData = amount.GroupBy(a => a.iSaleID).Select(x =>
        //            new
        //            {
        //                iSaleID = x.FirstOrDefault().iSaleID,
        //                ysnPaymentStatusFromSales = x.FirstOrDefault().ysnPaymentStatusFromSales,
        //            }).ToList();
        //    if (dailyBalanceReportData.Count > 0)
        //    {
        //        foreach (var item in dailyBalanceReportData)
        //        {
        //            var test1 = auctionContext.SalesPayments.Where(z => z.iSaleID == item.iSaleID).FirstOrDefault();
        //            test1.ysnPaymentStatusFromSales = true;
        //            auctionContext.SaveChanges();
        //        }
               
        //    }
           

        //    return Json(dailyBalanceReportData, JsonRequestBehavior.AllowGet);
        //}




        #region DashBoard Data
        public ActionResult TotalReceiveableAmount()
        {
            var amount = (from AM in auctionContext.Sales
                          select new
                          {
                              dmlAdvance = AM.dmlAdvance,
                              dmlSellingPrice = AM.dmlSellingPrice,

                          }).ToList();
            var dmlAdvance = amount.Sum(x => x.dmlAdvance);
            var dmlSellingPrice = amount.Sum(x => x.dmlSellingPrice);
            var amountReceived = dmlSellingPrice - dmlAdvance;

            return Json(amountReceived, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LastDaySale()
        {
            //var lstDate =Convert.ToDateTime("2017-08-02 12:00:00 AM");
            var lstDate = DateTime.Today;
            var lastDay = lstDate.AddDays(-1);
            //var test = Convert.ToDateTime("10/26/2017");
            var ttlSale = (from AM in auctionContext.Sales

                           //join t1 in auctionContext.SalesVehicles on AM.iSaleFrontEndID equals t1.iSaleFrontEndID
                           //join t2 in auctionContext.Vehicles on (int)AM.iYardID equals t1.iYardID

                           from t1 in auctionContext.SalesVehicles.Where(t1 => t1.iSaleFrontEndID == AM.iSaleFrontEndID).DefaultIfEmpty()
                           from t2 in auctionContext.Vehicles.Where(t2 => t2.iVehicleID == t1.iVehicleID).DefaultIfEmpty()
                           where AM.dtSalesDate == lastDay
                           select AM).Count();

            return Json(ttlSale, JsonRequestBehavior.AllowGet);
        }



        public ActionResult CashBalanceLastNight()
        {
            //var lstDate =Convert.ToDateTime("2017-08-02 12:00:00 AM");
            var lstDate = DateTime.Today;
            var lastDay = lstDate.AddDays(-1);

            var ttlLastNightAmount = (from AM in auctionContext.Sales

                                      //from t1 in auctionContext.SalesVehicles.Where(t1 => t1.iSaleFrontEndID == AM.iSaleFrontEndID).DefaultIfEmpty()
                                      //from t2 in auctionContext.Vehicles.Where(t2 => t2.iVehicleID == t2.iVehicleID).DefaultIfEmpty()
                                      where AM.dtSalesDate == lastDay
                                      select new
                                     {
                                         dmlAdvance = AM.dmlAdvance,

                                     }).ToList();
            var cashBalanceLastNight = ttlLastNightAmount.Sum(x => x.dmlAdvance);
            return Json(cashBalanceLastNight, JsonRequestBehavior.AllowGet);
        }

        public ActionResult YardSpace()
        {
            var result = (from AM in auctionContext.MYards
                          //join t1 in auctionContext.Sales on (int)AM.iYardID equals t1.iYardID
                          
                          
                        from t1 in auctionContext.Sales.Where(t1 => t1.iYardID == AM.iYardID).DefaultIfEmpty()
                         
                          
                          //join t2 in auctionContext.SalesVehicles on t1.iSaleFrontEndID equals t2.iSaleFrontEndID
                          //from t2 in auctionContext.SalesVehicles.Where(t2 => t2.iSaleFrontEndID == t1.iSaleFrontEndID).DefaultIfEmpty()
                          //from t3 in auctionContext.Vehicles.Where(t3 => t3.iVehicleID == t2.iVehicleID).DefaultIfEmpty()
                          //from t2 in auctionContext.Vehicles.Where(t2 => t2.iVehicleID == t2.iVehicleID).DefaultIfEmpty()
                          //where AM.dtSalesDate == lastDay                                   
                          //orderby AM.dmlSellingPrice descending
                         
                          select new
                          {
                              iYardID = AM.iYardID,
                              strYardName = AM.strYardName,
                              iYardLimit = AM.iYardLimit,
                             
                          }).ToList();


            if (result.Count > 0)
            {
                var YardLists = result.GroupBy(x => x.iYardID).Select(y =>
                    new
                    {
                        iYardID = y.Key,
                        strYardName = y.First().strYardName,
                        iYardLimit = y.First().iYardLimit, 
                        Count = y.Count()
                    }).Distinct().ToList();

                
                return Json(YardLists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public ActionResult TopCustomers()
        {
            //var lstDate =Convert.ToDateTime("2017-08-02 12:00:00 AM");

   
            var result = (from AM in auctionContext.Sales

                          from t1 in auctionContext.MCustomers.Where(t1 => t1.iCustomerID == AM.iCustomerID).DefaultIfEmpty()
                          //from t2 in auctionContext.Vehicles.Where(t2 => t2.iVehicleID == t2.iVehicleID).DefaultIfEmpty()
                          //where AM.dtSalesDate == lastDay                                   
                          //orderby AM.dmlSellingPrice descending


                          select new
                          {
                              CustomerFullName = t1.strFirstName + " " + t1.strLastName,
                              iCustomerID = AM.iCustomerID,
                              strSalesInvoiceNo = AM.strSalesInvoiceNo,
                              ShowRoomCustomerName = t1.strPersonFirstName + " " + t1.strPersonLastName,
                              iCutomerTypeID = t1.iCutomerTypeID,
                          }).ToList();


            if (result.Count > 0)
            {
                var topTenCustomers = result.GroupBy(x => x.iCustomerID).Select(y =>
                    new
                    {
                        iCustomerID = y.Key,
                        CustomerFullName = y.First().CustomerFullName,
                        ShowRoomCustomerName = y.First().ShowRoomCustomerName,
                        strSalesInvoiceNo = y.First().strSalesInvoiceNo,
                        iCutomerTypeID = y.First().iCutomerTypeID,
                        count = y.Count()
                    }).OrderByDescending(x => x.count).Distinct().ToList();

                var ttlTenCustomersCount = topTenCustomers.Take(10);
                return Json(ttlTenCustomersCount, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public ActionResult TopSuppliersAndStocks()
        {
            //var lstDate =Convert.ToDateTime("2017-08-02 12:00:00 AM");


            var result = (from AM in auctionContext.Vehicles
                                            from t1 in auctionContext.TPurchases.Where(t1 => t1.PurchaseID == AM.PurchaseID).DefaultIfEmpty()
                                            from t2 in auctionContext.MSuppliers.Where(t2 => t2.iSupplierID == t1.iSupplierID).DefaultIfEmpty()
                                            where !auctionContext.SalesVehicles.Any(f => f.iVehicleID == AM.iVehicleID) 

                                            //where AM.dtSalesDate == lastDay
                                            // orderby AM.iVehicleID descending
                                            select new
                                            {
                                                strCompanyName = t2.strCompanyName,
                                                //iSalesInvoiceID = AM.iSalesInvoiceID,
                                                iVehicleID = AM.iVehicleID,

                                            }).ToList();
            if (result.Count > 0) { 
            var topTenSuppliersAndStocks = result.GroupBy(x => x.strCompanyName).Select(y =>
                new
                {
                    strCompanyName = y.Key,
                    iVehicleID=y.Count()
                }).Take(10).ToList();

            var ttlSuppliersAndStocksCount = topTenSuppliersAndStocks.Take(10);
           
            return Json(ttlSuppliersAndStocksCount, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public ActionResult TopTenReceiveableCustomers()
        {
            //var lstDate =Convert.ToDateTime("2017-08-02 12:00:00 AM");


            var preResult = (from AM in auctionContext.Sales
                                              join t1 in auctionContext.MCustomers on AM.iCustomerID equals t1.iCustomerID
                                              //from t1 in auctionContext.MCustomers.Where(t1 => t1.iCustomerID == AM.iCustomerID).DefaultIfEmpty()
                                              ////from t2 in auctionContext.Vehicles.Where(t2 => t2.iVehicleID == t2.iVehicleID).DefaultIfEmpty()
                                              where AM.dmlBalance > 0
                                              //orderby AM.dmlBalance descending
                                              select new
                                              {
                                                  iCustomerID = t1.iCustomerID,
                                                  //CustomerFullName = t1.strFirstName + " " + t1.strLastName,
                                                  CustomerFullName = t1.strFirstName,
                                                  ShowRoomCustomerName = t1.strPersonFirstName + " " + t1.strPersonLastName,
                                                  iCutomerTypeID = t1.iCutomerTypeID,
                                                  dmlBalance = AM.dmlBalance,

                                              }).ToList();
            if (preResult.Count>0)
            {
            
            var topTenReceiveableCustomers = preResult.GroupBy(x =>x.iCustomerID).Select(x=>
                new
                {
                    CustomerFullName = x.FirstOrDefault().CustomerFullName,
                    ShowRoomCustomerName = x.FirstOrDefault().ShowRoomCustomerName,
                    iCutomerTypeID = x.FirstOrDefault().iCutomerTypeID,
                    dmlBalance = x.Sum(a=>a.dmlBalance),
                
                }).Distinct().OrderByDescending(z=>z.dmlBalance).Take(10);

            return Json(topTenReceiveableCustomers, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }

        public ActionResult TotalCarsStock()
        {
            var ttlCarsStock = (from AM in auctionContext.Vehicles
                                where !auctionContext.SalesVehicles.Any(f => f.iVehicleID == AM.iVehicleID)
                                select AM).Count();

            return Json(ttlCarsStock, JsonRequestBehavior.AllowGet);
        }


        public ActionResult TotalPendingCars()
        {
            var ttlPendingCars = (from AM in auctionContext.Sales
                                  //from t1 in auctionContext.SalesPayments.Where(t1=>t1.iSaleID==AM.iSaleID).DefaultIfEmpty() 
                                  join t1 in auctionContext.SalesVehicles on AM.iSaleFrontEndID equals t1.iSaleFrontEndID
                                  join t2 in auctionContext.Vehicles on t1.iVehicleID equals t2.iVehicleID
                                  where AM.dmlBalance > 0
                                  select AM).Count();

            return Json(ttlPendingCars, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThisMonthSales()
        {
            DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dtTo = DateTime.Now;

            var ttlThisMonthSales = (from AM in auctionContext.Sales
                                     //from t1 in auctionContext.SalesPayments.Where(t1=>t1.iSaleID==AM.iSaleID).DefaultIfEmpty() 
                                     where AM.dtSalesDate >= dtFrom && AM.dtSalesDate <= dtTo
                                     select new
                                     {
                                         dmlSellingPrice = AM.dmlSellingPrice,
                                         iSalesInvoiceID = AM.iSalesInvoiceID

                                     }).ToList();
            var ttlThisMonthSalesAmount = ttlThisMonthSales.Sum(x => x.dmlSellingPrice);
            var ttlThisMonthSalesCount = ttlThisMonthSales.Count();
            return Json(new { ttlThisMonthSalesAmount, ttlThisMonthSalesCount }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}