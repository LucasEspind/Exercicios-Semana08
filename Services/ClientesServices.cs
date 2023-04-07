using Exercicios_Semana08_WebAPI.Models;
using Exercicios_Semana08_WebAPI.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Drawing;

namespace Exercicios_Semana08_WebAPI.Services
{
    public class ClientesServices : IClienteServices
    {
        static List<Clientes> _clientes = new List<Clientes>();
        static List<PessoaFisica> _PessoaFisica = new List<PessoaFisica>();
        static List<PessoaJuridica> _PessoaJuridica = new List<PessoaJuridica>();

        public void AdicionarPessoaFisica(PessoaFisica pf)
        {
            _clientes.Add(pf);
            _PessoaFisica.Add(pf);
        }

        public void AdicionarPessoaJuridica(PessoaJuridica pj)
        {
            _clientes.Add(pj);
            _PessoaJuridica.Add(pj);
        }

        public List<Clientes> MostrarTodosClientes()
        {
            return _clientes;
        }

        public List<PessoaFisica> MostrarClientesPF()
        {
            return _PessoaFisica;
        }
        public List<PessoaJuridica> MostrarClientesPJ()
        {
            return _PessoaJuridica;
        }

        public List<Clientes> MostrarClientePorId(int id)
        {
            var filtroclientes = _clientes.Where(x => x.Id == id).ToList();
            return filtroclientes;
        }

        public bool ExisteCliente(int id)
        {
            if (_clientes.Exists(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool Excluirpf(int id)
        {
            var cliente = _PessoaFisica.Find(x => x.Id == id);
            if (cliente.Saldo == 0)
            {
                _PessoaFisica.Remove(cliente);
                _clientes.Remove(cliente);
                return true;
            }
            return false;
        }
        public bool Excluirpj(int id)
        {
            var cliente = _PessoaJuridica.Find(x => x.Id == id);
            if (cliente.Saldo == 0)
            {
                _PessoaJuridica.Remove(cliente);
                _clientes.Remove(cliente);
                return true;
            }
            return false;
        }

        public PessoaFisica AtualizarPessoaFisica(PessoaFisica pessoaFisica, int id)
        {
            var existe = _PessoaFisica.Find(x => x.Id == id);

            if (ExisteCliente(id))
            {
                foreach (var cliente in _PessoaFisica)
                {
                    if (cliente.Id == id)
                    {
                        cliente.Id = pessoaFisica.Id;
                        cliente.Email = pessoaFisica.Email;
                        cliente.Telefone = pessoaFisica.Telefone;
                        cliente.Endereco = pessoaFisica.Endereco;
                        cliente.Nome = pessoaFisica.Nome;
                        cliente.CPF = pessoaFisica.CPF;
                    }
                }
                foreach (var cliente in _clientes)
                {
                    cliente.Id = pessoaFisica.Id;
                    cliente.Email = pessoaFisica.Email;
                    cliente.Telefone = pessoaFisica.Telefone;
                    cliente.Endereco = pessoaFisica.Endereco;
                }
            }

            return existe;

        }

        public PessoaJuridica AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica, int id)
        {
            var existe = _PessoaJuridica.Find(x => x.Id == id);

            if (ExisteCliente(id))
            {
                foreach (var cliente in _PessoaJuridica)
                {
                    if (cliente.Id == id)
                    {
                        cliente.Id = pessoaJuridica.Id;
                        cliente.Email = pessoaJuridica.Email;
                        cliente.Telefone = pessoaJuridica.Telefone;
                        cliente.Endereco = pessoaJuridica.Endereco;
                        cliente.RazaoSocial = pessoaJuridica.RazaoSocial;
                        cliente.CNPJ = pessoaJuridica.CNPJ;
                    }
                }
                foreach (var cliente in _clientes)
                {
                    if (cliente.Id == id)
                    {
                        cliente.Id = pessoaJuridica.Id;
                        cliente.Email = pessoaJuridica.Email;
                        cliente.Telefone = pessoaJuridica.Telefone;
                        cliente.Endereco = pessoaJuridica.Endereco;
                    }
                }
            }

            return existe;
        }

        public bool AdicionarSaldo(int id, Transacao transacao)
        {
            foreach (var cliente in _clientes)
            {
                if (cliente.Id == id)
                {
                    
                    cliente.Extrato.Add(transacao);
                }
            }
            return true;
        }

        public bool RetirarSaldo(int id, Transacao transacao)
        {
            foreach (var cliente in _clientes)
            {
                if (cliente.Id == id)
                {
                    cliente.Extrato.Add(transacao);
                }
            }
            return true;
        }

        public List<Transacao> MostrarExtrato(int id)
        {
            foreach (var cliente in _clientes)
            {
                if (cliente.Id == id)
                {
                    return cliente.Extrato;
                }
            }
            return null;
        }
    }
}