using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaPrimeiraAPI.model
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }

        public Produto() { }
        public Produto(string nome, decimal preco)
        {
            this.nome = nome;
            this.preco = preco;
        }
    }
}