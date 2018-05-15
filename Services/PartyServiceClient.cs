using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class PartyServiceClient
    {



        public dynamic GetAllParties()
        {

            PartyRepository repo = new PartyRepository();
            var listParties = repo.GetAllParties();
            return listParties;
        }
        public bool SaveData(PartyModel party)
        {
            bool status = true;

            PartyRepository repo = new PartyRepository();
            status = repo.SaveEdit(ParserAddParty(party));
            return status;
        }

        public PartyModel GetParty(int id)
        {

            PartyModel party = new PartyModel();
            PartyRepository repo = new PartyRepository();
            if (party != null)
            {
                party = ParserParty(repo.GetParty(id));
            }
            return party;

        }

        public bool Delete(int id)
        {
            bool status = false;
            PartyRepository repo = new PartyRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private MParty ParserAddParty(PartyModel party)
        {
            MParty mParty = new MParty();

            if (party != null)
            {
                mParty.iPartyID = party.iPartyID;
                mParty.strFirstName = party.strFirstName ?? " ";
                mParty.strMiddleName = party.strMiddleName ?? " ";
                mParty.strLastName = party.strLastName ?? " ";
                mParty.iCountry = party.iCountry;
                mParty.iCity = party.iCity ;
                mParty.strEmailID = party.strEmailID ?? " ";
                mParty.strPhoneNumber = party.strPhoneNumber;
                mParty.strAddress = party.strAddress ?? " ";
                mParty.iPincode = party.iPincode;
                
            }
            return mParty;
        }

        private List<PartyModel> ParserGetAllParty(dynamic responseData)
        {
            List<PartyModel> listParty = new List<PartyModel>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    PartyModel party = new PartyModel();
                    party.iPartyID = data.iPartyID;
                    party.strFirstName = data.strFirstName ?? " ";
                    party.strMiddleName = data.strMiddleName ?? " ";
                    party.strLastName = data.strLastName ?? " ";
                    party.iCountry = data.iCountry;
                    party.iCity = data.iCity;
                    party.strEmailID = data.strEmailID ?? " ";
                    party.strPhoneNumber = data.strPhoneNumber;
                    party.strAddress = data.strAddress ?? " ";
                    party.iPincode = data.iPincode;
                   
                    listParty.Add(party);
                }
            }
            return listParty;
        }


        private PartyModel ParserParty(dynamic data)
        {
            PartyModel party = new PartyModel();

            if (data != null)
            {
                party.iPartyID = data.iPartyID;
                party.strFirstName = data.strFirstName ?? " ";
                party.strMiddleName = data.strMiddleName ?? " ";
                party.strLastName = data.strLastName ?? " ";
                party.iCountry = data.iCountry;
                party.iCity = data.iCity;
                party.strEmailID = data.strEmailID ?? " ";
                party.strPhoneNumber = data.strPhoneNumber;
                party.strAddress = data.strAddress ?? " ";
                party.iPincode = data.iPincode;
               
            }
            return party;
        }

        #endregion
    }
}