using SQLite.Net.Attributes;

namespace Trabalho2.Models
{
    [Table("Pedido")]
    class Pedido
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(11)]
        public int CompraId { get; set; }

        [MaxLength(11)]
        public int ProdutoId { get; set; }

        [MaxLength(11)]
        public int Quantidade { get; set; }

        [MaxLength(11)]
        public float Total { get; set; }

        public override string ToString()
        {
            ProdutoRepository pr = new ProdutoRepository();
            Produto p = pr.ObterPorId(ProdutoId);

            return string.Format("Id=[{0}], Produto={1}, Qtd={2}, Total={3}", Id, p.Nome, Quantidade, Total);
        }
    }
}
