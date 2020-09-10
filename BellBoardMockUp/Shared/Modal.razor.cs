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
        public string[,] Content = new string[11, 2];

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
            sb.Append("Key presses usually refers to online performances 'rung' using a computer keyboard, " +
                "but it can also refer to a method ringing performance on an instrument such as a carillon.");
            sb.Append("\n\n");
            sb.Append("Other is for anything that doesn't fall into the above categories. " +
                "Please provide details in the 'Other Style' box that will appear.");
            sb.Append("\n\n");
            sb.Append("If different ringers use different styles in the same performance (e.g. in a Ringing Room " +
                "performance, some ringers use dummy handbells and others use key presses), " +
                "please select 'Other' and specify who did what in the 'Other Style' box that will appear.");
            Content[1, 1] = sb.ToString();

            Content[2, 0] = "Distributed";
            sb.Clear();
            sb.Append("A distributed performance is one where the ringers are located in different places.");
            sb.Append("\n\n");
            sb.Append("Instead of entering a place for the performance, the approximate location is entered " +
                "for each ringer.");
            Content[2, 1] = sb.ToString();
            
            Content[3, 0] = "Tenor info";
            sb.Clear();
            sb.Append("For tower bells, this is usually entered in the form 18–3–20 in E♭, where the weight is in " +
                "cwt-qtr-lb.");
            sb.Append("\n\n");
            sb.Append("For handbells, this is usually entered in the form 13 in C♯, where 13 is the size used " +
                "by handbell manufacturers.");
            sb.Append("\n\n");
            sb.Append("If the performance was rung on a computer platform such as Ringing Room or Handbell Stadium, " +
                "then leave this box blank.");
            Content[3, 1] = sb.ToString();

            Content[4, 0] = "Platform";
            sb.Clear();
            sb.Append("If the performance was rung on a computer platform, enter the name of the platform such as " +
                "Ringing Room, Handbell Stadium, Muster, Ding, Abel, Mobel.");
            sb.Append("\n\n");
            sb.Append("Otherwise, leave this box blank.");
            Content[4, 1] = sb.ToString();

            Content[5, 0] = "Time taken";
            sb.Clear();
            sb.Append("Entered as hours:minutes, e.g. 3:05 or 0:42.");
            Content[5, 1] = sb.ToString();

            Content[6, 0] = "Performance Title";
            sb.Clear();
            sb.Append("E.g. 1260 Plain Bob Minor or 5152 Spliced Surprise Major (7m)");
            sb.Append("\n\n");
            sb.Append("See Section 6.A of the Framework for more information.");
            Content[6, 1] = sb.ToString();

            Content[7, 0] = "Performance Detail";
            sb.Clear();
            sb.Append("E.g. for 7 extents of multi-method Minor: (1-2) Beverley S, Surfleet S; (3) London S, Wells S; " +
                "(4-5) Kent TB; (6) Cambridge S; (7) Plain B");
            sb.Append("\n\n");
            sb.Append("E.g. for multi-method Surprise Major: 640 each Bristol, Pudsey, Rutland, Superlative, " +
                "Yorkshire; 608 each Cambridge, Lincolnshire, London; 120 com; atw");
            sb.Append("\n\n");
            sb.Append("See Section 6.A of the Framework for more information.");
            Content[7, 1] = sb.ToString();

            Content[8, 0] = "Additional ringer-level info";
            sb.Clear();
            sb.Append("Check this box to display an additional field per ringer, which can be used to enter " +
                "information such as college, role, lodge, etc.");
            Content[8, 1] = sb.ToString();

            Content[9, 0] = "New methods named";
            sb.Clear();
            sb.Append("Please enter the method title and place notation for any new method named in this performance.");
            sb.Append("\n\n");
            sb.Append("The requirements for naming a new method are in Section 5 of the Framework for Method Ringing.");
            sb.Append("\n\n");
            sb.Append("Place notation is described in Appendix A of the Framework.");
            Content[9, 1] = sb.ToString();

            Content[10, 0] = "Departures from Norms";
            sb.Clear();
            sb.Append("If the performance departed from any of the norms of method ringing as described in " +
                "Section 6.C of the Framework for Method Ringing, please describe the departures in the box provided.");
            Content[10, 1] = sb.ToString();
        }
    }
}
