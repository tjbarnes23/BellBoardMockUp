using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Utilities
{
    public static class ControlData
    {
        

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

        public static string Association(int association)
        {
            return association switch
            {
                1 => "Ancient Society of College Youths",
                2 => "Society of Royal Cumberland Youths",
                3 => "North American Guild",
                4 => "Cambridge University Guild",
                5 => "Guild of St Cuileáin",
                _ => association.ToString()
            };
        }

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

        public static string Stage(int stage)
        {
            return stage switch
            {
                2 => "Two",
                3 => "Singles",
                4 => "Minimus",
                5 => "Doubles",
                6 => "Minor",
                7 => "Triples",
                8 => "Major",
                9 => "Caters",
                10 => "Royal",
                11 => "Cinques",
                12 => "Maximus",
                13 => "Sextuples",
                14 => "Fourteen",
                15 => "Septuples",
                16 => "Sixteen",
                17 => "Octuples",
                18 => "Eighteen",
                19 => "Nineteen",
                20 => "Twenty",
                21 => "Twenty-One",
                22 => "Twenty-Two",
                23 => "Twenty-Three",
                24 => "Twenty-Four",
                _ => stage.ToString()
            };
        }
    }
}
