using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BellBoardMockUp.Models;
using BellBoardMockUp.Shared;
using BellBoardMockUp.Utilities;
using Microsoft.AspNetCore.Components;

namespace BellBoardMockUp.Pages
{
    public partial class Entry
    {
        [Inject]
        public TJBarnesService TJBarnesService { get; set; }

        [Inject]
        public CompLibService CompLibService { get; set; }

        [Inject]
        public Performance Performance { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        private Modal Modal { get; set; }

        public bool CompImporting { get; set; }

        public bool Saving { get; set; }

        protected void StyleChanged(int value)
        {
            Performance.Style = value;

            if (Performance.Style == 1)
            {
                Performance.BellsPerRinger = 1;
                Performance.PopulateRingers();
            }
            else if (Performance.Style == 2)
            {
                Performance.BellsPerRinger = 2;
                Performance.PopulateRingers();
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

        protected void NumRingersChanged(int value)
        {
            Performance.NumRingers = value;
            Performance.PopulateRingers();
        }

        protected void BellsPerRingerChanged(int value)
        {
            Performance.BellsPerRinger = value;

            Performance.PopulateRingersBells();
        }

        protected void AdditionalRingerInfoChanged(bool value)
        {
            Performance.AdditionalRingerInfo = value;
        }

        protected void ActivatePopUp(PopUp value)
        {
            Modal.Open(value);
        }

        protected async Task CompImport()
        {
            // Start spinner
            CompImporting = true;

            DateTime currTimeStart = DateTime.Now;

            // Clear any existing composition info
            Performance.Length = string.Empty;
            Performance.Title = string.Empty;
            Performance.Composer = string.Empty;
            Performance.Detail = string.Empty;

            // Get a test from the API
            JsonImport jsonImport = await TJBarnesService.GetHttpClient().GetFromJsonAsync<JsonImport>("api/gaptests/14");

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

            DateTime currTimeEnd = DateTime.Now;

            if (currTimeEnd < currTimeStart.AddSeconds(1))
            {
                double delay = currTimeStart.AddSeconds(1).Subtract(currTimeEnd).TotalMilliseconds;
                await Task.Delay(Convert.ToInt32(delay));
            }

            CompImporting = false;
        }

        protected async Task ValidateMethod(int newMethodId)
        {
            // Start spinner
            Performance.NewMethods[newMethodId].Validating = true;

            DateTime currTimeStart = DateTime.Now;

            // Clear any existing new method results
            Performance.NewMethods[newMethodId].Status = string.Empty;
            Performance.NewMethods[newMethodId].Title = string.Empty;

            // Get a test from the API
            JsonImport jsonImport = await TJBarnesService.GetHttpClient().GetFromJsonAsync<JsonImport>("api/gaptests/16");

            // Make property matching case insensitive
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            // Use the Deserializer method of the JsonSerializer class (in the System.Text.Json namespace) to create
            // a BlowSetData object
            NewMethod newMethod = JsonSerializer.Deserialize<NewMethod>(jsonImport.GapTestSpec, options);

            Performance.NewMethods[newMethodId].Status = newMethod.Status;
            Performance.NewMethods[newMethodId].Title = newMethod.Result.Title;

            DateTime currTimeEnd = DateTime.Now;

            if (currTimeEnd < currTimeStart.AddSeconds(1))
            {
                double delay = currTimeStart.AddSeconds(1).Subtract(currTimeEnd).TotalMilliseconds;
                await Task.Delay(Convert.ToInt32(delay));
            }

            Performance.NewMethods[newMethodId].Validating = false;
        }

        protected async void SaveDraft()
        {
            // Push the performance content to the API in JSON format
            Saving = true;

            // Use the Serializer method of the JsonSerializer class (in the System.Text.Json namespace) to create
            // a Json object from the Performance object
            PerformanceJson performanceJson = new PerformanceJson();
            performanceJson.Nickname = Performance.Nickname;
            performanceJson.PerformanceContent = JsonSerializer.Serialize(Performance);

            // Push the Json object to the API
            await TJBarnesService.GetHttpClient().PostAsJsonAsync("api/performances", performanceJson);

            Saving = false;

            StateHasChanged();
        }
    }
}
