namespace Atm.Models
{
    class ContaPoupanca
    {
        private readonly Cliente _cliente;
        public double SaldoPoupanca { get; private set; }

        public ContaPoupanca(Cliente cliente) {

            _cliente = cliente;
        }

        public void DepositoPoupanca(double valorSaque) {

            SaldoPoupanca += valorSaque;
        }

        public bool SaquePoupanca(double valorSaque) {

            if (SaldoPoupanca >= valorSaque)
            {
                SaldoPoupanca -= valorSaque;
                return true;
            }
            return false;
        }
   
    }
}