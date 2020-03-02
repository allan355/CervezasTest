using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Entidades.DTO
{
    public class DTORespuesta<T>
    {
        public string Mensaje { get; set; }
        public T Entidad { get; set; }
        public List<T> Datos { get; set; }

    }
    public class DTOPeticion<T>
    {
        [Required]
        public T Entidad { get; set; }

    }
}
