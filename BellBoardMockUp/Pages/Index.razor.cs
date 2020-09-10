using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BellBoardMockUp.Models;
using BellBoardMockUp.Shared;

namespace BellBoardMockUp.Pages
{
    public partial class Index
    {
        public Index()
        {
            Performance = new Performance()
            {
                BellsPerRinger = "1",
                Style = "1",
                AssociationDropDown = "Please select",
                Distributed = false,
                AdditionalRingerInfo = false,
                Ringers = new List<RingerResponse>()
            };

            PopulateRingers();
        }

        public Performance Performance { get; set; }

        private Modal Modal { get; set; }

        public int PopUpNum { get; set; }

        protected void BellsPerRingerChanged(string value)
        {
            Performance.BellsPerRinger = value;

            if (Performance.BellsPerRinger == "1")
            {
                Performance.Style = "1";
            }
            else if (Performance.BellsPerRinger == "2")
            {
                Performance.Style = "2";
            }

            PopulateRingers();
        }

        protected void StyleChanged(string value)
        {
            Performance.Style = value;

            if (Performance.Style == "3")
            {
                Performance.Distributed = true;
            }
        }

        protected void AssociationDropDownChanged(string value)
        {
            Performance.AssociationDropDown = value;
        }

        protected void DistributedChanged(bool value)
        {
            Performance.Distributed = value;
        }

        protected void AdditionalRingerInfoChanged(bool value)
        {
            Performance.AdditionalRingerInfo = value;
        }

        protected void BellsPerRingerPopUp()
        {
            PopUpNum = 0;
            Modal.Open();
        }

        protected void StylePopUp()
        {
            PopUpNum = 1;
            Modal.Open();
        }

        protected void DistributedPopUp()
        {
            PopUpNum = 2;
            Modal.Open();
        }

        protected void TenorPopUp()
        {
            PopUpNum = 3;
            Modal.Open();
        }

        protected void PlatformPopUp()
        {
            PopUpNum = 4;
            Modal.Open();
        }

        protected void TimePopUp()
        {
            PopUpNum = 5;
            Modal.Open();
        }

        protected void TitlePopUp()
        {
            PopUpNum = 6;
            Modal.Open();
        }

        protected void DetailPopUp()
        {
            PopUpNum = 7;
            Modal.Open();
        }

        protected void AdditionalRingerInfoPopUp()
        {
            PopUpNum = 8;
            Modal.Open();
        }

        protected void NewMethodsPopUp()
        {
            PopUpNum = 9;
            Modal.Open();
        }

        protected void NormsPopUp()
        {
            PopUpNum = 10;
            Modal.Open();
        }

        private void PopulateRingers()
        {
            // Clear and (re)populate Ringers List
            int j;

            if (Performance.BellsPerRinger == "1")
            {
                j = 16;
            }
            else
            {
                j = 12;
            }

            Performance.Ringers.Clear();

            for (int i = 1; i <= j; i++)
            {
                RingerResponse ringerResponse = new RingerResponse();

                if (j == 16)
                {
                    ringerResponse.Bell = i.ToString();
                }
                else
                {
                    ringerResponse.Bell = ((i * 2) - 1).ToString() + "-" + (i * 2).ToString();
                }
                
                ringerResponse.Ringer = string.Empty;
                ringerResponse.Conductor = false;
                ringerResponse.RingerInfo = string.Empty;
                ringerResponse.RingerLocation = string.Empty;
                Performance.Ringers.Add(ringerResponse);
            }
        }
    }
}
