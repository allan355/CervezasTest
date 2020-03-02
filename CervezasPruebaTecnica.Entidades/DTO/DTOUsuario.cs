using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Entidades.DTO
{
    public class DTOUsuario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        [Required]
        public string Alias { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public int TipoUsuarioId { get; set; }
        public bool Admin { get; set; }
    }
}
