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

        public string Association { get; set; }

        public string Date { get; set; }

        public bool Distributed { get; set; }

        public bool Online { get; set; }

        public string Place { get; set; }

        public string Address { get; set; }

        public string Tenor { get; set; }

        public string Platform { get; set; }

        public string Time { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public string Composer { get; set; }

        public string Footnotes { get; set; }

        public string NewMethods { get; set; }

        public bool SoundNorm { get; set; }

        public string SoundNormComment { get; set; }

        public bool TrueRoundBlockNorm { get; set; }

        public string TrueRoundBlockComment { get; set; }

        public bool SamePersonNorm { get; set; }

        public string SamePersonComment { get; set; }

        public bool RetainedInHandNorm { get; set; }

        public string RetainedInHandComment { get; set; }

        public bool NoAssistanceNorm { get; set; }

        public string NoAssistanceComment { get; set; }

        public bool HumanNorm { get; set; }

        public string HumanComment { get; set; }

        public bool TechnicalNorm { get; set; }

        public string TechnicalComment { get; set; }

        public bool NoFailureNorm { get; set; }

        public string NoFailureComment { get; set; }

    }
}
