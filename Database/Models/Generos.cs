

namespace Database.Models
{
   public class Generos
    {
        public int Id { get; set; }
        public string? NombreGenero { get; set; }

        
        //Propiedad de Navegacion
       public ICollection<Series> Series { get; set; }
    }
}
