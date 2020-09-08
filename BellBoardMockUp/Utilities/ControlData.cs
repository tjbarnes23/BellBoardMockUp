using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Utilities
{
    public static class ControlData
    {
        public static string BellsPerRinger(int bellsPerRinger)
        {
            return bellsPerRinger switch
            {
                1 => "One bell per ringer",
                2 => "Two bells per ringer",
                _ => bellsPerRinger.ToString()
            };
        }

        public static string Style(int style)
        {
            return style switch
            {
                1 => "Full circle",
                2 => "Alternating strokes",
                3 => "Key presses",
                4 => "Other",
                _ => style.ToString()
            };
        }
    }
}
