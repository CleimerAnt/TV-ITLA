using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.PostAndEditViewModel
{
    public class SeriesPostAndEditViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="El Nombre es Requerido")]
        public string NombreSerie { get; set; }
        [Required(ErrorMessage = "La Imagen de Portada es Requerida")]
        public string ImagenPortada { get; set; }
        [Required(ErrorMessage = "El Enlace del Video es Requerido")]

        public string EnlaceVideo { get; set; }
        [Required(ErrorMessage = "La Productora es Requerida")]
        [Range (1,int.MaxValue, ErrorMessage = "Debe Seleccionar una Productora")]

        public int ProductoraID { get; set; }
        [Required(ErrorMessage = "El Genero es Requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar un Genero primario")]
        public int GeneroId { get; set; }
       
        public int? GeneroSecundarioId { get; set; }
    }
}
