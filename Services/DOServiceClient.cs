using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class DOServiceClient
    {
        public dynamic GetCustomerDetails(string prefix)
        {
            DORepository repo = new DORepository();
            var customer = repo.GetCustomerDetails(prefix);
            return customer;

        }

        #region DO Customer Restriction To Print
        public bool CheckCustomerIsBlockOrNotForDO(string chassisNum)
        {
            bool status = true;

            DORepository repo = new DORepository();
            status = repo.CheckCustomerIsBlockOrNotForDO(chassisNum);
            return status;
        }
        #endregion
        public bool  DeleteDO(int ID)
        {
            bool status = true;
            DORepository repo = new DORepository();
            status = repo.DeleteDO(ID);
            return status;
        }
        public dynamic GetAllDOrders()
        {

            DORepository repo = new DORepository();
            var AllDOrders = repo.GetAllDOrders();
            return AllDOrders;
        }
        public bool SaveEdit(DeliveryOrderModel doModel)
        {
            bool status = true;
            DORepository repo = new DORepository();
            status = repo.SaveEdit(ParserAddDO(doModel));
            return status;
        }

        #region Parser
        private DeliveryOrder ParserAddDO(DeliveryOrderModel doModel)
        {
            DeliveryOrder doEntity = new DeliveryOrder();

            if (doEntity != null)
            {


                doEntity.iDeliveryOrderID = doModel.iDeliveryOrderID;
                doEntity.iVehicleID = doModel.iVehicleID;
                doEntity.strCustomerName = doModel.strCustomerName;
                doEntity.strCurrentDate = doModel.strCurrentDate;
                doEntity.dtCurrentDate = doModel.dtCurrentDate;
                doEntity.strExpiryDate = doModel.strExpiryDate;
                doEntity.dtExpiryDate = doModel.dtExpiryDate;
                doEntity.strCarDeliveryDate = doModel.strCarDeliveryDate;
                doEntity.dtCarDeliveryDate = doModel.dtCarDeliveryDate;
                doEntity.ysnDeliveryStatus = doModel.ysnDeliveryStatus;

            }

            return doEntity;
        }

        #endregion
    }
}