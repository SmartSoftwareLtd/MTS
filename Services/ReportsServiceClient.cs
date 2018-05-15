using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventoryDAL.Repositories;
namespace AuctionInventory.Services
{
    public class ReportsServiceClient
    {
          public dynamic VehicleDetailsReport()
        {
            dynamic vehicleList = 0;
            ReportsRepository repo = new ReportsRepository();

            vehicleList = repo.VehicleDetailsReport();
            return vehicleList;
              
        }
          public dynamic GetVehicles(string prefix)
          {
              ReportsRepository repo = new ReportsRepository();
              var vehicles = repo.GetVehicles(prefix);
              return vehicles;

          }
        public  dynamic GetVehiclesBySupplierID(int id)
          {
              ReportsRepository repo = new ReportsRepository();
              var vehicleList = repo.GetVehiclesBySupplierID(id);
              return vehicleList;
          }

        public dynamic GetDailySalesData(DateTime date)
        {
            ReportsRepository repo = new ReportsRepository();
            dynamic getvehiclelist = repo.GetDailySalesData(date);
            return getvehiclelist;

        }
        public dynamic GetDailyBalanceData(DateTime date)
        {
            ReportsRepository repo = new ReportsRepository();
            dynamic getvehiclelist = repo.GetDailyBalanceData(date);
            return getvehiclelist;

        }
        
        

        public dynamic GetRecievableReportData(DateTime fromDate, DateTime toDate)
        {
            ReportsRepository repo = new ReportsRepository();
            dynamic getvehiclelist = repo.GetRecievableReportData(fromDate, toDate);
            return getvehiclelist;

        }

        public dynamic GetVehicleDeliveryData(DateTime fromDate, DateTime toDate)
        {
            ReportsRepository repo = new ReportsRepository();
            dynamic getvehiclelist = repo.GetVehicleDeliveryData(fromDate, toDate);
            return getvehiclelist;

        }

        public dynamic GetCashSummaryData(DateTime Date)
        {
            ReportsRepository repo = new ReportsRepository();
            dynamic CashSummary = repo.GetCashSummary(Date);
            return CashSummary;

        }

        #region ExpenseReport
        public dynamic SingleVehicleExpenseReport()
        {
            dynamic vehicleList = 0;
            ReportsRepository repo = new ReportsRepository();

            vehicleList = repo.SingleVehicleExpenseReport();
            return vehicleList;

        }

        public dynamic AllVehicleExpenseReport(DateTime fromDate, DateTime toDate)
        {
            dynamic vehicleList = 0;
            ReportsRepository repo = new ReportsRepository();

            vehicleList = repo.AllVehicleExpenseReport(fromDate, toDate);
            return vehicleList;

        }
        #endregion


        #region deposit_RefundReport_developer1
        public dynamic GetDepositeRefundData(DateTime fromDate, DateTime toDate)
        {
            ReportsRepository repo = new ReportsRepository();
            dynamic List = repo.GetDepositeRefundData(fromDate, toDate);
            return List;
        }
        #endregion


        #region PrintYardData
        public dynamic YardDataReport()
        {
            ReportsRepository repo = new ReportsRepository();
            dynamic YardDataList = repo.GetYardDataList();
            return YardDataList;

        }
        #endregion
    }
}