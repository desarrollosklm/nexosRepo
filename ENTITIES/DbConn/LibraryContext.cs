using ENTITIES.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENTITIES.DbConn
{
    public class LibraryContext: DbContext
    {
        public LibraryContext()
        {

        }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Editorial> Editorials { get; set; }

        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Configuracion usada para crear migracion en capa separada
                optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress;Database=LibraryNexosDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }
    }
}
