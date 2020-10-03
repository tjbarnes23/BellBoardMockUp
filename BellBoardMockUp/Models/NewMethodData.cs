using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellBoardMockUp.Utilities;

namespace BellBoardMockUp.Models
{
    public class NewMethodData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stage { get; set; }

        public string PlaceNotation { get; set; }

        public bool Validating { get; set; }

        public string Status { get; set; }

        public string Title { get; set; }
    }
}
