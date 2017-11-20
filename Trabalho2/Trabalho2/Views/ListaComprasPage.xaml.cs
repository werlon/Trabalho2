using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Trabalho2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaComprasPage : ContentPage
    {
        private Compra _compra = null;

        public ObservableCollection<string> Items { get; set; }

        public ListaComprasPage()
        {
            InitializeComponent();

            ListarTodos();
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {

            var compra = new Compra
            {
                Cliente = Cliente.Text,
                CepEndereco = CepEndereco.Text
            };

            using (var dados = new CompraRepository())
            {
                if (_compra != null)
                {
                    _compra.Cliente = Cliente.Text;
                    _compra.CepEndereco = CepEndereco.Text;
                    dados.Update(_compra);
                }
                else
                {
                    if(Cliente != null)
                    {
                        _compra = new Compra
                        {
                            Cliente = Cliente.Text,
                            CepEndereco = CepEndereco.Text
                        };
                        dados.Insert(_compra);
                    }

                }

                LimparCampos();
                ListarTodos();
            }

        }

        private void Excluir_Clicked(object sender, EventArgs e)
        {
            _compra = Lista.SelectedItem as Compra;
            if (_compra != null)
            {
                using (var dados = new CompraRepository())
                {
                    dados.Delete(_compra);
                    ListarTodos();
                    LimparCampos();
                }
            }
        }

        private void Editar_Clicked(object sender, EventArgs e)
        {
            _compra = Lista.SelectedItem as Compra;
            if(_compra != null)
            {
                Cliente.Text = _compra.Cliente;
                CepEndereco.Text = _compra.CepEndereco;
            }
        }

        private async void AddProduto_Clicked(object sender, EventArgs e)
        {
            _compra = Lista.SelectedItem as Compra;
            if (_compra != null)
            {
                //await Navigation.PushAsync(new ListaPedidosPage(_compra.Id));

                await DisplayAlert("Compra " + _compra.Id, "Não consegui fazer funcionar o Picker para Implementar adição de pedidos na compra.", "OK");
                //direcionar para pagina de adicionar produtos passando a compra
            }
        }

        private void VerEnd_Clicked(object sender, EventArgs e)
        {
            _compra = Lista.SelectedItem as Compra;
            if (_compra != null)
            {
                Navigation.PushAsync(new MostrarEnderecoPage(_compra.CepEndereco));
                //direcionar para pagina de adicionar produtos passando a compra
            }
        }

        private void ListarTodos()
        {
            using (var dados = new CompraRepository())
            {
                Lista.ItemsSource = dados.Listar();
            }
        }

        private void LimparCampos()
        {
            Cliente.Text = "";
            CepEndereco.Text = "";
            _compra = null;
        }


    }
}
