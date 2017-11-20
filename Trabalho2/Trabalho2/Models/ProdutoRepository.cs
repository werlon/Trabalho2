using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;

namespace Trabalho2.Models
{
    class ProdutoRepository : IDisposable
    {
        private SQLiteConnection _conexao;

        public ProdutoRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "trabalho2.db3"));
            _conexao.CreateTable<Produto>();
        }

        public void Insert(Produto produto)
        {
            _conexao.Insert(produto);
        }

        public void Update(Produto produto)
        {
            _conexao.Update(produto);
        }

        public void Delete(Produto produto)
        {
            _conexao.Delete(produto);
        }

        public List<Produto> Listar()
        {
            return _conexao.Table<Produto>().OrderBy(p => p.Id).ToList();
        }

        public Produto ObterPorId(int id)
        {
            return _conexao.Table<Produto>().FirstOrDefault(p => p.Id == id);
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
