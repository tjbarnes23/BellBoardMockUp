using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BellBoardMockUp.Models;
using BellBoardMockUp.Shared;
using BellBoardMockUp.Utilities;
using Microsoft.AspNetCore.Components;

namespace BellBoardMockUp.Pages
{
    public partial class Index
    {
        public Index()
        {
            Performance = new Performance()
            {
                Style = 1,
                AssociationDropDown = 0,
                Distributed = false,
                BellsPerRinger = 1,
                AdditionalRingerInfo = false,
                Ringers = new List<RingerData>()
            };

            PopulateRingers();
        }

        [Inject]
        public HttpClient Http { get; set; }

        public Performance Performance { get; set; }

        private Modal Modal { get; set; }

        public int PopUpNum { get; set; }

        protected void StyleChanged(int value)
        {
            Performance.Style = value;

            if (Performance.Style == 1)
            {
                Performance.BellsPerRinger = 1;
                PopulateRingers();
            }
            else if (Performance.Style == 2)
            {
                Performance.BellsPerRinger = 2;
                PopulateRingers();
            }
            else if (Performance.Style == 3)
            {
                Performance.Distributed = true;
            }
        }

        protected void AssociationDropDownChanged(int value)
        {
            Performance.AssociationDropDown = value;
            Performance.AssociationFreeForm = string.Empty;
        }

        protected void BellsPerRingerChanged(int value)
        {
            Performance.BellsPerRinger = value;
            
            PopulateRingers();
        }

        protected void AdditionalRingerInfoChanged(bool value)
        {
            Performance.AdditionalRingerInfo = value;
        }

        protected async Task Import()
        {
            // Get a test from the API
            JsonImport jsonImport = await Http.GetFromJsonAsync<JsonImport>($"composition/{Performance.CompLibId}");

            // Use the Deserializer method of the JsonSerializer class (in the System.Text.Json namespace) to create
            // a BlowSetData object
            CompImport compImport = JsonSerializer.Deserialize<CompImport>(jsonImport.JsonSpec);

            Performance.Title = compImport.Title;
            Performance.Composer = compImport.Composer;
            
            StateHasChanged();
        }

        protected void StylePopUp()
        {
            PopUpNum = 0;
            Modal.Open();
        }

        protected void DistributedPopUp()
        {
            PopUpNum = 1;
            Modal.Open();
        }

        protected void TenorPopUp()
        {
            PopUpNum = 2;
            Modal.Open();
        }

        protected void PlatformPopUp()
        {
            PopUpNum = 3;
            Modal.Open();
        }

        protected void TimePopUp()
        {
            PopUpNum = 4;
            Modal.Open();
        }

        protected void ImportPopUp()
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

        protected void BellsPerRingerPopUp()
        {
            PopUpNum = 8;
            Modal.Open();
        }

        protected void AdditionalRingerInfoPopUp()
        {
            PopUpNum = 9;
            Modal.Open();
        }

        protected void RingerStylePopUp()
        {
            PopUpNum = 10;
            Modal.Open();
        }

        protected void NewMethodsPopUp()
        {
            PopUpNum = 11;
            Modal.Open();
        }

        protected void NormsPopUp()
        {
            PopUpNum = 12;
            Modal.Open();
        }

        private void PopulateRingers()
        {
            // Clear and (re)populate Ringers List
            int j;

            if (Performance.BellsPerRinger == 1)
            {
                j = 16;
            }
            else if (Performance.BellsPerRinger == 2)
            {
                j = 12;
            }
            else
            {
                j = 18;
            }

            Performance.Ringers.Clear();

            for (int i = 1; i <= j; i++)
            {
                RingerData ringerData = new RingerData();
                ringerData.Id = i;

                if (Performance.BellsPerRinger == 1)
                {
                    ringerData.Bell = i.ToString();
                }
                else if (Performance.BellsPerRinger == 2)
                {
                    ringerData.Bell = ((i * 2) - 1).ToString() + "-" + (i * 2).ToString();
                }
                else
                {
                    ringerData.Bell = string.Empty;
                }

                ringerData.Ringer = string.Empty;
                ringerData.Conductor = false;
                ringerData.RingerInfo = string.Empty;
                ringerData.RingerLocation = string.Empty;
                ringerData.RingerStyle = 1;
                ringerData.RingerStyleOther = string.Empty;

                Performance.Ringers.Add(ringerData);
            }
        }
    }
}
