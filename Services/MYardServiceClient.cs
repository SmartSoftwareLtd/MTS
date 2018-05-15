using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.Repositories;
namespace AuctionInventory.Services
{
    public class MYardServiceClient
    {

        public dynamic GetAllYard()
        {
            dynamic list = 0;
            MYardRepository repo = new MYardRepository();
            list = repo.GetAllYard();
            return list;
        }

        public bool SaveYard(MYardModel yardData)
        {
            bool status = false;
            MYardRepository repo=new MYardRepository();
            status = repo.SaveYard(parseAddYard(yardData));
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
             MYardRepository repo = new MYardRepository();
           status=repo.Delete(id);
           return status;
       }
        #region
        public MYard parseAddYard(MYardModel yardData)
        {
            MYard mYard = new MYard();
            if(yardData!=null){
                mYard.iYardID = yardData.iYardID;
                mYard.strYardName = yardData.strYardName;
                mYard.iYardLimit = yardData.iYardLimit;
            }
            return mYard;
        }

        #endregion
    }

   
}