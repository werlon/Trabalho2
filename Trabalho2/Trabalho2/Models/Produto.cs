using SQLite.Net.Attributes;

namespace Trabalho2.Models
{
    [Table("Produto")]
    class Produto
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(10)]
        public float Valor { get; set; }

        public override string ToString()
        {
            return string.Format("Id=[{0}],Nome={1}, Valor=R$ {2}", Id, Nome, Valor);
        }
    }
}
