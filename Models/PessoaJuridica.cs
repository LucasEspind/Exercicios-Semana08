namespace Exercicios_Semana08_WebAPI.Models
{
    public class PessoaJuridica : Clientes
    {
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
    }
}
