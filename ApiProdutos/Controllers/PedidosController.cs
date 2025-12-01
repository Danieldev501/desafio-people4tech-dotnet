using ApiProdutos.Models;
using ApiProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Pedido pedido)
        {
            if (string.IsNullOrEmpty(pedido.NomeCliente) || pedido.Itens == null || pedido.Itens.Count == 0)
            {
                return BadRequest("Dados inválidos para o pedido.");
            }

            try
            {
                var criado = _pedidoService.Criar(pedido);
                return Ok(criado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}