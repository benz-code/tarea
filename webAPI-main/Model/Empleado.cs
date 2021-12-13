using System.ComponentModel.DataAnnotations;

namespace webAPI.Models

{

    public class Empleado

    {

        [Key]
        public int EmpleadoID {get; set;}
        public string fullname {get; set;}
        public string direccion {get; set;}
        public decimal salario {get; set;}
        public int BibliotecaID {get; set;}
        public Biblioteca BiliotecaID {get; set;}





    }

}