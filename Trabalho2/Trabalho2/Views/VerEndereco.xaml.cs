using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trabalho2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerEndereco : ViewCell
    {
        public VerEndereco(string cep)
        {
            InitializeComponent();

            CarregarDados(cep);
        }

        private async void CarregarDados(string cep)
        {
            Cep _cep = await Services.ConsultaCepService.BuscaCep(cep);
            if(_cep != null)
            {
                Tcep.Text = _cep.cep.ToString();
                Tuf.Text = _cep.uf.ToString();
                Tcidade.Text = _cep.localidade.ToString();
                Tbairro.Text = _cep.bairro.ToString();
                Tlogradouro.Text = _cep.logradouro.ToString();
            }
            else
            {
                lblResultado.Text = "O CEP é invalido";
                lblResultado.TextColor = Color.Red;
            }
            
        }


    }
}