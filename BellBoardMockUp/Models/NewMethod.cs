using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Models
{
    public class NewMethod
    {
        public NewMethod()
        {
            Method = new Method();
            Properties = new Properties();
            Messages = new List<Message>();
        }

        public Method Method { get; set; }
        public Properties Properties { get; set; }
        public List<Message> Messages { get; set; }
    }

    public class Method
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string PlaceNotation { get; set; }
        public int Stage { get; set; }
    }

    public class Properties
    {
        public Properties()
        {
            Flags = new Flags();
        }

        public string LeadHead { get; set; }
        public string LeadheadCode { get; set; }
        public string FchGroups { get; set; }
        public int PlainCourseLength { get; set; }
        public int LeadLength { get; set; }
        public int LeadsInCourse { get; set; }
        public int NumberOfHuntBells { get; set; }
        public int NumberOfWorkingBells { get; set; }
        public int NumberOfStationaryBells { get; set; }
        public int NumberOfPrimaryHunts { get; set; }
        public int NumberOfSecondaryHunts { get; set; }
        public int NumberOfConsecutiveBlows { get; set; }
        public Flags Flags { get; set; }
    }

    public class Message
    {
        public string Type { get; set; }
        public string message { get; set; }
    }

    public class Flags
    {
        public long flagCollection { get; set; }
        public bool adjacentChanges { get; set; }
        public bool identityChanges { get; set; }
        public bool jumpChanges { get; set; }
        public bool @static { get; set; }
        public bool dynamic { get; set; }
        public bool principle { get; set; }
        public bool hunter { get; set; }
        public bool singleHunt { get; set; }
        public bool multipleHunt { get; set; }
        public bool allHunt { get; set; }
        public bool unicyclic { get; set; }
        public bool isocyclic { get; set; }
        public bool differential { get; set; }
        public bool plain { get; set; }
        public bool place { get; set; }
        public bool bob { get; set; }
        public bool single { get; set; }
        public bool trebleDodging { get; set; }
        public bool trebleBob { get; set; }
        public bool delight { get; set; }
        public bool surprise { get; set; }
        public bool alliance { get; set; }
        public bool treblePlace { get; set; }
        public bool hybrid { get; set; }
        public bool little { get; set; }
        public bool asymmetric { get; set; }
        public bool palindromic { get; set; }
        public bool @double { get; set; }
        public bool rotational { get; set; }
        public bool offset { get; set; }
        public bool plainBobLeadhead { get; set; }
        public bool grandsireLeadhead { get; set; }
        public bool originalLeadhead { get; set; }
        public bool cyclicLeadhead { get; set; }
        public bool roundsLeadhead { get; set; }
        public bool plainCourseIsTrue { get; set; }
        public bool leadIsTrue { get; set; }
        public bool rightPlace { get; set; }
        public bool unevenParity { get; set; }
        public bool layered { get; set; }
        public bool divisibleLead { get; set; }
        public bool block { get; set; }
        public bool slowCourse { get; set; }
    }
}
