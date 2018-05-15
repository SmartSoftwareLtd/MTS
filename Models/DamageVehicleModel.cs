using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class DamageVehicleModel
    {
        public long iDamageVehicleID { get; set; }
        public Nullable<int> iVehicleID { get; set; }
        public Nullable<int> iYardID { get; set; }
        public string strArrivalDate { get; set; }
        public Nullable<System.DateTime> dtArrivalDate { get; set; }
        public string strRepairingDate { get; set; }
        public Nullable<System.DateTime> dtRepairingDate { get; set; }
        public Nullable<bool> repairingStatus { get; set; }
    }
}