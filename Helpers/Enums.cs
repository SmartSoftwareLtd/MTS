using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionInventory.Helpers
{
    public class Enums
    {

        public enum Roles
        {
            SuperAdmin = 1,
            AdminSupplier = 2,
            Accountant = 3,
            DataEntry = 4,
            XYZRole = 5
        }

        public enum VehicleExpenseType
        {
            AllVehicleExpense = 1,
            SingleVehicleExpense = 2
        }


        public enum Creditcategory
        {
            A = 10,
            B = 15,
            C = 20
        }

        public enum ModuleName
        {
            MSupplier = 1,
            HomeController = 2,
            AuctionController = 3,
            LoginController = 4,
            MPartyController = 17,
            MCategoryController = 5,
            MColorController = 6,
            MCompanyController = 7,
            MCurrencyController = 8,
            MCustomerController = 9,
            MExpensesController = 10,
            MStaffController = 11,
            MVehicleController = 12,
            PapersController = 13,
            SalesController = 14,
            TPurchaseController = 15,
            UserAuthorizationController = 16,
            AccountPartyController = 18,
            DamageVehicleController = 19,
            IncomeAndExpenditureController = 20,
            MCreditCategoryController = 21,
            MYardController = 22,
            ReportsController = 23,
            VehicleStatusController = 24,
            DOController=26,
            MCashTransactionController=27,
            
        }
    }
}