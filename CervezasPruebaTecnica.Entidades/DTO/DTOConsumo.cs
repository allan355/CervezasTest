using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezasPruebaTecnica.Entidades.DTO
{
    public class DTOConsumo
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Alias { get; set; }
        public string CantidadMarca { get; set; }
        public string CantidadTotal { get; set; }
        public decimal Alcohol { get; set; }
        public int Cantidad { get; set; }
        public string TipoCerveza { get; set; }
        public string Pais { get; set; }
    }
}
