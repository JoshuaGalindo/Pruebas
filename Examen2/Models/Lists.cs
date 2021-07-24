using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Models
{
    public class Lists
    {
        [Key]
        [Display(Name = "No.")]
        public int ListId{ get; set; }
        [Display(Name = "Nombre:")]
        public string ListName { get; set; }


    }


}
