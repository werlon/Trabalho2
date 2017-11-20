using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;

namespace Trabalho2.Models
{
    class PedidoRepository : IDisposable
    {
        private SQLiteConnection _conexao;

        public PedidoRepository()
        {
            var config = DependencyService.Get<IConfig>();
            _conexao = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "trabalho2.db3"));
            _conexao.CreateTable<Pedido>();
        }

        public void Insert(Pedido pedido)
        {
            _conexao.Insert(pedido);
        }

        public void Update(Pedido pedido)
        {
            _conexao.Update(pedido);
        }

        public void Delete(Pedido pedido)
        {
            _conexao.Delete(pedido);
        }

        public List<Pedido> Listar(Pedido pedido)
        {
            return _conexao.Table<Pedido>().OrderBy(p => p.Id).ToList();
        }

        public Pedido ObterPorId(int id)
        {
            return _conexao.Table<Pedido>().FirstOrDefault(c => c.Id == id);
        }

        public List<Pedido> ListarPorIdDaCompra(int idCompra)
        {
            return _conexao.Table<Pedido>().Where(p => p.CompraId == idCompra).OrderBy(p => p.Id).ToList();
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}
