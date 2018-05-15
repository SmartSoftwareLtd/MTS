using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class PaperDetailsImportModel
    {
        public long iPaperDetailsForImportID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public string iDecNo { get; set; }
        public string strDecDate { get; set; }
        public Nullable<decimal> dcmlImpDeposit { get; set; }
        public Nullable<decimal> dcmlDuty { get; set; }
        public Nullable<decimal> dcmlPaper { get; set; }
        public Nullable<decimal> dcmlTotal { get; set; }
        public Nullable<decimal> dcmlImpBalance { get; set; }
        public string strDate { get; set; }
        public Nullable<System.DateTime> dtDate { get; set; }
        public Nullable<decimal> dcmlDeduction { get; set; }
    }
}