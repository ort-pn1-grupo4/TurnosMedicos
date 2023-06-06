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
        public string Nombre { get; set; }
        
        [Required]
        public string Apellido { get; set; }
    }
}
