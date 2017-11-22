using System.Collections.ObjectModel;
using Trabalho2.Models;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;

namespace Trabalho2.ViewModels
{
    class ProdutosViewModel : INotifyPropertyChanged
    {
        public Produto ProdutoAtual { get; set; }
        public Command SalvarProdutoCommand { get; set; }
        public Command ExcluirProdutoCommand { get; set; }
        public Command EditarProdutoCommand { get; set; }
        public ObservableCollection<Produto> Produtos { get; set; }

        public ProdutosViewModel()
        {
            //Title = "Produtos";
            ProdutoAtual = new Produto();
            Produtos = new ObservableCollection<Produto>(new ProdutoRepository().Listar());

            SalvarProdutoCommand = new Command(SalvarProduto);
            ExcluirProdutoCommand = new Command<Produto>(ExcluirProduto);
            EditarProdutoCommand = new Command<Produto>(EditarProduto);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SalvarProduto()
        {
            if (ProdutoAtual.Id == 0)
            {
                new ProdutoRepository().Insert(ProdutoAtual);
                Produtos.Add(ProdutoAtual);
                ProdutoAtual = new Produto();
                OnPropertyChanged("ProdutoAtual");
            }
            else
            {
                new ProdutoRepository().Update(ProdutoAtual);
                Produtos = new ObservableCollection<Produto>(new ProdutoRepository().Listar());
                OnPropertyChanged("Produtos");
                ProdutoAtual = new Produto();
                OnPropertyChanged("ProdutoAtual");
            }
        }

        private void ExcluirProduto(Produto produto)
        {
            new ProdutoRepository().Delete(produto);
            Produtos.Remove(produto);
        }

        private void EditarProduto(Produto produto)
        {
            ProdutoAtual = produto;
            OnPropertyChanged("ProdutoAtual");
        }
        
    }
}
