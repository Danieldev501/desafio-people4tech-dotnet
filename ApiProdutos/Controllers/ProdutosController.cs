using ApiProdutos.Models;
using ApiProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome) || produto.Preco <= 0 || produto.QuantidadeEmEstoque < 0)
            {
                return BadRequest("Dados inválidos para o produto.");
            }

            var adicionado = _produtoService.Adicionar(produto);
            return Ok(adicionado);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_produtoService.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Consultar(int id)
        {
            var produto = _produtoService.ObterPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }
            return Ok(produto);
        }
    }
}