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
            JsonImport jsonImport = await Http.GetFromJsonAsync<JsonImport>("api/gaptests/14");

            // Make property matching case insensitive
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Use the Deserializer method of the JsonSerializer class (in the System.Text.Json namespace) to create
            // a BlowSetData object
            CompImport compImport = JsonSerializer.Deserialize<CompImport>(jsonImport.GapTestSpec, options);

            int loc = compImport.Title.IndexOf(" ");

            Performance.Length = compImport.Title.Substring(0, loc);
            Performance.Title = compImport.Title.Substring(loc + 1);
            Performance.Composer = compImport.ComposerDetails.First().Name;
            
            StateHasChanged();
        }

        protected void ActivatePopUp(PopUp value)
        {
            Modal.Open(value);
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
