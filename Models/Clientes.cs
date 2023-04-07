namespace Exercicios_Semana08_WebAPI.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public double Saldo
        {
            get { return GetSaldo(); }
            private set { }
        }
        public List<Transacao> Extrato { get; set; }

        public Clientes()
        {
            Extrato = new List<Transacao>();
        }

        private double GetSaldo()
        {
            double saldo = 0;
            foreach (Transacao transacao in Extrato)
            {
                saldo += transacao.Valor;
            }
            return saldo;
        }
    }
}
