using Trabalho2.Models;
using Trabalho2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trabalho2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutosPage : ContentPage
    {
       // private Produto _produto = null;

        public Produto ProdutoEdicao { get; set; }

        public ListaProdutosPage()
        {
            InitializeComponent();

            BindingContext = new ProdutosViewModel();

            //ListarTodos();
        }
        /*
        private void Salvar_Clicked(object sender, EventArgs e)
        {
            var produto = new Produto
            {
                Nome = Nome.Text,
                Valor = float.Parse(Valor.Text)
            };

            //se der problema de conversao usar System.Globalization.CultureInfo.InvariantCulture apos valor.Text,

            using (var dados = new ProdutoRepository())
            {
                if(_produto != null)
                {
                    _produto.Nome = Nome.Text;
                    _produto.Valor = float.Parse(Valor.Text);
                    dados.Update(_produto);
                }
                else
                {
                    if(Nome != null && Valor != null)
                    {
                        _produto = new Produto
                        {
                            Nome = Nome.Text,
                            Valor = float.Parse(Valor.Text)
                        };
                        dados.Insert(_produto);
                    }
                }

                LimparCampos();
                ListarTodos();
            }
        }

        private void Excluir_Clicked(object sender, EventArgs e)
        {
            _produto = Lista.SelectedItem as Produto;
            if(_produto != null)
            {
                using (var dados = new ProdutoRepository())
                {
                    dados.Delete(_produto);
                    ListarTodos();
                    LimparCampos();
                }
            }

        }

        private void Editar_Clicked(object sender, EventArgs e)
        {
            _produto = Lista.SelectedItem as Produto;
            if(_produto != null)
            {
                Nome.Text = _produto.Nome;
                Valor.Text = string.Format("{0}",_produto.Valor);
            }
        }

        private void LimparCampos()
        {
            Nome.Text = "";
            Valor.Text = "";
            _produto = null;
        }

        private void ListarTodos()
        {
            using (var dados = new ProdutoRepository())
            {
                Lista.ItemsSource = dados.Listar();
            }
        } */

    }
}
