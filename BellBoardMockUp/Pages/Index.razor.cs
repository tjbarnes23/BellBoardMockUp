using System;
using System.Collections.Generic;
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
    public partial class Index
    {
        [Inject]
        public TJBarnesService TJBarnesService { get; set; }
        
        [Inject]
        public Performance Performance { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public Viewport Viewport { get; set; }

        public IEnumerable<PerformanceJson> Performances { get; set; }

        public bool Loading { get; set; }

        public int Width { get; set; }

        public string LeftPosStr { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetWidth();

            // 40 is half the width of the spinner
            int leftPos = (Width / 2) - 40;
            leftPos = Math.Min(leftPos, 215);

            LeftPosStr = leftPos.ToString() + "px";

            StateHasChanged();

            Performances = (await TJBarnesService.GetHttpClient()
                    .GetFromJsonAsync<PerformanceJson[]>("api/performances")).ToList();
        }

        protected void LoadDraft(int id)
        {
            PerformanceJson performanceJson = Performances.Where(p => p.Id == id).FirstOrDefault();

            // Use the Deserializer method of the JsonSerializer class (in the System.Text.Json namespace) to create
            // a Performance object
            Performance performance = JsonSerializer.Deserialize<Performance>(performanceJson.PerformanceContent);

            // Populate Performance service fields
            Performance.Id = performance.Id;
            Performance.Nickname = performance.Nickname;
            Performance.Style = performance.Style;
            Performance.StyleOther = performance.StyleOther;
            Performance.AssociationDropDown = performance.AssociationDropDown;
            Performance.AssociationFreeForm = performance.AssociationFreeForm;
            Performance.Date = performance.Date;
            Performance.Distributed = performance.Distributed;
            Performance.Location = performance.Location;
            Performance.County = performance.County;
            Performance.Address = performance.Address;
            Performance.Tenor = performance.Tenor;
            Performance.Platform = performance.Platform;
            Performance.Time = performance.Time;
            Performance.ImportFromCompLib = performance.ImportFromCompLib;
            Performance.CompLibId = performance.CompLibId;
            Performance.Length = performance.Length;
            Performance.Title = performance.Title;
            Performance.Composer = performance.Composer;
            Performance.Detail = performance.Detail;

            Performance.NumRingers = performance.NumRingers;
            Performance.BellsPerRinger = performance.BellsPerRinger;
            Performance.AdditionalRingerInfo = performance.AdditionalRingerInfo;

            Performance.Ringers.Clear();

            foreach (RingerData ringerData in performance.Ringers)
            {
                Performance.Ringers.Add(ringerData);
            }

            Performance.NewMethodsNamed = performance.NewMethodsNamed;
            
            Performance.NewMethods.Clear();

            foreach (NewMethodData newMethodData in performance.NewMethods)
            {
                Performance.NewMethods.Add(newMethodData);
            }

            Performance.Footnotes = performance.Footnotes;
            Performance.NormDepartures = performance.NormDepartures;

            NavManager.NavigateTo("/preview");
        }

        protected void NewPerformance()
        {
            Performance.Id = 0;
            Performance.Nickname = string.Empty;
            Performance.Style = 1;
            Performance.StyleOther = string.Empty;
            Performance.AssociationDropDown = 0;
            Performance.AssociationFreeForm = string.Empty;
            Performance.Date = DateTime.Today;
            Performance.Distributed = false;
            Performance.Location = string.Empty;
            Performance.County = string.Empty;
            Performance.Address = string.Empty;
            Performance.Tenor = string.Empty;
            Performance.Platform = string.Empty;
            Performance.Time = string.Empty;
            Performance.ImportFromCompLib = false;
            Performance.CompLibId = string.Empty;
            Performance.Length = string.Empty;
            Performance.Title = string.Empty;
            Performance.Composer = string.Empty;
            Performance.Detail = string.Empty;

            Performance.NumRingers = 0;
            Performance.BellsPerRinger = 1;
            Performance.AdditionalRingerInfo = false;
            Performance.Ringers.Clear();

            Performance.NewMethodsNamed = false;
            Performance.NewMethods.Clear();
            Performance.AddNewMethod();

            Performance.Footnotes = string.Empty;
            Performance.NormDepartures = string.Empty;
            
            NavManager.NavigateTo("/entry");
        }

        protected async Task GetWidth()
        {
            BrowserDimensions browserDimensions = await Viewport.GetDimensions();
            Width = browserDimensions.Width;
        }
    }
}
