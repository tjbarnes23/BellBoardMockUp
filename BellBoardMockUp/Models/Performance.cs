using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellBoardMockUp.Utilities;

namespace BellBoardMockUp.Models
{
    public class Performance
    {
        public int Style { get; set; }

        public string StyleOther { get; set; }

        public int AssociationDropDown { get; set; }

        public string AssociationFreeForm { get; set; }

        public string Date { get; set; }

        public bool Distributed { get; set; }

        public string Location { get; set; }

        public string County { get; set; }

        public string Address { get; set; }

        public string Tenor { get; set; }

        public string Platform { get; set; }

        public string Time { get; set; }

        public bool ImportFromCompLib { get; set; }

        public string CompLibId { get; set; }

        public string Length { get; set; }

        public string Title { get; set; }

        public string Composer { get; set; }

        public string Detail { get; set; }

        public int BellsPerRinger { get; set; }

        public bool AdditionalRingerInfo { get; set; }

        public List<RingerData> Ringers { get; set; }

        public string Footnotes { get; set; }

        public string NewMethodName { get; set; }

        public string NewMethodPlaceNotation { get; set; }

        public Stage NewMethodStage { get; set; }

        public string NewMethodValidationMessage { get; set; }

        public string NewMethodTitle { get; set; }

        public string NormDepartures { get; set; }
    }
}
