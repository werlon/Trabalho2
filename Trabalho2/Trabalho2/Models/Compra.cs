using SQLite.Net.Attributes;
namespace Trabalho2.Models
{
    [Table("Compra")]
    class Compra
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Cliente { get; set; }

        [MaxLength(10)]
        public string CepEndereco { get; set; }

        private string endereco { get; set; }

        public override string ToString()
        {
            string endereco = "Faltou CEP";
            if(CepEndereco != null)
            {
                buscaEndereco();
            }
            return string.Format("Id=[{0}], Cliente={1}, Endereco={2}", Id, Cliente, CepEndereco);
        }

        private async void buscaEndereco()
        {
            Cep cep = await Services.ConsultaCepService.BuscaCep(CepEndereco);
            endereco = cep.ToString();
        }

    }
}
