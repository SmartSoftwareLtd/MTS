using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class AccountModel
    {
        public long iAccountID { get; set; }
        public string strAccountPartyName { get; set; }
        public Nullable<decimal> strDebit { get; set; }
        public Nullable<decimal> strCredit { get; set; }
        public Nullable<System.DateTime> dtAccountDate { get; set; }
        public string strAccountDate { get; set; }
        public string strAmountInDHM { get; set; }
        public string strAmountInYEN { get; set; }
        public string strDescription { get; set; }
        public string strConvRate { get; set; } 
        public Nullable<int> DebitCreditOptions { get; set; }
        public Nullable<int> iAccountPartyID { get; set; }
        public string strChassisNum { get; set; }
        public string strReferenceNumber { get; set; }
    }
}