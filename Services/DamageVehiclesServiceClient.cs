using AuctionInventory.Models;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Services
{
    public class DamageVehiclesServiceClient
    {
        public dynamic GetVehicles(string prefix)
        {
            DamageVehiclesRepository repo = new DamageVehiclesRepository();
            var vehicles = repo.GetVehicles(prefix);
            return vehicles;

        }

        public dynamic GetDamageVehicles(int vehicleID)
        {
            DamageVehiclesRepository repo = new DamageVehiclesRepository();
            var vehicles = repo.GetDamageVehicles(vehicleID);
            return vehicles;

        }


        public dynamic GetAllDamageVehicles()
        {
            DamageVehiclesRepository repo = new DamageVehiclesRepository();
            var vehicles = repo.GetAllDamageVehicles();
            return vehicles;

        }
        public bool SaveDamageVehicles(DamageVehicleModel damageVehicles)
        {
            bool status = true;
            DamageVehicleModel vehicles = new DamageVehicleModel();
            DamageVehiclesRepository repo = new DamageVehiclesRepository();
            status = repo.SaveEditDamageVehicles(ParserAddDamageVehicles(damageVehicles));
            return status;
        }

        private DamageVehicle ParserAddDamageVehicles(DamageVehicleModel vehicles)
        {
            DamageVehicle mvehicles = new DamageVehicle();

            if (vehicles != null)
            {
                mvehicles.iDamageVehicleID = vehicles.iDamageVehicleID;
                mvehicles.iVehicleID = vehicles.iVehicleID;
                mvehicles.iYardID = vehicles.iYardID;
                mvehicles.dtArrivalDate = vehicles.dtArrivalDate;
                mvehicles.strArrivalDate = vehicles.strArrivalDate;
                mvehicles.repairingStatus = vehicles.repairingStatus;
               
            }
            return mvehicles;
        }
    }
}