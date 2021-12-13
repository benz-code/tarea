using System.ComponentModel.DataAnnotations;

namespace webAPI.Models

{

    public class Biblioteca

    {

        [Key]
        public int BibliotecaID {get; set;}
        public string Libro {get; set;}
        public string CategoriaLibro {get; set;}
        public string NombreAutor {get; set;}
        public string FechaDeLanzamiento {get; set;}
        public string ISBN {get; set;}





    }

}