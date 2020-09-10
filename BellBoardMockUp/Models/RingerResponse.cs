using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Models
{
    public class RingerResponse
    {
        public string Bell { get; set; }

        public string Ringer { get; set; }

        public bool Conductor { get; set; }

        public string RingerInfo { get; set; }

        public string RingerLocation { get; set; }
    }
}
