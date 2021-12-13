using Microsoft.EntityFrameworkCore;

using webAPI.Models;



namespace webAPI.Data

{

    public class DatabaseContext : DbContext

    {

        public DatabaseContext() { }

         

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base (options) {}

       



        public DbSet<Empleado> Empleados {get; set;}



        public DbSet<Biblioteca> Bibliotecas {get; set;}

    }

}