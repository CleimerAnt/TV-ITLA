

namespace Database.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string? NombreSerie { get; set; }
        public string? ImagenPortada { get; set; }
        public string? EnlaceVideo { get; set; }
         public int ProductoraId { get; set; }    
        public int GeneroId { get; set; }   
        public int? GeneroSecundarioId { get; set; } 


        //Propiedad de Navegacion  
       public Productora Productora { get; set; }
        public ICollection<Generos> Generos { get; set; }
    }
}
