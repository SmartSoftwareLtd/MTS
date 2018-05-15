using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class MYardModel
    {
        public long iYardID { get; set; }
        public string strYardName { get; set; }
        public Nullable<int> iYardLimit { get; set; }
    }
}