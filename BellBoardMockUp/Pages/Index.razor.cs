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

        public IEnumerable<PerformanceJson> Performances { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Performances = (await TJBarnesService.GetHttpClient().GetFromJsonAsync<PerformanceJson[]>("api/performances")).ToList();
        }

        protected void LoadDraft(int id)
        {
            PerformanceJson performanceJson = Performances.Where(p => p.Id == id).FirstOrDefault();

            // Use the Deserializer method of the JsonSerializer class (in the System.Text.Json namespace) to create
            // a Performance object
            Performance = JsonSerializer.Deserialize<Performance>(performanceJson.PerformanceContent);

            StateHasChanged();

            NavManager.NavigateTo("/entry");
        }
    }
}
