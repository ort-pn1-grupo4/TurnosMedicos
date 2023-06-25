using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedico { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression("^([A-Za-z]+ -)$", ErrorMessage = "solo se aceptan letras.")]
        public string Nombre { get; set; } 
        
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [RegularExpression("^([A-Za-z]+ -)$", ErrorMessage = "solo se aceptan letras.")]
        public string Apellido { get; set; }

        [Required]
        public Sexo Sexo{ get; set; }
        [Required]
        public Especialidad Especialidad {get; set; }
    }
}
