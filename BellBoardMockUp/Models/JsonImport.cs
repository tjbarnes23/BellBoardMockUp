using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BellBoardMockUp.Models
{
    public class JsonImport
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public string GapTestSpec { get; set; }
    }
}
