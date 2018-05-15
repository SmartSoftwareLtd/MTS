using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;
using AuctionInventory.Helpers;

namespace AuctionInventory.Services
{
    public class ExpensesServiceClient
    {
        //public List<Expenses> GetAllExpenses()
        //{
        //    List<Expenses> listExpenses = new List<Expenses>();
        //    ExpensesRepository repo = new ExpensesRepository();
        //    dynamic expenses = repo.GetAll();
        //    listExpenses = ParserGetAllExpenses(expenses);
        //    return listExpenses;
        //}


        public dynamic ViewRowDataOfAllVehicleExpense(int id)
        {
            dynamic vehicleList = 0;
            ExpensesRepository repo = new ExpensesRepository();

            vehicleList = repo.ViewRowDataOfAllVehicleExpense(id);
            return vehicleList;

        }

        public dynamic GetAllExpenses()
        {

            ExpensesRepository repo = new ExpensesRepository();
            var expenses = repo.GetAll();
            return expenses;
        }
        public bool SaveData(Expenses expenses)
        {
            bool status = true;
            Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.SaveEdit(ParserAddExpenses(expenses));
            return status;
        }


        public dynamic GetAllVehicleExpensesByInvoiceID(int id)
        {
           
            ExpensesRepository repo = new ExpensesRepository();
            dynamic allVehicleExpenses = repo.GetAllVehicleExpensesByInvoiceID(id);
           
            return allVehicleExpenses;
        }

        public dynamic GetAllVehicleExpensesListData()
        {
           
            ExpensesRepository repo = new ExpensesRepository();
            dynamic allVehicleExpenses = repo.GetAllVehicleExpensesListData();
           
            return allVehicleExpenses;
        }


        public dynamic GetSingleVehicleExpensesListData()
        {

            ExpensesRepository repo = new ExpensesRepository();
            dynamic singleVehicleExpenses = repo.GetSingleVehicleExpensesListData();

            return singleVehicleExpenses;
        }


        public dynamic GetExpenseByVehicleID(int id)
        {           
            ExpensesRepository repo = new ExpensesRepository();
            var listExpense = repo.GetExpenseByVehicleID(id);
            return listExpense;
        }

        public dynamic GetExpenseByInvoiceID(int id)
        {           
            ExpensesRepository repo = new ExpensesRepository();
            var listExpenses = repo.GetExpenseByInvoiceID(id);
            return listExpenses;
        }
        public dynamic VehiclesByBLNO(string id)
        {           
            ExpensesRepository repo = new ExpensesRepository();
            var listPurchase = repo.VehiclesByBLNO(id);
            return listPurchase;
        }

        public dynamic ExpenseFilterByDate(DateTime fromDate, DateTime toDate)
        {           
            ExpensesRepository repo = new ExpensesRepository();
            var listExpenses = repo.ExpenseFilterByDate(fromDate, toDate);
            return listExpenses;
        }
        
        public dynamic AutoCompleteExpense(string prefix)
        {           
            ExpensesRepository repo = new ExpensesRepository();
            var expenses = repo.AutoCompleteExpense(prefix);
            return expenses;
        }
        
        public dynamic VehiclesByVehicleID(int id)
        {           
            ExpensesRepository repo = new ExpensesRepository();
            var VehiclesList = repo.VehiclesByVehicleID(id);
            return VehiclesList;
        }

        public dynamic AutoCompleteVehicles(string prefix)
        {           
            ExpensesRepository repo = new ExpensesRepository();
            var vehicles = repo.AutoCompleteVehicles(prefix);
            return vehicles;
        }

        public Expenses GetExpenses(int id)
        {

            Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            if (expense != null)
            {
                expense = ParserExpenses(repo.Get(id));
            }
            return expense;

        }

        public bool Delete(int id)
        {
            bool status = false;
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.Delete(id);
            return status;
        }



        public bool SaveDataVehicleExpense(List<VehicleExpenseModel> expenses, int id)
        {
            AuctionInventoryEntities auctionContext=new AuctionInventoryEntities();
            bool status = true;
            //Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();

            string refenceNumber = CommonMethods.GetRefenceNumber(ShortCode.ExpenseKey, "1");
            status = repo.SaveRepoVehicleExpense(ParserAddVehicleExpenses(expenses), refenceNumber, id);
            return status;
        }


        public bool SpreadExpenseAmount(decimal totalAmount, int purchaseInvoiceID)
        {
            bool status = true;
            //Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.SpreadExpenseAmount(totalAmount, purchaseInvoiceID);
            return status;
        }



        public bool UndoSpreadExpenseAmount(int purchaseInvoiceID, decimal spreadAmount)
        {
            bool status = true;
            //Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.UndoSpreadExpenseAmount(purchaseInvoiceID, spreadAmount);
            return status;
        }

        #region Lots
        public dynamic GetAllLots()
        {

            ExpensesRepository repo = new ExpensesRepository();
            var listLot = repo.GetAllLots();
            return listLot;
        }

        public bool SaveExpenseLot(Lots lot)
        {
            bool status = true;

            ExpensesRepository repo = new ExpensesRepository();
            status = repo.expenseLotSaveEdit(ParserAddExpenseLot(lot));
            return status;
        }

