namespace ApiProdutos.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }

    public class ItemPedido
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}