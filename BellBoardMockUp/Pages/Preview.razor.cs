using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BellBoardMockUp.Models;
using System.Text;

namespace BellBoardMockUp.Pages
{
    public partial class Preview
    {
        [Inject]
        public Performance Performance { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        public string Location1 { get; set; }

        protected string ConsolidatedRinger(RingerData ringerData)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(ringerData.Ringer);
            sb.Append(" ");

            if (ringerData.Conductor == true)
            {
                sb.Append("(C)");
            }

            return sb.ToString();
        }

        protected string ConsolidatedRingerInfo(RingerData ringerData)
        {
            StringBuilder sb = new StringBuilder();
            int items = 0;

            if (Performance.AdditionalRingerInfo == true && !string.IsNullOrEmpty(ringerData.RingerInfo))
            {
                sb.Append("(");
                sb.Append(ringerData.RingerInfo);
                items++;
            }

            if (Performance.Distributed == true && !string.IsNullOrEmpty(ringerData.RingerLocation))
            {
                if (items > 0)
                {
                    sb.Append("; ");
                }
                else
                {
                    sb.Append("(");
                }

                sb.Append(ringerData.RingerLocation);
                items++;
            }

            if (Performance.Style == 5)
            {
                if (items > 0)
                {
                    sb.Append("; ");
                }
                else
                {
                    sb.Append("(");
                }

                switch (ringerData.RingerStyle)
                {
                    case 1:
                        sb.Append("Full circle");
                        break;

                    case 2:
                        sb.Append("Up/down strokes");
                        break;

                    case 3:
                        sb.Append("Key presses");
                        break;
                    
                    case 4:
                        sb.Append(ringerData.RingerStyleOther);
                        break;

                    default:
                        break;
                }

                items++;
            }

            if (items > 0)
            {
                sb.Append(")");
            }

            return sb.ToString();
        }
    }
}
