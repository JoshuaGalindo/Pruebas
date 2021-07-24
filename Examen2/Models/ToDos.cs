using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Models
{
    public class ToDo
    {
        [Key]
        [Display(Name = "No.")]
        public int TareaId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [StringLength(30, ErrorMessage = "No debe tener más de 30 caracteres.")]
        [MinLength(3, ErrorMessage = "Debe tener más de 3 caracteres.")]
        public string TareaName { get; set; }

        [Display(Name = "fecha de inicio:")]
        [Required(ErrorMessage = "la fecha es obligatoria")]
        public DateTime TareaFechaInicio { get; set; }

        [Display(Name = "fecha de finalización")]
        [Required(ErrorMessage = "la fecha es obligatoria")]
        public DateTime TareaFechaFinal { get; set; }

        [Display(Name = "Tipo de lista")]
        [Required(ErrorMessage = "la lista es obligatoria")]
        public String TareaTipoLista { get; set; }

        [Display(Name = "Terminada")]
        public Boolean TareaTerminada { get; set; }

    }
}
