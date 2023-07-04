using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage ="Erroraso")]
        public int MedicoId { get; set; }
        //PROP DE NAVEGACION
        public Medico? Medico { get; set; } = null!;
        [Required]
        public int PacienteId { get; set; }
        //PROP DE NAVEGACION
        public Paciente? Paciente { get; set; } = null!;
    }
}
/**
 * 
 * public class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; } // Required foreign key property
    public Blog Blog { get; set; } = null!; // Required reference navigation to principal
}
*/
