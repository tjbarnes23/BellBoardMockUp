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
            Performance = new Performance()
            {
                BellsPerRinger = "1",
                Style = "1",
                StyleOther = "",
                Distributed = false,
                Online = false,
                Expand = false,
                SoundNorm = true,
                TrueRoundBlockNorm = true,
                SamePersonNorm = true,
                RetainedInHandNorm = true,
                TechnicalNorm = true,
                NoFailureNorm = true
            };
        }

        public Performance Performance { get; set; }

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
        }

        protected void StyleChanged(string value)
        {
            Performance.Style = value;

            if (Performance.Style == "3")
            {
                Performance.Distributed = true;
                Performance.Online = true;
            }
        }

        protected void DistributedChanged(bool value)
        {
            Performance.Distributed = value;
        }

        protected void OnlineChanged(bool value)
        {
            Performance.Online = value;
        }

        protected void ExpandChanged()
        {
            if (Performance.Expand == true)
            {
                Performance.Expand = false;
            }
            else
            {
                Performance.Expand = true;
            }
        }
    }
}
