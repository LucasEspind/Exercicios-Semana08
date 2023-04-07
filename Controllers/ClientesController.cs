using Microsoft.AspNetCore.Mvc;
using Exercicios_Semana08_WebAPI.Models;
using Exercicios_Semana08_WebAPI.Services;
using Exercicios_Semana08_WebAPI.Interface;

namespace Exercicios_Semana08_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        IClienteServices _clienteServices;
        public ClientesController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        [Route("ClientesResumidos")]
        public ActionResult MostrarTodosClientes()
        {
            return Ok(_clienteServices.MostrarTodosClientes());
        }

        [HttpGet]
        [Route("PessoaFisica")]
        public ActionResult MostrarTodosClientesPF()
        {
            return Ok(_clienteServices.MostrarClientesPF());
        }

        [HttpGet]
        [Route("PessoaJuridica")]
        public ActionResult MostrarTodosClientesPJ()
        {
            return Ok(_clienteServices.MostrarClientesPJ());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult ClientePorId(int id)
        {
            if (_clienteServices.ExisteCliente(id)) {
                
                return Ok(_clienteServices.MostrarClientePorId(id)); 
            }

            return NoContent();
            
        }


        [HttpPost]
        [Route("/Clientes/pessoafisica")]
        public ActionResult AdicionarPessoaFisica([FromBody]PessoaFisica pf)
        {
            if (_clienteServices.ExisteCliente(pf.Id))
            {
                return BadRequest("Cliente já cadastrado");
            }
            _clienteServices.AdicionarPessoaFisica(pf);
            return Ok("Cliente Adicionado!");
        }

        [HttpPost]
        [Route("/Clientes/pessoaJuridica")]
        public ActionResult AdicionarPessoaJuridica([FromBody] PessoaJuridica pj)
        {
            if (_clienteServices.ExisteCliente(pj.Id))
            {
                return BadRequest("Cliente já cadastrado");
            }
            _clienteServices.AdicionarPessoaJuridica(pj);
            return Ok("Cliente Adicionado!");
        }

        // Ex 04

        [HttpPut]
        [Route("pessoafisica/{id}")]
        public ActionResult AtualizarPessoaFisica(int id, [FromBody] PessoaFisica pf)
        {
            if (_clienteServices.ExisteCliente(id))
            {
                _clienteServices.AtualizarPessoaFisica(pf, id);
                return Ok("Cliente alterado");
            }
            return NoContent();
        }

        [HttpPut]
        [Route("/Clientes/pessoajuridica/{id}")]
        public ActionResult AtualizarPessoaJuridica(int id, [FromBody] PessoaJuridica pj)
        {
            if (_clienteServices.ExisteCliente(id))
            {
                _clienteServices.AtualizarPessoaJuridica(pj, id);
                return Ok("Cliente alterado");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("/Excluir/PessoaFisica")]
        public ActionResult DeletarClientePF([FromBody] int id)
        {
            if (_clienteServices.ExisteCliente(id))
            {
                if (_clienteServices.Excluirpf(id))
                {
                    return Ok("Cliente Excluido!");
                }
                return BadRequest("Cliente ainda possui saldo em conta!");
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("/Excluir/PessoaJuridica")]
        public ActionResult DeletarClientePJ([FromBody]int id) {
            if (_clienteServices.ExisteCliente(id))
            {   
                if (_clienteServices.Excluirpj(id))
                {
                    return Ok("Cliente Excluido!");
                }
                return BadRequest("Cliente ainda possui saldo em conta!");
            }
            return NoContent();
        }
    }
}
