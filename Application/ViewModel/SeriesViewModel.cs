using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string NombreSerie { get; set; }
        public string ImagenPortada { get; set; }
        public string ElanceVideo { get; set; }
        public int ProductoraId { get; set; }
        public int GeneroId { get; set; }

        //Propiedades de las Relaciones
        public string ProductoraNombre { get; set; }
        public string GeneroNombre { get; set; }    
        public string GeneroSecundario { get; set; }

    }
}
