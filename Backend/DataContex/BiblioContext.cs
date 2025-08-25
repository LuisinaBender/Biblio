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
            }
        }
    }
}
