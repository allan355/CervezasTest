using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Entidades.DTO
{
    public class DTOHistoricoCerveza
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CervezaId { get; set; }
        public int Consumo { get; set; }
    }
}
