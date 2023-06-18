using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set;}
    }
}
