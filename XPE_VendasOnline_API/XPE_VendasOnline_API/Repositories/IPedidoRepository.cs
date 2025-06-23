using XPE_VendasOnline_API.Models;

namespace XPE_VendasOnline_API.Repositories
{
    public interface IPedidoRepository
    {
        List<Pedido> ObterTodos();
        Pedido ObterPorId(int id);
        List<Pedido> ObterPorNome(string nome);
        void Criar(Pedido pedido);
        void Atualizar(Pedido pedido);
        void Deletar(int id);
        int Contar();
    }
}
