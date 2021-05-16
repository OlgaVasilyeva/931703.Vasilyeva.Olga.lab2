using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend2.Models
{
    public class NumberViewModel
    {
        [Required(ErrorMessage = "First operand is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Second operand is required")]
        public String Name1 { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public String Opt { get; set; }
    }
}
