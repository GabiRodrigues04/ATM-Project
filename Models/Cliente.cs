namespace Atm.Models {

    class Cliente
    {
        private double _valorTransacao;
        private ContaCorrente _contaCorrente;
        private ContaPoupanca _contaPoupanca;
        public string NomeTitular { get; private set; }
        public string SobrenomeTitular { get; private set; }
        public string Agencia { get; private set; }
        public int Conta { get; private set; }
        public int Senha { get; private set; }

         public Cliente(string nome, string sobrenome, int senha) {

            NomeTitular = nome;
            SobrenomeTitular = sobrenome;
            Senha = senha;
            Random rnd = new Random();
            Conta = rnd.Next(10000, 99999);
            Agencia = $"000{rnd.Next(100, 999)}-{rnd.Next(0, 9)}";
            _contaCorrente = new ContaCorrente(this);
            _contaPoupanca = new ContaPoupanca(this);

        }
        
         public void Menu() {

            bool exibirMenu = true;
            Console.Clear();

            while (exibirMenu){

                Console.WriteLine("----------- MENU -----------");
                Console.WriteLine("0. Encerrar");
                Console.WriteLine("1. Consultar informações");
                Console.WriteLine("2. Consultar saldo");
                Console.WriteLine("3. Realizar depósito");
                Console.WriteLine("4. Realizar saque");
                Console.WriteLine("5. Realizar transferência");
                Console.WriteLine("--- Selecione uma opção ---");

                    switch (int.Parse(Console.ReadLine() ?? "9"))  {
                        case 0:
                            Console.WriteLine("Saindo...");
                            exibirMenu = false;
                            break;
                        case 1:
                            AcessarDados();
                            break;
                        case 2:
                            AcessarSaldo();
                            break;
                        case 3:
                            Deposito();
                            break;
                        case 4:
                            Saque();
                            break;
                        case 5:
                            Transferencia();
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }
            }
         
         public void AcessarDados() {

            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Aqui vão seus dados!");
            Console.WriteLine(NomeTitular + " " + SobrenomeTitular);
            Console.WriteLine("Número da conta: " + Conta);
            Console.WriteLine("Número da agência: " + Agencia);

            Console.WriteLine("\nDigite uma tecla para continuar: ");
            Console.ReadLine();
        }  
    
        public void Deposito() {
        
            Console.Clear();
            Console.WriteLine("Digite o valor a ser depositado");
            _valorTransacao = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. para fazer depósito em conta corrente");
            Console.WriteLine("2. para fazer depósito em conta poupança");
            int value = int.Parse(Console.ReadLine() ?? "0");

            while (value <= 0 || value > 2 ) {    
            Console.WriteLine("Digite 1 para fazer depósito em corrente e 2 para depósito em poupança");
            value = int.Parse(Console.ReadLine() ?? "0");
            }

                if (value == 1) {

                _contaCorrente.DepositoCorrente(_valorTransacao);
                Console.WriteLine("Valor de R$ " + _valorTransacao + " depositado em conta corrente.");
 

                } else if (value == 2) {

                _contaPoupanca.DepositoPoupanca(_valorTransacao);
                Console.WriteLine("Valor de R$ " + _valorTransacao + " depositado em conta poupança.");

                } 

                Console.WriteLine("\nDigite uma tecla para continuar: ");
                Console.ReadLine();

            }
     
        public void Saque() {

            Console.Clear();
            Console.WriteLine("Digite o valor a ser sacado");
            _valorTransacao = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. para fazer saque em conta corrente");
            Console.WriteLine("2. para fazer saque em conta poupança");
            int value = int.Parse(Console.ReadLine() ?? "0");

            while (value <= 0 || value > 2 ) {    
            Console.WriteLine("Digite 1 para fazer saque em corrente e 2 para depósito em poupança");
            value = int.Parse(Console.ReadLine() ?? "0");
            }

            if (value == 1) {

                if (_contaCorrente.SaqueCorrente(_valorTransacao)) {
                    Console.WriteLine("Valor de R$ " + _valorTransacao + " sacados da conta corrente.");
                } else {
                     Console.WriteLine("Valor de R$ " + _valorTransacao + " indisponível em conta corrente.");
                }

            } else if (value == 2) {

                if (_contaPoupanca.SaquePoupanca(_valorTransacao)) {
                    Console.WriteLine("Valor de R$ " + _valorTransacao + " sacados da conta poupança.");
                } else {
                     Console.WriteLine("Valor de R$ " + _valorTransacao + " indisponível em conta corrente.");
                 }
            } 

            Console.WriteLine("\nDigite uma tecla para continuar: ");
            Console.ReadLine();

            }

        public void AcessarSaldo() {

            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Aqui está o valor em sua conta corrente: R$ " + _contaCorrente.SaldoCorrente );
            Console.WriteLine("Aqui está o valor em sua conta poupança: R$ " + _contaPoupanca.SaldoPoupanca );
            Console.WriteLine("Valor total em conta: R$ " + (_contaPoupanca.SaldoPoupanca + _contaCorrente.SaldoCorrente) );

            Console.WriteLine("\nDigite uma tecla para continuar: ");
            Console.ReadLine();
     }

        public void Transferencia() {

            Console.Clear();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. Se deseja transferir da CONTA CORRENTE PARA POUPANÇA");
            Console.WriteLine("2. Se deseja transferir da CONTA POUPANÇA PARA CORRENTE");
            int value = int.Parse(Console.ReadLine() ?? "0");

            while (value <= 0 || value > 2 ) {    
            Console.WriteLine("1. para transferir CORRENTE -> POUPANÇA e 2. para transferir POUPANÇA -> CORRENTE");
            value = int.Parse(Console.ReadLine() ?? "0");
            }
        
            if (value == 1) {

                Console.WriteLine("Este é o valor em sua conta corrente: R$ " + _contaCorrente.SaldoCorrente );
                Console.WriteLine("Quanto deseja transferir ?");
                _valorTransacao = double.Parse(Console.ReadLine() ?? "0");

                if (_contaCorrente.SaqueCorrente(_valorTransacao)) {
                    
                    _contaCorrente.SaqueCorrente(_valorTransacao);
                    _contaPoupanca.DepositoPoupanca(_valorTransacao);
                    Console.WriteLine("Valor de R$ " + _valorTransacao + " transferidos da conta corrente para conta poupança.");
                    
                } else {

                    Console.WriteLine("Saldo de " + _valorTransacao + "insuficiente para transferência na conta poupança.");
                }

                } else if (value == 2) {

                Console.WriteLine("Este é o valor em sua conta poupança: R$ " + _contaPoupanca.SaldoPoupanca  );
                Console.WriteLine("Quanto deseja transferir ?");
                _valorTransacao = double.Parse(Console.ReadLine() ?? "0");

                if (_contaPoupanca.SaquePoupanca(_valorTransacao)) {
                    
                    _contaPoupanca.SaquePoupanca(_valorTransacao);
                    _contaCorrente.DepositoCorrente(_valorTransacao);
                    Console.WriteLine("Valor de R$ " + _valorTransacao + " transferidos da conta corrente para conta poupança.");
                    
                } else {

                    Console.WriteLine("Saldo de " + _valorTransacao  + "insuficiente para transferência na conta poupança.");

                }

            Console.WriteLine("\n Digite uma tecla para continuar: ");
            Console.ReadLine();
        
        }   
    } 

} 
}

