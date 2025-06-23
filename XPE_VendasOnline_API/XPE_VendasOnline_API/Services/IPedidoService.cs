using XPE_VendasOnline_API.Models;

namespace XPE_VendasOnline_API.Services
{
    public interface IPedidoService
    {
        List<Pedido> ObterTodos();
        Pedido ObterPorId(int id);
        List<Pedido> ObterPorNome(string nome);
        void Criar(Pedido pedido);
        void Atualizar(int id, Pedido pedido);
        void Deletar(int id);
        int Contar();
    }
}
