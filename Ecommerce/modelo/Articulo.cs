using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace modelo
{
    public class Articulo {
        public int Id { get; set; }
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { set; get; }
        public Categoria Categoria { get; set; }
        public string ImagenUrl { get; set; }
        public double Precio { get; set; }
    
    }
}
