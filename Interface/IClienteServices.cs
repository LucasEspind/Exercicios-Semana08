using Exercicios_Semana08_WebAPI.Models;

namespace Exercicios_Semana08_WebAPI.Interface
{
    public interface IClienteServices
    {
        List<Clientes> MostrarClientePorId(int id);
        List<Clientes> MostrarTodosClientes();
        List<PessoaJuridica> MostrarClientesPJ();
        List<PessoaFisica> MostrarClientesPF();
        void AdicionarPessoaFisica(PessoaFisica pf);
        void AdicionarPessoaJuridica(PessoaJuridica pj);
        bool ExisteCliente(int id);
        PessoaFisica AtualizarPessoaFisica(PessoaFisica pessoaFisica, int id);
        PessoaJuridica AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica, int id);
        bool Excluirpf(int id);
        bool Excluirpj(int id);
        bool AdicionarSaldo(int id, Transacao transacao);
        bool RetirarSaldo(int id, Transacao transacao);
        List<Transacao> MostrarExtrato(int id);

    }
}
