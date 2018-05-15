using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventoryDAL.Repositories;
namespace AuctionInventory.Services
{
    public class IncomeAndExpenditureServiceClient
    {
        public dynamic GetAllSaleByLot()
        {
            dynamic listSalesByLot = 0;
            IncomeAndExpenditureRepository repo = new IncomeAndExpenditureRepository();
            listSalesByLot = repo.GetAllSaleByLot();
            return listSalesByLot;

        }

        public dynamic GetAllPurchaseByLot()
        {
            dynamic listPurchaseByLot = 0;
            IncomeAndExpenditureRepository repo = new IncomeAndExpenditureRepository();
            listPurchaseByLot = repo.GetAllPurchaseByLot();
            return listPurchaseByLot;

        }

        public dynamic GetAllClearingChargesByLot()
        {
            dynamic listExpenseByLot = 0;
            IncomeAndExpenditureRepository repo = new IncomeAndExpenditureRepository();
            listExpenseByLot = repo.GetAllClearingChargesByLot();
            return listExpenseByLot;

        }


        public dynamic GetAllRepairingChargesByLot()
        {
            dynamic listExpenseByLot = 0;
            IncomeAndExpenditureRepository repo = new IncomeAndExpenditureRepository();
            listExpenseByLot = repo.GetAllRepairingChargesByLot();
            return listExpenseByLot;

        }

        public dynamic GetAllImportDutyByLot()
        {
            dynamic listExpenseByLot = 0;
            IncomeAndExpenditureRepository repo = new IncomeAndExpenditureRepository();
            listExpenseByLot = repo.GetAllImportDutyByLot();
            return listExpenseByLot;

        }
    }
}