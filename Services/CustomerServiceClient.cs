using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class CustomerServiceClient
    {

        public dynamic GetAllCustomers()
        {
           
            CustomersRepository repo = new CustomersRepository();           
           var listCustomers = repo.GetAll();
            return listCustomers;
        }

        public dynamic GetAllShowRoomCustomers()
        {
           
            CustomersRepository repo = new CustomersRepository();
            var listCustomers = repo.GetAllShowRoomCustomers();
            return listCustomers;
        }
        public bool SaveData(Customer customer, HttpPostedFileBase fileIDCopy,HttpPostedFileBase fileVisaCopy)
        {
            bool status = true;
            Customer cust = new Customer();
            CustomersRepository repo = new CustomersRepository();
            status = repo.SaveEdit(ParserAddCustomer(customer), fileIDCopy, fileVisaCopy);
            return status;
        }

        public Customer GetCustomer(int id)
        {

            Customer customer = new Customer();
            CustomersRepository repo = new CustomersRepository();
            if (customer != null)
            {
                customer = ParserCustomer(repo.Get(id));
            }
            return customer;

        }

        public bool Delete(int id)
        {
            bool status = false;
            CustomersRepository repo = new CustomersRepository();
            status = repo.Delete(id);
            return status;
        }

        //FOR ALL SHOWROOM CUSTOMERS
        public dynamic GetAllSRCustomers()
        {

            CustomersRepository repo = new CustomersRepository();
            var listCustomers = repo.GetAllSRCustomers();
            return listCustomers;
        }

        #region Customer Account
        public dynamic GetShowRoomCustomerAccount(string prefix)
        {
            CustomersRepository repo = new CustomersRepository();
            var customer = repo.GetShowRoomCustomerAccount(prefix);
            return customer;

        }


        public dynamic GetDirectCustomerAccount(string prefix)
        {
            CustomersRepository repo = new CustomersRepository();
            var customer = repo.GetDirectCustomerAccount(prefix);
            return customer;

        }

        public dynamic GetCustomerVehicles(int id)
        {
            CustomersRepository repo = new CustomersRepository();
            var vehicles = repo.GetCustomerVehicles(id);
            return vehicles;

        }
        #endregion



        #region Parser

        private MCustomer ParserAddCustomer(Customer customer)
        {
            MCustomer mCustomer = new MCustomer();

            if (customer != null)
            {
                mCustomer.iCustomerID = customer.iCustomerID;
                mCustomer.strFirstName = customer.strFirstName ?? " ";
                mCustomer.strMiddleName = customer.strMiddleName ?? " ";
                mCustomer.strLastName = customer.strLastName ?? " ";
                mCustomer.iCountry = customer.iCountry;
                mCustomer.iCity = customer.iCity ;
                mCustomer.strEmailID = customer.strEmailID ?? " ";
                mCustomer.fltPhoneNumber = customer.fltPhoneNumber;
                mCustomer.strAddress = customer.strAddress ?? " ";
                mCustomer.strPincode = customer.strPincode;
                mCustomer.strCreditLimit = customer.strCreditLimit;
              
                mCustomer.strPersonFirstName = customer.strPersonFirstName ?? " ";
                mCustomer.strPersonMiddleName = customer.strPersonMiddleName ?? " ";
                mCustomer.strPersonLastName = customer.strPersonLastName ?? " ";
                mCustomer.strPersonPhoneNo = customer.strPersonPhoneNo ?? " ";
          
                mCustomer.strShowRoomName = customer.strShowRoomName ?? " ";
                mCustomer.strShowRoomNumber = customer.strShowRoomNumber ?? " ";
                mCustomer.strBlock = customer.strBlock ?? " ";
                mCustomer.strShowRoomPhoneNo = customer.strShowRoomPhoneNo ?? " ";


                mCustomer.CustomerPhoto = customer.CustomerPhoto ?? " ";
                mCustomer.CustomerDate = customer.CustomerDate ?? " ";
                mCustomer.iCreditCategoryID = customer.iCreditCategoryID;

                mCustomer.IsBlocked = customer.IsBlocked;
                mCustomer.strQRCode = customer.strQRCode;
                mCustomer.IsActive = customer.IsActive;
                mCustomer.strQRCodePath = customer.strQRCodePath;
                mCustomer.iCutomerTypeID = customer.iCutomerTypeID;

                mCustomer.dtExpiryDate = customer.dtExpiryDate;
                mCustomer.strExpiryDate = customer.strExpiryDate ?? " ";
                mCustomer.strPcCode = customer.strPcCode ?? " ";
                mCustomer.fltPassportNo = customer.fltPassportNo;

                mCustomer.IDCopy = customer.IDCopy;
                mCustomer.IDCopyName = customer.IDCopyName;
                mCustomer.VisaCopy = customer.VisaCopy;
                mCustomer.VisaCopyName = customer.VisaCopyName;
            }
            return mCustomer;
        }

        private List<Customer> ParserGetAllCustomers(dynamic responseData)
        {
            List<Customer> listCustomer = new List<Customer>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Customer customer = new Customer();
                    customer.iCustomerID = data.iCustomerID;
                    customer.strFirstName = data.strFirstName ?? " ";
                    customer.strMiddleName = data.strMiddleName ?? " ";
                    customer.strLastName = data.strLastName ?? " ";
                    customer.iCountry = data.iCountry;
                    customer.iCity = data.iCity;
                    customer.strEmailID = data.strEmailID ?? " ";
                    customer.fltPhoneNumber = data.fltPhoneNumber;
                    customer.strAddress = data.strAddress ?? " ";
                    customer.strPincode = data.strPincode;
                    customer.strCreditLimit = data.strCreditLimit;
                 
                    customer.strPersonFirstName = data.strPersonFirstName ?? " ";
                    customer.strPersonMiddleName = data.strPersonMiddleName ?? " ";
                    customer.strPersonLastName = data.strPersonLastName ?? " ";
                    customer.strPersonPhoneNo = data.strPersonPhoneNo ?? " ";

                    customer.strShowRoomName = data.strShowRoomName ?? " ";
                    customer.strShowRoomNumber = data.strShowRoomNumber ?? " ";
                    customer.strBlock = data.strBlock ?? " ";
                    customer.strShowRoomPhoneNo = data.strShowRoomPhoneNo ?? " ";
                 
                    customer.CustomerPhoto = data.CustomerPhoto ?? " ";
                    customer.CustomerDate = data.CustomerDate ?? " ";

                    customer.dtExpiryDate = data.dtExpiryDate;
                    customer.strExpiryDate = data.strExpiryDate ?? " ";
                    customer.strPcCode = data.strPcCode ?? " ";
                    customer.fltPassportNo = data.fltPassportNo;
                    customer.IDCopy = data.IDCopy;
                    customer.IDCopyName = data.IDCopyName;
                    customer.VisaCopy = data.VisaCopy;
                    customer.VisaCopyName = data.VisaCopyName;

                    listCustomer.Add(customer);
                }
            }
            return listCustomer;
        }


        private Customer ParserCustomer(dynamic data)
        {
            Customer customer = new Customer();

            if (data != null)
            {
                customer.iCustomerID = data.iCustomerID;
                customer.strFirstName = data.strFirstName ?? " ";
                customer.strMiddleName = data.strMiddleName ?? " ";
                customer.strLastName = data.strLastName ?? " ";
                customer.iCountry = data.iCountry;
                customer.iCity = data.iCity;
                customer.strEmailID = data.strEmailID ?? " ";
                customer.fltPhoneNumber = data.fltPhoneNumber;
                customer.strAddress = data.strAddress ?? " ";
                customer.strPincode = data.strPincode;
                customer.strCreditLimit = data.strCreditLimit;
            
                customer.strPersonFirstName = data.strPersonFirstName ?? " ";
                customer.strPersonMiddleName = data.strPersonMiddleName ?? " ";
                customer.strPersonLastName = data.strPersonLastName ?? " ";
                customer.strPersonPhoneNo = data.strPersonPhoneNo ?? " ";

                customer.strShowRoomName = data.strShowRoomName ?? " ";
                customer.strShowRoomNumber = data.strShowRoomNumber ?? " ";
                customer.strBlock = data.strBlock ?? " ";
                customer.strShowRoomPhoneNo = data.strShowRoomPhoneNo ?? " ";

                customer.CustomerPhoto = data.CustomerPhoto ?? " ";
                customer.CustomerDate = data.CustomerDate ?? " ";

                customer.iCreditCategoryID = data.iCreditCategoryID;
                customer.IsBlocked = data.IsBlocked;
                customer.strQRCode = data.strQRCode;
                customer.IsActive = data.IsActive;

                customer.strQRCodePath = data.strQRCodePath;
                customer.iCutomerTypeID = data.iCutomerTypeID;

                customer.dtExpiryDate = data.dtExpiryDate;
                customer.strExpiryDate = data.strExpiryDate ?? " ";
                customer.strPcCode = data.strPcCode ?? " ";
                customer.fltPassportNo = data.fltPassportNo;

                customer.IDCopy = data.IDCopy;
                customer.IDCopyName = data.IDCopyName;
                customer.VisaCopy = data.VisaCopy;
                customer.VisaCopyName = data.VisaCopyName;
            }
            return customer;
        }

        #endregion
    }
}