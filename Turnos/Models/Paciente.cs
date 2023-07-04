using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Solo se aceptan letras.")]
        public string Nombre { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Solo se aceptan letras.")]
        public string Apellido { get; set; }

        [Required]
        [MinLength(8)]
        public string Dni { get; set; }

        [Required]
        public Sexo Sexo { get; set; }
    }
}
