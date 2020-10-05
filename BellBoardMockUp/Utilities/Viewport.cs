using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BellBoardMockUp.Utilities
{
    public class Viewport
    {
        private readonly IJSRuntime JSRuntime;

        public Viewport(IJSRuntime js)
        {
            JSRuntime = js;
        }

        public async Task<BrowserDimensions> GetDimensions()
        {
            return await JSRuntime.InvokeAsync<BrowserDimensions>("getDimensions");
        }

    }

    public class BrowserDimensions
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
    }
}
