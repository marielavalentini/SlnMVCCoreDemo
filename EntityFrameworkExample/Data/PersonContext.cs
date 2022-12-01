using EntityFrameworkExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExample.Data
{

    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OPCIONAL PARA INICIALIZAR DATOS EN LA BASE DE DATOS
            //INICIALIZA LA TABLA PERSONA CON DOS INSTANCIAS

            modelBuilder.Entity<Person>().HasData(
               new Person
               {
                   PersonId = 1,
                   FirstName = "Tara",
                   LastName = "Brewer",
                   City = "Ocala",
                   Address = "317 Long Street"
               },
               new Person
               {
                   PersonId = 2,
                   FirstName = "Andrew",
                   LastName = "Tippett",
                   City = "Anaheim",
                   Address = "3163 Nickel Road"
               });
        }
    }
}

