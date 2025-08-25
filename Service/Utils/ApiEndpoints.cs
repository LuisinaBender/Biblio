using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utils
{
    public static class ApiEndpoints
    {
        public static string Libro { get; set; } = "libros";
        public static string Editorial { get; set; } = "editoriales";
        public static string Autor { get; set; } = "autorres";
        public static string Ejemplar { get; set; } = "ejemplares";
        public static string Carrera { get; set; } = "carreras";
        public static string Genero { get; set; } = "generos";
        public static string Prestamo { get; set; } = "prestamos";
        public static string Usuario { get; set; } = "usuarios";
        public static string LibroAutor { get; set; } = "libroautores";
        public static string LibroGenero { get; set; } = "librogeneros";
        public static string UsuarioCarrera { get; set; } = "usuariocarreras";
        public static string Gemini { get; set; } = "gemini";



        public static string GetEndpoint(string name)
        {
            return name switch
            {
                nameof(Libro) => Libro,
                nameof(Editorial) => Editorial,
                nameof(Autor) => Autor,
                nameof(Ejemplar) => Ejemplar,
                nameof(Carrera) => Carrera,
                nameof(Genero) => Genero,
                nameof(Prestamo) => Prestamo,
                nameof(Usuario) => Usuario,
                nameof(LibroAutor) => LibroAutor,
                nameof(LibroGenero) => LibroGenero,
                nameof(UsuarioCarrera) => UsuarioCarrera,
                nameof(Gemini) => Gemini,
                _ => throw new ArgumentException($"Endpoint '{name}' no está definido.")
            };
        }
    }
}
