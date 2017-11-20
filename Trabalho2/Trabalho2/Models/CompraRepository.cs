using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;

namespace Trabalho2.Models
{
    class CompraRepository : IDisposable
    {
        private SQLiteConnection _conexao;

        public CompraRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "trabalho2.db3"));
            _conexao.CreateTable<Compra>();
        }

        public void Insert(Compra compra)
        {
            _conexao.Insert(compra);
        }

        public void Update(Compra compra)
        {
            _conexao.Update(compra);
        }

        public void Delete(Compra compra)
        {
            _conexao.Delete(compra);
        }

        public List<Compra> Listar()
        {
            return _conexao.Table<Compra>().OrderBy(p => p.Id).ToList();
        }

        public Compra ObterPorId(int id)
        {
            return _conexao.Table<Compra>().FirstOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
