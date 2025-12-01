using ApiProdutos.Models;
using System;
using System.Collections.Generic;

namespace ApiProdutos.Services
{
    public class PedidoService
    {
        private readonly ProdutoService _produtoService;
        private List<Pedido> _pedidos = new List<Pedido>();
        private int _nextId = 1;

        public PedidoService(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public Pedido Criar(Pedido pedido)
        {
            // Verifica estoque
            foreach (var item in pedido.Itens)
            {
                var produto = _produtoService.ObterPorId(item.ProdutoId);
                if (produto == null || produto.QuantidadeEmEstoque < item.Quantidade)
                {
                    throw new Exception($"Estoque insuficiente para o produto {item.ProdutoId}.");
                }
            }

            // Diminui estoque
            foreach (var item in pedido.Itens)
            {
                _produtoService.DiminuirEstoque(item.ProdutoId, item.Quantidade);
            }

            pedido.Id = _nextId++;
            _pedidos.Add(pedido);
            return pedido;
        }
    }
}