using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class GeneralExpenses
    {
        public long iGeneralExpensesID { get; set; }
        public string strExpenseNumber { get; set; }
        public string strExpenseDate { get; set; }
        public Nullable<int> iExpenseID { get; set; }
        public Nullable<decimal> dcmlExpenseAmount { get; set; }
        public string strRemarks { get; set; }
        public Nullable<int> iPartyID { get; set; }
        public Nullable<int> iExpenseNumber { get; set; }
        public Nullable<System.DateTime> dtExpenseDate { get; set; }
        public string strReferenceNumber { get; set; }
    }
}