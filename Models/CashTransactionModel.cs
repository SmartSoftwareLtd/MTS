using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class CashTransactionModel
    {
        public long iCashTransactionID { get; set; }
        public string strCashDate { get; set; }
        public Nullable<long> iAccountPartyID { get; set; }
        public Nullable<System.DateTime> dtCashDate { get; set; }
        public Nullable<decimal> dmlPaidAmount { get; set; }
        public string strDescription { get; set; }
        public Nullable<int> DebitCreditOptions { get; set; }
        public Nullable<int> BankCashOptions { get; set; }
        public string strReferenceNumber { get; set; }
    }
}