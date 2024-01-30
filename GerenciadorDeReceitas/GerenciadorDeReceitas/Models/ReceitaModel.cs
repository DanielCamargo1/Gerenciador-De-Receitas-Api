using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeReceitas.Models
{
    public class ReceitaModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="A receita nessecita de um nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A receita nessecita conter ingredientes")]
        public string Ingredientes { get; set; }
        [Required(ErrorMessage = "A receita nessecita deixar explicito o modo de preparo")]
        public string ModoDePreparo { get; set; }
        public string DicasParaReceita { get; set; }
    }
}
