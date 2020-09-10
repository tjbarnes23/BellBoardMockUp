using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Models
{
    public class Performance
    {
        public string BellsPerRinger { get; set; }

        public string Style { get; set; }

        public string StyleOther { get; set; }

        public string AssociationDropDown { get; set; }

        public string AssociationFreeForm { get; set; }

        public string Date { get; set; }

        public bool Distributed { get; set; }

        public string Location { get; set; }

        public string County { get; set; }

        public string Address { get; set; }

        public string Tenor { get; set; }

        public string Platform { get; set; }

        public string Time { get; set; }

        public string Length { get; set; }

        public string Title { get; set; }

        public string Composer { get; set; }

        public string Detail { get; set; }

        public bool AdditionalRingerInfo { get; set; }

        public List<RingerResponse> Ringers { get; set; }

        public string Footnotes { get; set; }

        public string NewMethods { get; set; }
        
        public string NormDepartures { get; set; }
    }
}
