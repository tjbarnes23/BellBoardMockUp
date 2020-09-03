using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellBoardMockUp.Models;

namespace BellBoardMockUp.Pages
{
    public partial class Index
    {
        public Index()
        {
            Performance = new Performance();
        }

        public Performance Performance { get; set; }

        public void StyleChanged(Style value)
        {
            Performance.Style = value;
        }

        public void BellsPerRingerChanged(BellsPerRinger value)
        {
            Performance.BellsPerRinger = value;
        }

        public void NumBellsChanged(string value)
        {
            Performance.NumBells = value;
        }
    }
}
