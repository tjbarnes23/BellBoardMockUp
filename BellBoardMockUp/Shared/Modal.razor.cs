using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BellBoardMockUp.Shared
{
    public partial class Modal
    {
        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public bool ShowBackdrop = false;
        public string[,] Content = new string[10, 2];

        public Modal()
        {
            Populate();
        }

        [Parameter]
        public int PopUpNum { get; set; }

        public void Open()
        {
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

        protected void Populate()
        {
            StringBuilder sb = new StringBuilder();

            Content[0, 0] = "Bells per ringer";
            sb.Clear();
            sb.Append("If some ringers ring 1 bell and others ring 2 (or more) bells, " +
                "select 1 bell per ringer and enter the ringers' names for each bell. " +
                "BellBoard will merge the same ringer on adjacent bells.");
            Content[0, 1] = sb.ToString();

            Content[1, 0] = "Style";
            sb.Clear();
            sb.Append("Full circle is the usual style for tower bells (including dummy tower bells). " +
                "The bells are rung using a rope, wheel and pulley.");
            sb.Append("\n\n");
            sb.Append("Alternating strokes is the usual style for handbells (including dummy handbells). " +
                "The bells are retained in hand and rung with alternating upstrokes and downstrokes.");
            sb.Append("\n\n");
            sb.Append("Key presses usually refers to performances rung using a computer keyboard, " +
                "but it can also refer to a method ringing performance on an instrument such as a carillon.");
            sb.Append("\n\n");
            sb.Append("Other is for anything that doesn't fall into the above categories. " +
                "Please provide details in the 'Other Style' box that will appear.");
            Content[1, 1] = sb.ToString();

            Content[2, 0] = "Distributed performance";
            sb.Clear();
            sb.Append("A distributed performance is one where the ringers are located in different places.");
            sb.Append("\n\n");
            sb.Append("Instead of entering a place for the performance, the approximate location is entered " +
                "for each ringer.");
            Content[2, 1] = sb.ToString();

            Content[3, 0] = "Online performance";
            sb.Clear();
            sb.Append("An online performance is one that uses a computer platform such as Ringing Room or " +
                "Handbell Stadium to connect the ringers.");
            sb.Append("\n\n");
            sb.Append("Online performances are assumed to use simulated sound unless otherwise specified.");
            Content[3, 1] = sb.ToString();

            Content[4, 0] = "Tenor weight / size, note";
            sb.Clear();
            sb.Append("For tower bells this usually takes the form: 18–3–20 in E♭ where the weight is in " +
                "cwt-qtr-lb.");
            sb.Append("\n\n");
            sb.Append("For handbells, this usually takes the form: 13 in C♯ where 13 is the size used by handbell " +
                "manufacturers.");
            Content[4, 1] = sb.ToString();

            Content[5, 0] = "Online platform";
            sb.Clear();
            sb.Append("E.g. Ringing Room, Handbell Stadium, Muster, Ding.");
            Content[5, 1] = sb.ToString();

            Content[6, 0] = "Time taken";
            sb.Clear();
            sb.Append("Entered as hours:minutes, e.g. 3:05 or 0:42.");
            Content[6, 1] = sb.ToString();

            Content[7, 0] = "New methods named";
            sb.Clear();
            sb.Append("Please enter the method title and place notation for any new method named in this performance.");
            sb.Append("\n\n");
            sb.Append("The requirements for naming a new method are in Section 5 of the Framework for Method Ringing.");
            sb.Append("\n\n");
            sb.Append("Place notation is described in Appendix A of the Framework.");
            Content[7, 1] = sb.ToString();

            Content[8, 0] = "Departures from Norms";
            sb.Clear();
            sb.Append("If the performance departed from any of the norms of method ringing as described in " +
                "Section 6.C of the Framework for Method Ringing, please describe the departures in the box provided.");
            Content[8, 1] = sb.ToString();
        }
    }
}
