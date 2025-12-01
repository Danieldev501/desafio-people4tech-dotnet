using ApiProdutos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProdutos.Services
{
    public class ProdutoService
    {
        private List<Produto> _produtos = new List<Produto>();
        private int _nextId = 1;

        public Produto Adicionar(Produto produto)
        {
            produto.Id = _nextId++;
            _produtos.Add(produto);
            return produto;
        }

        public List<Produto> Listar()
        {
            return _produtos;
        }

        public Produto ObterPorId(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public bool DiminuirEstoque(int id, int quantidade)
        {
            var produto = ObterPorId(id);
            if (produto != null && produto.QuantidadeEmEstoque >= quantidade)
            {
                produto.QuantidadeEmEstoque -= quantidade;
                return true;
            }
            return false;
        }
    }
}