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
    public partial class MostrarEnderecoPage : ContentPage
    {
        public MostrarEnderecoPage(string cep)
        {
            InitializeComponent();
            CarregarDados(cep);
        }

        private async void CarregarDados(string cep)
        {
            Cep _cep = await Services.ConsultaCepService.BuscaCep(cep);
                Tcep.Text = _cep.cep;
                Tuf.Text = _cep.uf;
                Tcidade.Text = _cep.localidade;
                Tbairro.Text = _cep.bairro;
                Tlogradouro.Text = _cep.logradouro;

        }
    }
}