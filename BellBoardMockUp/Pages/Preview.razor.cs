using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BellBoardMockUp.Models;

namespace BellBoardMockUp.Pages
{
    public partial class Preview
    {
        [Inject]
        public Performance Performance { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }
    }
}
