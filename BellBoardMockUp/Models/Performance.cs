using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Models
{
    public class Performance
    {
        public Style Style { get; set; }

        public string StyleOther { get; set; }

        public BellsPerRinger BellsPerRinger { get; set; }

        public string NumBells { get; set; }


    }
}
