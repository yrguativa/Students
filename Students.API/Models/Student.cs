using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.API.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(80,
            ErrorMessage = "El campo {0} puede contener un máximo de {1} y un mínimo de {2} caracteres",
            MinimumLength = 3)]
        public string Names { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(80,
            ErrorMessage = "El campo {0} puede contener un máximo de {1} y un mínimo de {2} caracteres",
            MinimumLength = 3)]
        public string Surnames { get; set; }

        [Display(Name = "Tipo de identificación")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(2,
            ErrorMessage = "El campo {0} puede contener un mínimo de {2} caracteres",
            MinimumLength = 2)]
        public string IdentificationType { get; set; }

        [Display(Name = "Número de identificación")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(15,
            ErrorMessage = "El campo {0} puede contener un máximo de {1} y un mínimo de {2} caracteres",
            MinimumLength = 6)]
        public string IdentificationNumber { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime BirthDate { get; set; }

        [JsonIgnore]
        public List<Curse> Curses { get; set; }
    }
}