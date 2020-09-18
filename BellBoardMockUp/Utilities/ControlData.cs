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
                3 => "Other configuration",
                _ => bellsPerRinger.ToString()
            };
        }

        public static string Style(int style)
        {
            return style switch
            {
                1 => "Full circle (Tower bells)",
                2 => "Up / down strokes (Handbells)",
                3 => "Key presses (Online)",
                4 => "Other style",
                5 => "Mixed style",
                _ => style.ToString()
            };
        }
    }
}
