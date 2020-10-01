using System;
using System.Collections.Generic;
using System.Linq;

namespace BellBoardMockUp.Models
{
    public class Performance
    {
        public Performance()
        {
            Id = 0;
            Style = 1;
            AssociationDropDown = 0;
            Date = DateTime.Today;
            Distributed = false;
            ImportFromCompLib = false;
            NumRingers = 8;
            BellsPerRinger = 1;
            AdditionalRingerInfo = false;
            Ringers = new List<RingerData>();
            NewMethods = new List<NewMethodData>();

            PopulateRingers();
            AddNewMethod();
        }

        public int Id { get; set; }

        public string Nickname { get; set; }

        public int Style { get; set; }

        public string StyleOther { get; set; }

        public int AssociationDropDown { get; set; }

        public string AssociationFreeForm { get; set; }

        public DateTime Date { get; set; }

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

        public int NumRingers { get; set; }

        public int BellsPerRinger { get; set; }

        public bool AdditionalRingerInfo { get; set; }

        public List<RingerData> Ringers { get; set; }

        public string Footnotes { get; set; }

        public List<NewMethodData> NewMethods { get; set; }

        public string NormDepartures { get; set; }

        public void PopulateRingers()
        {
            // See how many items are currently in Ringers list, and adjust to match the value of NumRingers

            int j = NumRingers - Ringers.Count;

            if (j > 0)
            {
                for (int i = 1; i <= j; i++)
                {
                    RingerData ringerData = new RingerData();
                    ringerData.Id = Ringers.Count;
                    ringerData.Bell = string.Empty;
                    ringerData.Ringer = string.Empty;
                    ringerData.Conductor = false;
                    ringerData.RingerInfo = string.Empty;
                    ringerData.RingerLocation = string.Empty;
                    ringerData.RingerStyle = 1;
                    ringerData.RingerStyleOther = string.Empty;

                    Ringers.Add(ringerData);
                }
            }
            else if (j < 0)
            {
                int k = -j;
                
                for (int i = 1; i <= k; i++)
                {
                    Ringers.RemoveAt(Ringers.Count - 1);
                }
            }

            if (j != 0)
            {
                PopulateRingersBells();
            }
        }

        public void PopulateRingersBells()
        {
            int i = 1;

            foreach (RingerData ringerData in Ringers)
            {
                if (BellsPerRinger == 1)
                {
                    ringerData.Bell = i.ToString();
                }
                else if (BellsPerRinger == 2)
                {
                    ringerData.Bell = ((i * 2) - 1).ToString() + "-" + (i * 2).ToString();
                }

                i++;
            }
        }

        public void AddNewMethod()
        {
            NewMethodData newMethodData = new NewMethodData()
            {
                Id = NewMethods.Count(),
                Name = string.Empty,
                PlaceNotation = string.Empty,
                Stage = 0
            };

            NewMethods.Add(newMethodData);
        }
    }
}
