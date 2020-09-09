using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellBoardMockUp.Models;
using BellBoardMockUp.Shared;

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
                Online = false
            };
        }

        public Performance Performance { get; set; }

        private Modal Modal { get; set; }

        public int PopUpNum { get; set; }

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

        protected void BellsPerRingerPopUp()
        {
            PopUpNum = 0;
            Modal.Open();
        }

        protected void StylePopUp()
        {
            PopUpNum = 1;
            Modal.Open();
        }

        protected void DistributedPopUp()
        {
            PopUpNum = 2;
            Modal.Open();
        }

        protected void OnlinePopUp()
        {
            PopUpNum = 3;
            Modal.Open();
        }

        protected void TenorPopUp()
        {
            PopUpNum = 4;
            Modal.Open();
        }

        protected void OnlinePlatformPopUp()
        {
            PopUpNum = 5;
            Modal.Open();
        }

        protected void TimePopUp()
        {
            PopUpNum = 6;
            Modal.Open();
        }

        protected void NewMethodsPopUp()
        {
            PopUpNum = 7;
            Modal.Open();
        }

        protected void NormsPopUp()
        {
            PopUpNum = 8;
            Modal.Open();
        }
    }
}
