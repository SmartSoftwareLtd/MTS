using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventory.Services;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class AccountServiceClient
    {


        public dynamic GetAccountListData()
        {           
            AccountRepository repo = new AccountRepository();
            dynamic List = repo.GetAccountListData();
            return List;
        }

         public bool SaveEdit(AccountModel acntModel)
         {
            bool status = true;
            AccountRepository repo = new AccountRepository();
            status = repo.SaveEdit(ParserAddAccount(acntModel));
            return status;
         }

          public bool Delete(int id)
         {
             bool status = true;
             AccountRepository repo = new AccountRepository();
             status = repo.Delete(id);
             return status;
         }

        #region Parser
         private Account ParserAddAccount(AccountModel accountModel)
         {
             Account accountEntity = new Account();

             if (accountModel != null)
             {
                 accountEntity.iAccountID = accountModel.iAccountID;
                 accountEntity.strAccountPartyName=accountModel.strAccountPartyName??"";
                 accountEntity.strDebit = accountModel.strDebit;
                 accountEntity.strCredit = accountModel.strCredit;
                 accountEntity.strAccountDate = accountModel.strAccountDate ?? "";
                 accountEntity.dtAccountDate = accountModel.dtAccountDate;
                 accountEntity.strAmountInDHM = accountModel.strAmountInDHM ?? "";
                 accountEntity.strAmountInYEN = accountModel.strAmountInYEN ?? "";
                 accountEntity.strDescription = accountModel.strDescription ?? "";
                 accountEntity.strConvRate = accountModel.strConvRate ?? "";

                 accountEntity.DebitCreditOptions = accountModel.DebitCreditOptions;

                    accountEntity.iAccountPartyID = accountModel.iAccountPartyID;
                    accountEntity.strChassisNum = accountModel.strChassisNum;
                    accountEntity.strReferenceNumber = accountModel.strReferenceNumber;

             }

             return accountEntity;
         }

        #endregion
    }
}