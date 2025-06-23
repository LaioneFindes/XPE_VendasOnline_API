namespace XPE_VendasOnline_API.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
