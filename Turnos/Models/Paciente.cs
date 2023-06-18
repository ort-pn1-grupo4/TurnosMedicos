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
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required] 
        public string Dni { get; set; }

        [Required]
        public Sexo Sexo { get; set; }
    }
}
