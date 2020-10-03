using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BellBoardMockUp.Models;
using BellBoardMockUp.Utilities;
using Microsoft.AspNetCore.Components;

namespace BellBoardMockUp.Shared
{
    public partial class Modal
    {
        [Inject]
        public NewMethod NewMethod { get; set; }

        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public bool ShowBackdrop = false;
        public string Title;
        public string Content;
        public string Image;
        public string Link;

        public void Open()
        {
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            StateHasChanged();
        }

        public void Open(PopUp popUp)
        {
            Populate(popUp);
            ModalDisplay = "block;";
            ModalClass = "Show";
            ShowBackdrop = true;
            StateHasChanged();
        }

        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            ShowBackdrop = false;
            StateHasChanged();
        }

        protected void Populate(PopUp popUp)
        {
            StringBuilder sb = new StringBuilder();

            switch (popUp)
            {
                case PopUp.Style:
                    Title = "Style";
                    sb.Append("Full circle is the usual style for tower bells (including dummy tower bells). " +
                        "The bells are rung using a rope, wheel and pulley.");
                    sb.Append("\n\n");
                    sb.Append("Up / down strokes is the usual style for handbells (including dummy handbells). " +
                        "The bells are retained in hand and rung with alternating upstrokes and downstrokes.");
                    sb.Append("\n\n");
                    sb.Append("Key presses usually refers to online performances 'rung' using a computer keyboard, " +
                        "but it can also refer to a method ringing performance on an instrument such as a carillon.");
                    sb.Append("\n\n");
                    sb.Append("Other style is for anything that doesn't fall into the above categories. " +
                        "Please provide details in the 'Other Style' box that will appear.");
                    sb.Append("\n\n");
                    sb.Append("If different ringers use different styles in the same performance (e.g. in a Ringing " +
                        "Room performance, some ringers use dummy handbells and others use key presses), " +
                        "please select 'Mixed style'. You will then be able to specify the style used by each " +
                        "individual ringer.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;
                
                case PopUp.Distributed:
                    Title = "Distributed";
                    sb.Append("A distributed performance is one where the ringers are located in different places.");
                    sb.Append("\n\n");
                    sb.Append("Instead of entering a place for the performance, the approximate location is entered " +
                        "for each ringer.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;
                
                case PopUp.Tenor:
                    Title = "Tenor info";
                    sb.Append("For tower bells, this is usually entered in the form 18–3–20 in E♭, where the " +
                        "weight is in cwt-qtr-lb.");
                    sb.Append("\n\n");
                    sb.Append("For handbells, this is usually entered in the form 13 in C♯, where 13 is the size " +
                        "used by handbell manufacturers.");
                    sb.Append("\n\n");
                    sb.Append("If the performance was rung on a computer platform such as Ringing Room or Handbell " +
                        "Stadium, then leave this box blank.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;
                
                case PopUp.Platform:
                    Title = "Platform";
                    sb.Append("If the performance was rung on a computer platform, enter the name of the platform " +
                        "such as Ringing Room, Handbell Stadium, Muster, Ding, Abel, or Mobel.");
                    sb.Append("\n\n");
                    sb.Append("Otherwise, leave this box blank.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;
                
                case PopUp.Time:
                    Title = "Time taken";
                    sb.Append("Entered as hours:minutes, e.g. 3:05 or 0:42.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;
                
                case PopUp.Import:
                    Title = "Import from CompLib";
                    sb.Append("The Performance Title, Composer and Performance Detail boxes can be " +
                        "imported from CompLib.");
                    sb.Append("\n\n");
                    sb.Append("Click this checkbox, enter the CompLib composition id in the box that will appear, " +
                        "and click on Import.");
                    sb.Append("\n\n");
                    sb.Append("The CompLib composition id is the number at the end of the CompLib URL " +
                        "(after the last slash) when the composition is selected in CompLib.");
                    sb.Append(" E.g. if the selected composition in CompLib has the URL shown below, the " +
                        "composition id is 66827.");
                    Content = sb.ToString();
                    Image = "images/complib-id.jpg";
                    Link = string.Empty;
                    break;
                
                case PopUp.Title:
                    Title = "Performance Title";
                    sb.Append("E.g. 1260 Plain Bob Minor or 5024 Spliced Surprise Major (7m)");
                    sb.Append("\n\n");
                    sb.Append("See Section 6.A of the Framework for Method Ringing for more information.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = "https://framework.cccbr.org.uk";
                    break;
                
                case PopUp.Detail:
                    Title = "Performance Detail";
                    sb.Append("E.g. for 7 extents of multi-method Minor: (1-2) Beverley S, Surfleet S; " +
                        "(3) London S, Wells S; (4-5) Kent TB; (6) Cambridge S; (7) Plain B");
                    sb.Append("\n\n");
                    sb.Append("E.g. for multi-method Surprise Major: 800 Lessness; 768 each Bristol, " +
                        "Cornwall, Superlative; 704 each Cambridge, Yorkshire; 512 London; 133 com; atw");
                    sb.Append("\n\n");
                    sb.Append("See Section 6.A of the Framework for Method Ringing for more information.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = "https://framework.cccbr.org.uk";
                    break;

                case PopUp.NumRingers:
                    Title = "Number of ringers";
                    sb.Append("Select the number of ringers who took part in the performance.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;

                case PopUp.BellsPerRinger:
                    Title = "Bells per ringer";
                    sb.Append("Select one of the options from the dropdown. The first option is usually for " +
                        "tower bell performances, and the second option is usually for handbell performances.");
                    sb.Append("\n\n");
                    sb.Append("If the performance didn't use one bell per ringer or two bells per ringer across " +
                        "all bells (e.g. an online performance " +
                        "might have had some people ringing one bell and other people ringing two bells), then " +
                        "select 'Other Configuration'. You will then be able to enter the bell(s) that each ringer " +
                        "rang.");
                    sb.Append("\n\n");
                    sb.Append("E.g. enter 1, 4 if a ringer rang bells 1 and 4, " +
                        "or enter 3-6 if a ringer rang bells 3, 4, 5 and 6.");
                    sb.Append("\n\n");
                    sb.Append("If two people rang one bell (e.g. a tenor rung with a strapper), " +
                        "enter the same bell number on two separate rows and enter one of the two ringers alongside " +
                        "each.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;
                
                case PopUp.AdditionalRingerInfo:
                    Title = "Additional ringer info";
                    sb.Append("Check this box to display an additional field per ringer, which can be used to enter " +
                        "information such as college, role, lodge, etc.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;

                case PopUp.ApproxLocation:
                    Title = "Approx location";
                    sb.Append("Usually entered as City/Town/Village and County/State/Country, as applicable.");
                    sb.Append("\n\n");
                    sb.Append("E.g. Andover, Hampshire or Boston, Massachusetts.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;

                case PopUp.RingerStyle:
                    Title = "Ringer style";
                    sb.Append("This box is for entering the style of an individual ringer when not all ringers " +
                        "in the band used the same style (i.e. a mixed style performance).");
                    sb.Append("\n\n");
                    sb.Append("See the information box for Style at the top of the page for more information.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;
                
                case PopUp.NewMethods:
                    Title = "New methods named";
                    sb.Append("Please enter the method name (excluding any class descriptors such as Bob or " +
                        "Surprise), place notation and stage for any new method(s) named in this performance.");
                    sb.Append("\n\n");
                    sb.Append("The requirements for naming a new method are in Section 5 " +
                        "of the Framework for Method Ringing.");
                    sb.Append("\n\n");
                    sb.Append("Place notation is described in Appendix A of the Framework.");
                    sb.Append("\n\n");
                    sb.Append("Then click the Validate button to check that your new method name is available " +
                        "and meets requirements. ");
                    sb.Append("If you receive error or warning messages that you are unclear about, the CC Methods " +
                        "Team will be pleased to assist you. ");
                    sb.Append("They can be reached by email at methods@cccbr.org.uk.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = "https://framework.cccbr.org.uk";
                    break;
                
                case PopUp.Norms:
                    Title = "Departures from Norms";
                    sb.Append("If the performance departed from any of the norms of method ringing as described in " +
                        "Section 6.C of the Framework for Method Ringing, please describe the departures in the box " +
                        "provided.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = "https://framework.cccbr.org.uk";
                    break;

                case PopUp.NewMethodResult:
                    Title = "New method validation results";
                    sb.Append($"Title: {NewMethod.Method.Title}");
                    sb.Append("\n");
                    sb.Append($"Place notation: {NewMethod.Method.PlaceNotation}");
                    sb.Append("\n");
                    sb.Append($"First leadhead: {NewMethod.Properties.LeadHead}");
                    sb.Append("\n");

                    if (string.IsNullOrEmpty(NewMethod.Properties.LeadheadCode))
                    {
                        sb.Append("Leadhead code: n/a");
                    }
                    else
                    {
                        sb.Append($"Leadhead code: {NewMethod.Properties.LeadheadCode}");
                    }
                    sb.Append("\n\n");

                    if (NewMethod.Messages.Count != 0)
                    {
                        foreach (var msg in NewMethod.Messages)
                        {
                            sb.Append($"{msg.Type}: {msg.message}");
                            sb.Append("\n");
                        }
                    }
                    else
                    {
                        sb.Append("No messages");
                        sb.Append("\n");
                    }

                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;

                case PopUp.Nickname:
                    Title = "Draft performance description";
                    sb.Append("This description will be used to identify the performance in the list of " +
                        "saved draft performances on the home page.");
                    sb.Append("\n\n");
                    sb.Append("If no description is entered, one will be automatically generated.");
                    Content = sb.ToString();
                    Image = string.Empty;
                    Link = string.Empty;
                    break;

                default:
                    break;
            }
        }
    }
}
