using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class PapersServiceClient
    {
        public bool SaveImportData(List<PaperDetailsImportModel> mImport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.SavePaperImport(ParserAddImports(mImport));
            return status;
        }

        public dynamic GetPartyAccountTransaction(int partyID, DateTime fromDate, DateTime toDate)
        {
            //List<Vehicles> listVehicles = new List<Vehicles>();
            PapersRepository repo = new PapersRepository();
            dynamic depositList = repo.GetPartyAccountTransaction(partyID, fromDate, toDate);
            // listVehicles = ParserGetAllVehicles(vehicle);
            return depositList;
        }

        public dynamic GetDepositListData(DateTime fromDate, DateTime toDate)
        {
            //List<Vehicles> listVehicles = new List<Vehicles>();
            PapersRepository repo = new PapersRepository();
            dynamic depositList = repo.GetDepositListData(fromDate, toDate);
            // listVehicles = ParserGetAllVehicles(vehicle);
            return depositList;
        }

        public dynamic GetCustomerDetails(string prefix)
        {
            PapersRepository repo = new PapersRepository();
            var customer = repo.GetCustomerDetails(prefix);
            return customer;

        }
        public dynamic GetAccountListData(string chassisNum)
        {
            PapersRepository repo = new PapersRepository();
            dynamic List = repo.GetAccountListData(chassisNum);
            return List;
        }
        public dynamic GetDeductionAmount(string strChassisNum)
        {
            PapersRepository repo = new PapersRepository();
            var amount = repo.GetDeductionAmount(strChassisNum);
            return amount;

        }

        #region DeleteImport
        public bool DeleteImportPaperDetails(long ID)
        {
            PapersRepository repo = new PapersRepository();
            return repo.DeleteImportPaperDetails(ID);
        }
        #endregion


        #region DeleteExport
        public bool DeleteExportPaperDetails(long ID)
        {
            PapersRepository repo = new PapersRepository();
            return repo.DeleteExportPaperDetails(ID);
        }
        #endregion
        public bool UpdateImportData(PaperDetailsImportModel mImport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.UpdatePaperImport(ParserUpdateImports(mImport));
            return status;
        }

        public bool UpdateExportData(PaperDetailsExportModel mExport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.UpdatePaperExport(ParserUpdateExports(mExport));
            return status;
        }
        public dynamic GetImportData()
        {

            PapersRepository repo = new PapersRepository();
            var importDataList = repo.GetImportData();
            return importDataList;
        }

        public dynamic GetExportData()
        {
            PapersRepository repo = new PapersRepository();
            var exportDataList = repo.GetExportData();
            return exportDataList;
        }

        public dynamic GetSalesVehicleByPapertype(int paperTypeID)
        {
            PapersRepository repo = new PapersRepository();
            var vehiclePaperByType = repo.GetSalesVehicleByPapertype(paperTypeID);
            return vehiclePaperByType;
        }

        public bool SaveExportData(List<PaperDetailsExportModel> mExport)
        {
            bool status = true;
            PapersRepository repo = new PapersRepository();
            status = repo.SavePaperExport(ParserAddExports(mExport));
            return status;
        }

        private List<PaperDetailsForImport> ParserAddImports(List<PaperDetailsImportModel> import)
        {
            List<PaperDetailsForImport> eImportList = new List<PaperDetailsForImport>();

            foreach (var data in import)
            {
                if (data != null)
                {
                    PaperDetailsForImport eImport = new PaperDetailsForImport();
                    eImport.iPaperDetailsForImportID = data.iPaperDetailsForImportID;
                    eImport.iVehicleID = data.iVehicleID;
                    eImport.iDecNo = data.iDecNo;
                    eImport.strDecDate = data.strDecDate;
                    eImport.dcmlImpDeposit = data.dcmlImpDeposit;
                    eImport.dcmlDuty = data.dcmlDuty;
                    eImport.dcmlPaper = data.dcmlPaper;
                    eImport.dcmlTotal = data.dcmlTotal;
                    eImport.dcmlImpBalance = data.dcmlImpBalance;
                    eImport.dtDate = data.dtDate;
                    eImport.strDate = data.strDate;
                    eImport.dcmlDeduction = data.dcmlDeduction;
                    eImportList.Add(eImport);
                }
            }

            return eImportList;
        }


        private PaperDetailsForImport ParserUpdateImports(PaperDetailsImportModel import)
        {
            PaperDetailsForImport eImport = new PaperDetailsForImport();

            if (import != null)
            {

                eImport.iPaperDetailsForImportID = import.iPaperDetailsForImportID;
                eImport.iVehicleID = import.iVehicleID;
                eImport.iDecNo = import.iDecNo;
                eImport.strDecDate = import.strDecDate;
                eImport.dcmlImpDeposit = import.dcmlImpDeposit;
                eImport.dcmlDuty = import.dcmlDuty;
                eImport.dcmlPaper = import.dcmlPaper;
                eImport.dcmlTotal = import.dcmlTotal;
                eImport.dcmlImpBalance = import.dcmlImpBalance;
                eImport.dtDate = import.dtDate;
                eImport.strDate = import.strDate;
                eImport.dcmlDeduction = import.dcmlDeduction;
            }

            return eImport;
        }

        private PaperDetailsForExport ParserUpdateExports(PaperDetailsExportModel export)
        {
            PaperDetailsForExport eExport = new PaperDetailsForExport();

            if (export != null)
            {
                eExport.iPaperDetailsForExportID = export.iPaperDetailsForExportID;
                eExport.iVehicleID = export.iVehicleID;
                eExport.strReceivingDate = export.strReceivingDate;
                eExport.strSubmitDate = export.strSubmitDate;
                eExport.iCustApproval = export.iCustApproval;
                eExport.dcmlDeduction = export.dcmlDeduction;
                eExport.dcmlFine = export.dcmlFine;
                eExport.dcmlMisc = export.dcmlMisc;
                eExport.dcmlExportDeposit = export.dcmlExportDeposit;
                eExport.dcmlExportBalance = export.dcmlExportBalance;
                eExport.dtDate = export.dtDate;
                eExport.strDate = export.strDate;

            }

            return eExport;
        }


        private List<PaperDetailsForExport> ParserAddExports(List<PaperDetailsExportModel> export)
        {
            List<PaperDetailsForExport> eExportList = new List<PaperDetailsForExport>();

            foreach (var data in export)
            {
                if (data != null)
                {
                    PaperDetailsForExport eExport = new PaperDetailsForExport();
                    eExport.iPaperDetailsForExportID = data.iPaperDetailsForExportID;
                    eExport.iVehicleID = data.iVehicleID;
                    eExport.strReceivingDate = data.strReceivingDate;
                    eExport.strSubmitDate = data.strSubmitDate;
                    eExport.iCustApproval = data.iCustApproval;
                    eExport.dcmlDeduction = data.dcmlDeduction;
                    eExport.dcmlFine = data.dcmlFine;
                    eExport.dcmlMisc = data.dcmlMisc;
                    eExport.dcmlExportDeposit = data.dcmlExportDeposit;
                    eExport.dcmlExportBalance = data.dcmlExportBalance;
                    eExport.dtDate = data.dtDate;
                    eExport.strDate = data.strDate;
                    eExportList.Add(eExport);
                }
            }

            return eExportList;
        }

    }
}