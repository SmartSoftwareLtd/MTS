using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class DeliveryOrderModel
    {
        public long iDeliveryOrderID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public string strCustomerName { get; set; }
        public string strCurrentDate { get; set; }
        public Nullable<System.DateTime> dtCurrentDate { get; set; }
        public string strExpiryDate { get; set; }
        public Nullable<System.DateTime> dtExpiryDate { get; set; }
        public string strCarDeliveryDate { get; set; }
        public Nullable<System.DateTime> dtCarDeliveryDate { get; set; }
        public Nullable<bool> ysnDeliveryStatus { get; set; }
    }
}