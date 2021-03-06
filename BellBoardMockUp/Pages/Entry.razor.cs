﻿using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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
        public NewMethod NewMethod { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        private Modal Modal { get; set; }

        private int FormPage { get; set; } = 1;

        public bool CompImporting { get; set; }

        public bool Saving { get; set; }

        public bool Saved { get; set; }

        public int Width { get; set; }

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

        protected void AssociationFreeFormChanged(string value)
        {
            Performance.AssociationFreeForm = value;
            Performance.AssociationDropDown = 0;
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

            // Clear any existing composition info
            Performance.Length = string.Empty;
            Performance.Title = string.Empty;
            Performance.Composer = string.Empty;
            Performance.Detail = string.Empty;

            // Check that valid id has been entered
            if (!string.IsNullOrEmpty(Performance.CompLibId))
            {
                var response = await CompLibService.GetHttpClient()
                    .GetAsync($"composition/{Performance.CompLibId}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    CompImport compImport = await CompLibService.GetHttpClient()
                        .GetFromJsonAsync<CompImport>($"composition/{Performance.CompLibId}");

                    int firstSpace = compImport.Title.IndexOf(" ");

                    Performance.Length = compImport.Title.Substring(0, firstSpace);
                    Performance.Title = compImport.Title.Substring(firstSpace + 1);

                    if (compImport.ComposerDetails.Length != 0)
                    {
                        Performance.Composer = compImport.ComposerDetails.First().Name;
                    }
                    else
                    {
                        Performance.Composer = string.Empty;
                    }

                    Performance.Detail = compImport.MethodDetails;
                }
                else
                {
                    Performance.Title = "*** Composition not found ***";
                }
            }
            else
            {
                Performance.Title = "*** Composition not found ***";
            }

            CompImporting = false;
        }

        protected async Task ValidateMethod(int newMethodId)
        {
            // Start spinner
            Performance.NewMethods[newMethodId].Validating = true;

            // Clear any existing new method results
            Performance.NewMethods[newMethodId].Status = string.Empty;
            Performance.NewMethods[newMethodId].Title = string.Empty;

            // Check for nothing entered
            if (!string.IsNullOrEmpty(Performance.NewMethods[newMethodId].Name) ||
                    !string.IsNullOrEmpty(Performance.NewMethods[newMethodId].PlaceNotation) ||
                    Performance.NewMethods[newMethodId].Stage != 0)
            {
                // Get a test from the API
                NewMethod newMethod = await CompLibService.GetHttpClient()
                        .GetFromJsonAsync<NewMethod>($"method/validate?stage={Performance.NewMethods[newMethodId].Stage}" +
                        $"&name={Performance.NewMethods[newMethodId].Name}" +
                        $"&placenotation={Performance.NewMethods[newMethodId].PlaceNotation}");

                // Populate the NewMethod service
                if (newMethod.Method != null)
                {
                    NewMethod.Method.Title = newMethod.Method.Title;
                    NewMethod.Method.PlaceNotation = newMethod.Method.PlaceNotation;
                    NewMethod.Properties.LeadheadCode = newMethod.Properties.LeadheadCode;
                    NewMethod.Properties.LeadHead = newMethod.Properties.LeadHead;

                    Performance.NewMethods[newMethodId].Title = newMethod.Method.Title;
                }
                else
                {
                    Performance.NewMethods[newMethodId].Title = "Error";
                }

                NewMethod.Messages.Clear();

                if (newMethod.Messages.Count != 0)
                {
                    foreach (var message in newMethod.Messages)
                    {
                        NewMethod.Messages.Add(message);
                    }

                    Performance.NewMethods[newMethodId].Status = "See messages";
                }
                else
                {
                    Performance.NewMethods[newMethodId].Status = "No messages";
                }
            }

            Performance.NewMethods[newMethodId].Validating = false;

            if (!string.IsNullOrEmpty(Performance.NewMethods[newMethodId].Title))
            {
                ActivatePopUp(PopUp.NewMethodResult);
            }
        }

        protected async Task SaveDraft()
        {
            // Push the performance content to the API in JSON format

            // Generate nickname if none
            if (string.IsNullOrEmpty(Performance.Nickname))
            {
                StringBuilder sb = new StringBuilder();
                int items = 0;

                if (!string.IsNullOrEmpty(Performance.Location))
                {
                    sb.Append(Performance.Location);
                    items++;
                }

                if (items == 0)
                {
                    if (!string.IsNullOrEmpty(Performance.Platform))
                    {
                        sb.Append(Performance.Platform);
                        items++;
                    }
                }

                if (items > 0)
                {
                    sb.Append(" ");
                }

                sb.Append(Performance.Date.ToString("yyyy-MM-dd"));

                Performance.Nickname = sb.ToString();
            }

            PerformanceJson performanceJson = new PerformanceJson();

            // If Id = 0 then this is a new performance so Push an initial PerformanceJson object
            // to the API to get the new id
            if (Performance.Id == 0)
            {
                // Do an initial post of a blank PerformanceJson object to get the new Id
                HttpResponseMessage response = await TJBarnesService.GetHttpClient()
                        .PostAsJsonAsync("api/performances", performanceJson);

                PerformanceJson returnValue = await response.Content.ReadFromJsonAsync<PerformanceJson>();

                // Update the Performance object with the new id
                Performance.Id = returnValue.Id;
            }

            // Now populate the performanceJson object
            performanceJson.Id = Performance.Id;
            performanceJson.Nickname = Performance.Nickname;
                
            // Use the Serializer method of the JsonSerializer class (in the System.Text.Json namespace) to create
            // a Json object from the Performance object
            performanceJson.PerformanceContent = JsonSerializer.Serialize(Performance);

            await TJBarnesService.GetHttpClient()
                    .PutAsJsonAsync($"api/performances/{Performance.Id}", performanceJson);
        }

        protected async Task Back()
        {
            Saving = true;
            await SaveDraft();
            
            FormPage--;

            Saving = false;
            StateHasChanged();
        }

        protected async Task Next()
        {
            Saving = true;
            await SaveDraft();

            if (FormPage == 0 || FormPage == 5)
            {
                // Must be at the end of the form, so navigate to Preview page
                NavManager.NavigateTo("/preview");
            }
            else
            {
                FormPage++;
            }

            Saving = false;
            StateHasChanged();
        }

        
    }
}
