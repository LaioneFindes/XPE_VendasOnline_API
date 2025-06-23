using XPE_VendasOnline_API.Models;
using XPE_VendasOnline_API.Repositories;

namespace XPE_VendasOnline_API.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public List<Pedido> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public Pedido ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public List<Pedido> ObterPorNome(string nome)
        {
            return _repository.ObterPorNome(nome);
        }

        public void Criar(Pedido pedido)
        {
            _repository.Criar(pedido);
        }

        public void Atualizar(int id, Pedido pedido)
        {
            var existente = _repository.ObterPorId(id);
            if (existente != null)
            {
                pedido.Id = id;
                _repository.Atualizar(pedido);
            }
        }

        public void Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public int Contar()
        {
            return _repository.Contar();
        }
    }
}
