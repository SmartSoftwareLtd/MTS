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
    public class AccountPartyServiceClient
    {
        public dynamic GetAccountListData()
        {
            AccountPartyRepository repo = new AccountPartyRepository();
            dynamic List = repo.GetAccountListData();
            return List;
        }

        public bool SaveEdit(AccountPartyModel acntModel)
        {
            bool status = true;
            AccountPartyRepository repo = new AccountPartyRepository();
            status = repo.SaveEdit(ParserAddAccount(acntModel));
            return status;
        }

        public bool Delete(int id)
        {
            bool status = true;
            AccountPartyRepository repo = new AccountPartyRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser
        private AccountParty ParserAddAccount(AccountPartyModel accountModel)
        {
            AccountParty accountEntity = new AccountParty();

            if (accountModel != null)
            {
                accountEntity.iAccountPartyID = accountModel.iAccountPartyID;
                accountEntity.strPartyName = accountModel.strPartyName ?? "";
               
            }

            return accountEntity;
        }

        #endregion
    }
}