        public Lots GetLots(int id)
        {

            Lots lots = new Lots();
            ExpensesRepository repo = new ExpensesRepository();
            if (lots != null)
            {
                lots = ParserGetExpenseLot(repo.GetLot(id));
            }
            return lots;

        }
        public bool DeleteExpenseLot(int id)
        {
            bool status = false;
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.DeleteExpenseLot(id);
            return status;
        }
        private MLot ParserAddExpenseLot(Lots lot)
        {
            MLot mlot = new MLot();

            if (mlot != null)
            {
                mlot.iLotID = lot.iLotID;
                mlot.strLotName = lot.strLotName ?? " ";
                mlot.strFromDate = lot.strFromDate ?? " ";
                mlot.dtFromDate = lot.dtFromDate;
                mlot.strToDate = lot.strToDate;
                mlot.dtToDate = lot.dtToDate;
                mlot.chLotType = lot.chLotType ?? " ";

            }
            return mlot;
        }

        private Lots ParserGetExpenseLot(dynamic data)
        {
            Lots lot = new Lots();

            if (data != null)
            {

                lot.iLotID = data.iLotID;
                lot.strLotName = data.strLotName ?? " ";
                lot.strFromDate = data.strFromDate ?? " ";
                lot.dtFromDate = data.dtFromDate ?? " ";
                lot.strToDate = data.strToDate;
                lot.dtToDate = data.dtToDate;
                lot.chLotType = data.chLotType ?? " ";

            }
            return lot;
        }
        #endregion


        #region generalExpense
        public dynamic AutoCompleteGeneralExpense(string prefix)
        {
            ExpensesRepository repo = new ExpensesRepository();
            var expenses = repo.AutoCompleteGeneralExpense(prefix);
            return expenses;
        }

        public GeneralExpenses GetGeneralExpense(int id)
        {

            GeneralExpenses generalExpense = new GeneralExpenses();
            ExpensesRepository repo = new ExpensesRepository();
            if (generalExpense != null)
            {
                generalExpense = ParserGetGeneralExpenses(repo.GetGeneralExpense(id));
            }
            return generalExpense;

        }

        public string saveGeneralExpense(GeneralExpenses genexpense)
        {
            AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();
            //bool status = true;
            string savedBillNum = string.Empty;
            //Expenses expense = new Expenses();
            ExpensesRepository repo = new ExpensesRepository();


            savedBillNum = repo.GeneralExpenseSaveEdit(ParserAddGeneralExpenses(genexpense));
            return savedBillNum;
        }


        private GeneralExpens ParserAddGeneralExpenses(GeneralExpenses expenses)
        {
            GeneralExpens mGenExpense = new GeneralExpens();

            if (expenses != null)
            {

                mGenExpense.iGeneralExpensesID = expenses.iGeneralExpensesID;
                mGenExpense.strExpenseNumber = expenses.strExpenseNumber;
                mGenExpense.iExpenseID = expenses.iExpenseID;
                mGenExpense.strExpenseDate = expenses.strExpenseDate;
                mGenExpense.dcmlExpenseAmount = expenses.dcmlExpenseAmount;
                mGenExpense.strRemarks = expenses.strRemarks;
                mGenExpense.iPartyID = expenses.iPartyID;
                mGenExpense.iExpenseNumber = expenses.iExpenseNumber;
                mGenExpense.dtExpenseDate = expenses.dtExpenseDate;
                mGenExpense.strReferenceNumber = expenses.strReferenceNumber;



            }

            return mGenExpense;
        }

        public dynamic GetAllGeneralExpenses()
        {

            ExpensesRepository repo = new ExpensesRepository();
            var expenses = repo.GetAllGeneralExpenses();
            return expenses;
        }



        private GeneralExpenses ParserGetGeneralExpenses(dynamic data)
        {
            GeneralExpenses generalExpenses = new GeneralExpenses();

            if (data != null)
            {
                generalExpenses.iGeneralExpensesID = data.iGeneralExpensesID;
                generalExpenses.strExpenseNumber = data.strExpenseNumber;
                generalExpenses.iExpenseID = data.iExpenseID;
                generalExpenses.strExpenseDate = data.strExpenseDate;
                generalExpenses.dcmlExpenseAmount = data.dcmlExpenseAmount;
                generalExpenses.strRemarks = data.strRemarks;
                generalExpenses.iPartyID = data.iPartyID;
                generalExpenses.iExpenseNumber = data.iExpenseNumber;



            }
            return generalExpenses;
        }

        public bool DeleteGeneralExpense(int id)
        {
            bool status = false;
            ExpensesRepository repo = new ExpensesRepository();
            status = repo.DeleteGeneralExpense(id);
            return status;
        }

        #endregion



        #region DeleteVehicleExpenses
        public bool DeleteVehicleExpense(int ID)
        {
            ExpensesRepository repo = new ExpensesRepository();
            return repo.DeleteVehicleExpense(ID);
        }
        #endregion

        #region Parser

