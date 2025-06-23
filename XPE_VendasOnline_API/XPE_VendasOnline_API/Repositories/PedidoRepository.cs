using XPE_VendasOnline_API.Models;

namespace XPE_VendasOnline_API.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private static List<Pedido> _pedidos = new();

        public List<Pedido> ObterTodos()
        {
            return _pedidos;
        }

        public Pedido ObterPorId(int id)
        {
            return _pedidos.FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido> ObterPorNome(string nome)
        {
            return _pedidos.Where(p => p.Cliente.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Criar(Pedido pedido)
        {
            pedido.Id = _pedidos.Count > 0 ? _pedidos.Max(p => p.Id) + 1 : 1;
            pedido.DataPedido = DateTime.Now;
            _pedidos.Add(pedido);
        }

        public void Atualizar(Pedido pedido)
        {
            var existente = ObterPorId(pedido.Id);
            if (existente != null)
            {
                existente.Cliente = pedido.Cliente;
                existente.Produto = pedido.Produto;
                existente.Quantidade = pedido.Quantidade;
                existente.ValorTotal = pedido.ValorTotal;
                // DataPedido pode ou não ser atualizada
            }
        }

        public void Deletar(int id)
        {
            var pedido = ObterPorId(id);
            if (pedido != null)
            {
                _pedidos.Remove(pedido);
            }
        }

        public int Contar()
        {
            return _pedidos.Count;
        }
    }
}
