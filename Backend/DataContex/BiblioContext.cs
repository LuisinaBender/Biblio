using Microsoft.EntityFrameworkCore;
using Service;
using Service.Models;


namespace Backend.DataContex
{
    public class BiblioContext : DbContext
    {
        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Editorial> Editoriales { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<LibroGenero> LibroGeneros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioCarrera> UsuarioCarreras { get; set; }
        public virtual DbSet<Ejemplar> Ejemplares { get; set; }
        public virtual DbSet<LibroAutor> LibroAutores { get; set; }



        public BiblioContext(DbContextOptions<BiblioContext> options) : base(options)
        {

        }

        // onConfiguring is not needed because we are using dependency injection to pass the options

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
                var connectionString = configuration.GetConnectionString("mysqlRemoto");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Datos semillas de 10 Autores
            //Datos semillas de 10 autores
            modelBuilder.Entity<Autor>().HasData(
                new Autor { id = 1, nombre = "Gabriel García Márquez" },
                new Autor { id = 2, nombre = "Isabel Allende" },
                new Autor { id = 3, nombre = "Mario Vargas Llosa" },
                new Autor { id = 4, nombre = "Jorge Luis Borges" },
                new Autor { id = 5, nombre = "Pablo Neruda" },
                new Autor { id = 6, nombre = "Julio Cortázar" },
                new Autor { id = 7, nombre = "Carlos Fuentes" },
                new Autor { id = 8, nombre = "Laura Esquivel" },
                new Autor { id = 9, nombre = "Roberto Bolaño" },
                new Autor { id = 10, nombre = "Cecilia Meireles" }
              
            );
            #endregion

            #region Datos semillas de 10 Generos
            modelBuilder.Entity<Genero>().HasData(
                new Genero { id = 1, nombre = "Novela" },
                new Genero { id = 2, nombre = "Poesía" },
                new Genero { id = 3, nombre = "Cuento" },
                new Genero { id = 4, nombre = "Ensayo" },
                new Genero { id = 5, nombre = "Teatro" },
                new Genero { id = 6, nombre = "Fantasía" },
                new Genero { id = 7, nombre = "Ciencia Ficción" },
                new Genero { id = 8, nombre = "Misterio" },
                new Genero { id = 9, nombre = "Romance" },
                new Genero { id = 10, nombre = "Aventura" }
            );
            #endregion

            #region Datos semillas de 10 Editoriales
            modelBuilder.Entity<Editorial>().HasData(
                new Editorial { id = 1, nombre = "Penguin Random House" },
                new Editorial { id = 2, nombre = "HarperCollins" },
                new Editorial { id = 3, nombre = "Simon & Schuster" },
                new Editorial { id = 4, nombre = "Hachette Book Group" },
                new Editorial { id = 5, nombre = "Macmillan Publishers" },
                new Editorial { id = 6, nombre = "Scholastic" },
                new Editorial { id = 7, nombre = "Bloomsbury Publishing" },
                new Editorial { id = 8, nombre = "Oxford University Press" },
                new Editorial { id = 9, nombre = "Cambridge University Press" },
                new Editorial { id = 10, nombre = "Wiley" }
            );
            #endregion

            //Configuramos los query filters para que no traiga los registros marcados como eliminados
            modelBuilder.Entity<Autor>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Genero>().HasQueryFilter(g => !g.IsDeleted);
            modelBuilder.Entity<Editorial>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Libro>().HasQueryFilter(l => !l.IsDeleted);
            modelBuilder.Entity<Carrera>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Prestamo>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Ejemplar>().HasQueryFilter(ej => !ej.IsDeleted);
            modelBuilder.Entity<UsuarioCarrera>().HasQueryFilter(uc => !uc.IsDeleted);
            modelBuilder.Entity<LibroAutor>().HasQueryFilter(la => !la.IsDeleted);
            modelBuilder.Entity<LibroGenero>().HasQueryFilter(lg => !lg.IsDeleted);

        }
    }
}
