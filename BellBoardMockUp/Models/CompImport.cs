﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Models
{
    public class CompImport
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ComposerDetails[] ComposerDetails { get; set; }

        public string MethodDetails { get; set; }
    }

    public class ComposerDetails
    {
        public string Role { get; set; }

        public string Name { get; set; }
    }
}