        private MExpense ParserAddExpenses(Expenses expenses)
        {
            MExpense expense = new MExpense();

            if (expenses != null)
            {
                expense.iExpenseID = expenses.iExpenseID;
                expense.strExpenseName = expenses.strExpenseName ?? " ";
                expense.iPurchaseInvoiceID = expenses.iPurchaseInvoiceID;
                expense.iCategoryID = expenses.iCategoryID;
                expense.iSubCategoryID = expenses.iSubCategoryID;
                expense.dcmlExpenseAmount = expenses.dcmlExpenseAmount;
            }
            return expense;
        }

        private Expenses ParserExpenses(dynamic data)
        {
            Expenses expenses = new Expenses();

            if (data != null)
            {
                expenses.iExpenseID = data.iExpenseID ?? -1;
                expenses.strExpenseName = data.strExpenseName ?? " ";
                expenses.iPurchaseInvoiceID = data.iPurchaseInvoiceID ?? -1;

                expenses.iCategoryID = data.iCategoryID ?? -1;
                expenses.iSubCategoryID = data.iSubCategoryID ?? -1;
                expenses.dcmlExpenseAmount = data.dcmlExpenseAmount ?? -1;
            }
            return expenses;
        }
        private List<Expenses> ParserGetAllExpenses(dynamic responseData)
        {
            List<Expenses> listExpenses = new List<Expenses>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Expenses expenses = new Expenses();
                    // supplier.FullName = data.FullName;
                    expenses.iExpenseID = data.iExpenseID ?? -1;
                    expenses.strExpenseName = data.strExpenseName ?? " ";
                    expenses.iPurchaseInvoiceID = data.iPurchaseInvoiceID ?? -1;
                    expenses.iCategoryID = data.iCategoryID ?? -1;
                    expenses.iSubCategoryID = data.iSubCategoryID ?? -1;
                    expenses.dcmlExpenseAmount = data.dcmlExpenseAmount ?? -1;
                    listExpenses.Add(expenses);
                }
            }
            return listExpenses;
        }

        private List<VehicleExpens> ParserAddVehicleExpenses(List<VehicleExpenseModel> expenses)
        {
            List<VehicleExpens> listAllVehicleExpense = new List<VehicleExpens>();
            foreach (var item in expenses)
            {


                if (item != null)
                {
                    VehicleExpens mVehicleExpense = new VehicleExpens();

                    

                    mVehicleExpense.iPurchaseInvoiceID = item.iPurchaseInvoiceID;

                    mVehicleExpense.iVehicleID = item.iVehicleID;

                    mVehicleExpense.strExpenseDate = item.strExpenseDate;

                    mVehicleExpense.iVehicleExpenseID = item.iVehicleExpenseID;

                    mVehicleExpense.strPurchaseInvoiceNo = item.strPurchaseInvoiceNo;

                    mVehicleExpense.iExpenseID = item.iExpenseID;
                    mVehicleExpense.dcmlExpenseAmount = item.dcmlExpenseAmount;
                    mVehicleExpense.dcmlTotalExpenseAmount = item.dcmlTotalExpenseAmount;

                    mVehicleExpense.iVehicleExpenseTypeID = item.iVehicleExpenseTypeID;
                    mVehicleExpense.dcmlSpreadAmount = item.dcmlSpreadAmount;
                    mVehicleExpense.isSpread = item.isSpread;

                    mVehicleExpense.strRemarks = item.strRemarks ?? " ";

                    mVehicleExpense.dcmlDOExpenseAmount = item.dcmlDOExpenseAmount;
                    mVehicleExpense.dcmlDPAExpenseAmount = item.dcmlDPAExpenseAmount;
                    mVehicleExpense.dcmlTrailerShipment = item.dcmlTrailerShipment;
                    mVehicleExpense.dcmlComission = item.dcmlComission;
                    mVehicleExpense.dcmlTawakal = item.dcmlTawakal;


                    mVehicleExpense.dcmlDemurrageCharges = item.dcmlDemurrageCharges;
                    mVehicleExpense.dcmlContainerInspection = item.dcmlContainerInspection;
                    mVehicleExpense.dcmlServicesCharges = item.dcmlServicesCharges;

                    mVehicleExpense.strReferenceNumber = item.strReferenceNumber;

                    mVehicleExpense.iPartyID = item.iPartyID;
                    mVehicleExpense.dtExpenseDate = item.dtExpenseDate;
                    listAllVehicleExpense.Add(mVehicleExpense);


                }
            }
            return listAllVehicleExpense;
        }

        //private VehicleExpens ParserAddSingleVehicleExpenses(VehicleExpenseModel expenses)
        //{
        //    VehicleExpens expense = new VehicleExpens();

        //    if (expenses != null)
        //    {
               
        //        expense.iVehicleID = expenses.iVehicleID;
        //        expense.iExpenseID = expenses.iExpenseID;
        //        expense.dcmlExpenseAmount = expenses.dcmlExpenseAmount;
        //        expense.dcmlTotalExpenseAmount = expenses.dcmlTotalExpenseAmount;
        //        expense.strRemarks = expenses.strRemarks ?? " ";
                
        //    }
        //    return expense;
        //}

        #endregion
    }
}