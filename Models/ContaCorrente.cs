namespace Atm.Models
{
    class ContaCorrente
    {
        private readonly Cliente _cliente;
        public double SaldoCorrente { get; private set; }

        public ContaCorrente(Cliente cliente) {
            _cliente = cliente;
        }

        public void DepositoCorrente(double valorDeposito) {
            SaldoCorrente += valorDeposito;
        }

        public bool SaqueCorrente(double valorSaque)  {
            if (SaldoCorrente >= valorSaque)
            {
                SaldoCorrente -= valorSaque;
                return true;
            }
            return false;
        }
   
    }
}