using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho2.Models
{
    class Cep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }

        public override string ToString()
        {
            return string.Format(" CEP=[{0}], Bairro={1}, Cidade={2} - Uf={3}", cep, bairro, localidade, uf);
        }
    }

    
}
    