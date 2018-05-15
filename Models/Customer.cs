using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionInventory.Models
{
    public class Customer
    {
        public int iCustomerID { get; set; }
        public string strFirstName { get; set; }
        public string strMiddleName { get; set; }
        public string strLastName { get; set; }
        public Nullable<int> iCountry { get; set; }
        public Nullable<int> iCity { get; set; }
        public string strEmailID { get; set; }
        public string strAddress { get; set; }
        public Nullable<decimal> strCreditLimit { get; set; }
        public string strPersonFirstName { get; set; }
        public string strPersonMiddleName { get; set; }
        public string strPersonLastName { get; set; }
        public string CustomerPhoto { get; set; }
        public string CustomerDate { get; set; }
        public Nullable<long> iCreditCategoryID { get; set; }
        public string strPincode { get; set; }
        public Nullable<double> fltPhoneNumber { get; set; }
        public Nullable<bool> IsBlocked { get; set; }
        public string strQRCode { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string strQRCodePath { get; set; }
        public Nullable<int> iCutomerTypeID { get; set; }
        public string strShowRoomName { get; set; }
        public string strShowRoomNumber { get; set; }
        public string strBlock { get; set; }
        public string strShowRoomPhoneNo { get; set; }
        public string strPersonPhoneNo { get; set; }
        public Nullable<double> fltPassportNo { get; set; }
        public string strPcCode { get; set; }
        public string strExpiryDate { get; set; }
        public Nullable<System.DateTime> dtExpiryDate { get; set; }
        public string IDCopy { get; set; }
        public string IDCopyName { get; set; }
        public string VisaCopy { get; set; }
        public string VisaCopyName { get; set; }
    }
}