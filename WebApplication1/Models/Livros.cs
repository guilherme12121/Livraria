using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Livros
    {
        [Key]
        public int LivroId { get; set; }
        public string LivroNome { get; set; }
        public string Anodaedição { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Idioma { get; set; }
        public string Numerodepagina { get; set; }
    }
}
