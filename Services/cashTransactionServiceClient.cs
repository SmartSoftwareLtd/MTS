using AuctionInventory.Models;
using AuctionInventoryDAL.Entity;
using AuctionInventoryDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Services
{
    public class cashTransactionServiceClient
    {

        public dynamic GetAllCash()
        {

            cashTransactionRepository repo = new cashTransactionRepository();
            var listTransactions = repo.GetAllCash();
            return listTransactions;
        }

        public dynamic GetAllTransactions()
        {

            cashTransactionRepository repo = new cashTransactionRepository();
            var listTransactions = repo.GetAllTransactions();
            return listTransactions;
        }


        public dynamic GetAllTransactionsByDate(DateTime fromDate, DateTime toDate)
        {

            cashTransactionRepository repo = new cashTransactionRepository();
            var listTransactions = repo.GetAllTransactionsByDate(fromDate, toDate);
            return listTransactions;
        }

        public bool SaveEdit(CashTransactionModel cashModel)
        {
            bool status = true;
            cashTransactionRepository repo = new cashTransactionRepository();
            status = repo.SaveEdit(ParserAddAccount(cashModel));
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            cashTransactionRepository repo = new cashTransactionRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser
        private MCashTransaction ParserAddAccount(CashTransactionModel cashModel)
        {
            MCashTransaction cashEntity = new MCashTransaction();

            if (cashModel != null)
            {
                cashEntity.iCashTransactionID = cashModel.iCashTransactionID;
                cashEntity.iAccountPartyID = cashModel.iAccountPartyID;
                cashEntity.strCashDate = cashModel.strCashDate;
                cashEntity.dtCashDate = cashModel.dtCashDate;
                cashEntity.dmlPaidAmount = cashModel.dmlPaidAmount;
                cashEntity.strReferenceNumber = cashModel.strReferenceNumber;
                cashEntity.strDescription = cashModel.strDescription;
                cashEntity.DebitCreditOptions = cashModel.DebitCreditOptions;
                cashEntity.BankCashOptions = cashModel.BankCashOptions;

            }

            return cashEntity;
        }

        #endregion
    }
}