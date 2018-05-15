using AuctionInventoryDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Services
{
    public class VehicleStatusServiceClient
    {
        #region deveoper1
        public dynamic GetSoldVehiclesInYard(DateTime fromDate, DateTime ToDate)
        {

            VehicleStatusRepository repo = new VehicleStatusRepository();
            var expenses = repo.GetSoldVehiclesInYard(fromDate, ToDate);
            return expenses;
        }



        public dynamic GetSoldVehicles(DateTime fromDate,DateTime ToDate)
        {

            VehicleStatusRepository repo = new VehicleStatusRepository();
            var expenses = repo.GetSoldVehicles(fromDate,ToDate);
            return expenses;
        }


        public dynamic GetRemainingVehicles(DateTime fromDate, DateTime ToDate)
        {

            VehicleStatusRepository repo = new VehicleStatusRepository();
            var expenses = repo.GetRemainingVehicles(fromDate, ToDate);
            return expenses;
        }


        public dynamic GetPendingCars(DateTime fromDate, DateTime ToDate)
        {

            VehicleStatusRepository repo = new VehicleStatusRepository();
            var vehicle = repo.GetPendingCars(fromDate, ToDate);
            return vehicle;
        }
        #endregion
    }
}