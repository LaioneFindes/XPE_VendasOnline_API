using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XPE_VendasOnline_API.Models;
using XPE_VendasOnline_API.Services;

namespace XPE_VendasOnline_API.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // POST: adicionar
        [HttpPost("add")]
        public IActionResult Create([FromBody] Pedido pedido)
        {
            _pedidoService.Criar(pedido);
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        // PUT: atualizar
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pedido pedido)
        {
            var existente = _pedidoService.ObterPorId(id);
            if (existente == null)
                return NotFound($"Pedido com ID {id} não encontrado.");

            _pedidoService.Atualizar(id, pedido);
            return NoContent();
        }

        // DELETE: deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _pedidoService.ObterPorId(id);
            if (existente == null)
                return NotFound($"Pedido com ID {id} não encontrado.");

            _pedidoService.Deletar(id);
            return NoContent();
        }

        //GET: listar - Find By All
        [HttpGet("list")]
        public ActionResult<List<Pedido>> GetAll()
        {
            return Ok(_pedidoService.ObterTodos());
        }

        //GET - buscar por id - find by id
        [HttpGet("{id}")]
        public ActionResult<Pedido> GetById(int id)
        {
            var pedido = _pedidoService.ObterPorId(id);
            if (pedido == null)
                return NotFound($"Pedido com ID {id} não encontrado.");
            return Ok(pedido);
        }

        //GET - buscar por nome - find by name
        [HttpGet("{nome}")]
        public ActionResult<List<Pedido>> GetByNome(string nome)
        {
            var pedidos = _pedidoService.ObterPorNome(nome);
            return Ok(pedidos);
        }

        // GET: contagem de registros
        [HttpGet("count")]
        public ActionResult<int> GetCount()
        {
            return Ok(_pedidoService.Contar());
        }

        
    }
}
