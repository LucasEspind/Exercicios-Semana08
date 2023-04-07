using Exercicios_Semana08_WebAPI.Interface;
using Exercicios_Semana08_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios_Semana08_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        IClienteServices _clienteServices;
        public TransacaoController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost]
        [Route("/Transacoes/AdicionarValor/{id}")]
        public ActionResult AicionarUmValor(int id, [FromBody] Transacao transacao)
        {
            if (_clienteServices.ExisteCliente(id))
            {
                _clienteServices.AdicionarSaldo(id, transacao);
                return Ok("Transação realizada!");
            }
            return BadRequest("Transação não autorizada!");
        }

        [HttpPost]
        [Route("/Transacoes/RetirarValor/{id}")]
        public ActionResult RetirarUmValor(int id, [FromBody] Transacao transacao)
        {
            if (_clienteServices.ExisteCliente(id))
            {
                _clienteServices.RetirarSaldo(id, transacao);
                return Ok("Transação realizada!");
            }
            return BadRequest("Transação não autorizada!");
        }

        [HttpGet]
        [Route("/Transacoes/{id}")]
        public ActionResult HistoricoTransacao(int id) {
            Clientes clientes = new();
            return Ok(_clienteServices.MostrarExtrato(id));
        }
    }
}
