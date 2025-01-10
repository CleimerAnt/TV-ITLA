

namespace Database.Models
{
    public class Productora
    {
        public int Id { get; set; }
        public string? NombreProductora { get; set; } 


        //Propieda de Navegacion
        public Series Series { get; set; }
    }
}
