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
                SoundNorm = true,
                TrueRoundBlockNorm = true,
                SamePersonNorm = true,
                RetainedInHandNorm = true,
                NoAssistanceNorm = true,
                HumanNorm = true,
                TechnicalNorm = true,
                NoFailureNorm = true
            };
        }

        public Performance Performance { get; set; }

        public void BellsPerRingerChanged(string value)
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

        public void StyleChanged(string value)
        {
            Performance.Style = value;

            if (Performance.Style == "3")
            {
                Performance.Distributed = true;
                Performance.Online = true;
            }
        }

        public void DistributedChanged(bool value)
        {
            Performance.Distributed = value;
        }

        public void OnlineChanged(bool value)
        {
            Performance.Online = value;
        }
    }
}
