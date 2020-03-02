using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Entidades.DTO
{
    public class DTOCerveza
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Alcohol { get; set; }
        public int TipoId { get; set; }
        public string TipoCerveza { get; set; }
        public int PaisId { get; set; }
        public string Pais { get; set; }
    }
}
