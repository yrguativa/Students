using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.API.Models
{
    public class Curse
    {
        public int Id { get; set; }

        [Display( Name ="Curso")]
        public string Course { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(80,
            ErrorMessage = "El campo {0} puede contener un máximo de {1} y un mínimo de {2} caracteres",
            MinimumLength = 3)]
        public List<Student> Students { get; set; }
    }
}