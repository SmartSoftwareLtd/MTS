using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class VehicleExpenseModel
    {
        public long iVehicleExpenseID { get; set; }
        public Nullable<int> iPurchaseInvoiceID { get; set; }
        public string strExpenseDate { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public Nullable<int> iExpenseID { get; set; }
        public Nullable<decimal> dcmlExpenseAmount { get; set; }
        public Nullable<decimal> dcmlTotalExpenseAmount { get; set; }
        public string strRemarks { get; set; }
        public string strExpenseKey { get; set; }
        public Nullable<int> iVehicleExpenseTypeID { get; set; }
        public Nullable<decimal> dcmlSpreadAmount { get; set; }
        public Nullable<bool> isSpread { get; set; }
        public string strPurchaseInvoiceNo { get; set; }
        public Nullable<decimal> dcmlDOExpenseAmount { get; set; }
        public Nullable<decimal> dcmlDPAExpenseAmount { get; set; }
        public Nullable<decimal> dcmlComission { get; set; }
        public Nullable<decimal> dcmlTrailerShipment { get; set; }
        public Nullable<decimal> dcmlTawakal { get; set; }
        public Nullable<decimal> dcmlDemurrageCharges { get; set; }
        public Nullable<decimal> dcmlContainerInspection { get; set; }
        public Nullable<decimal> dcmlServicesCharges { get; set; }
        public Nullable<int> iPartyID { get; set; }
        public Nullable<System.DateTime> dtExpenseDate { get; set; }
        public string strReferenceNumber { get; set; }
    }
}