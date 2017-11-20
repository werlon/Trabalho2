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
    public partial class ListaPedidosPage : ContentPage
    {

        private Pedido _pedido = null;
        private int IdDessaCompra = 0;

        public ListaPedidosPage(int IdDaCompra)
        {
            InitializeComponent();
            NumeroCompra.Text = IdDaCompra.ToString();
            IdDessaCompra = IdDaCompra;
            CarregarPedidos();

        }

        private void CarregarPicker() {
            //picker dos produtos
            using (var dados = new ProdutoRepository())
            {
                ListaProdutos.ItemsSource = dados.Listar().ToList();
            }
        }



        private void CarregarPedidos()
        {
            if (IdDessaCompra > 0)
            {
                using (var dados = new PedidoRepository())
                {
                    Lista.ItemsSource = dados.ListarPorIdDaCompra(IdDessaCompra);
                }
            }
        }

        private void Adicionar_Clicked(object sender, EventArgs e)
        {
            Produto produto = ListaProdutos.SelectedItem as Produto;
            var pedido = new Pedido
            {
                CompraId = IdDessaCompra,
                ProdutoId = produto.Id,
                Quantidade = int.Parse(TQuantidade.Text),
                Total = (int.Parse(TQuantidade.Text) * produto.Valor)
            };

            using (var dados = new PedidoRepository())
            {
                if(TQuantidade != null && ListaProdutos.SelectedItem != null)
                {
                    _pedido = new Pedido
                    {
                        CompraId = IdDessaCompra,
                        ProdutoId = produto.Id,
                        Quantidade = int.Parse(TQuantidade.Text),
                        Total = (int.Parse(TQuantidade.Text) * produto.Valor)
                    };
                    dados.Insert(_pedido);
                }
                LimparCampos();
                CarregarPedidos();
            }
        }

        private void Remover_Clicked(object sender, EventArgs e)
        {
            _pedido = Lista.SelectedItem as Pedido;
            if(_pedido != null)
            {
                using(var dados = new PedidoRepository())
                {
                    dados.Delete(_pedido);
                    LimparCampos();
                    CarregarPedidos();
                }
            }

        }

        private void LimparCampos() {
            TQuantidade.Text = "";
            CarregarPicker();
            _pedido = null;
        }

    
    }
}
