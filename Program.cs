using Atm.Models;

class Program
{
    static void Main(string[] args) {

        Cliente admin = new Cliente("admin", "admin", 1234);

        string value = "0";

        Console.WriteLine("Olá, seja bem-vindo ao caixa eletrônico !");
        Console.WriteLine("Insira o dígito da operação desejada: ");
        Console.WriteLine("0. Se deseja sair.");
        Console.WriteLine("1. Se deseja criar uma conta.");
        Console.WriteLine("2. Se deseja acessar uma conta existente.");
        value = Console.ReadLine() ?? string.Empty;

        if (value == "1")
        {
            Cadastro();
        }
        else if (value == "2")
        {
            Entrar(admin);
        }
    }

    public static void Cadastro() {

        string input = "";
        string valueNome = "";
        string valueSobrenome = "";
        int valueSenha = 0;

        Console.Clear();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Para criar sua conta, primeiro digite seu nome: ");
        input = Console.ReadLine() ?? string.Empty;

        while (input == string.Empty)
        {
            Console.WriteLine("O nome não pode estar em branco.");
            input = Console.ReadLine() ?? string.Empty;
        }

        if (input != string.Empty)
        {
            valueNome = char.ToUpper(input[0]) + input.Substring(1);
        }

        Console.WriteLine("Agora, digite seu sobrenome: ");
        input = Console.ReadLine() ?? string.Empty;

        while (input == string.Empty)
        {
            Console.WriteLine("O sobrenome não pode estar em branco.");
            input = Console.ReadLine() ?? string.Empty;
        }

        if (input != string.Empty)
        {
            valueSobrenome = char.ToUpper(input[0]) + input.Substring(1);
        }

        Console.WriteLine("Agora digite uma senha de QUATRO dígitos NUMÉRICOS");
        input = Console.ReadLine() ?? string.Empty;

        while (input.Length != 4)
        {
            Console.WriteLine("A senha deve conter QUATRO dígitos NUMÉRICOS.");
            input = Console.ReadLine() ?? string.Empty;
        }

        if (input != string.Empty)
        {
            valueSenha = int.Parse(input);
        }

        Cliente cliente = new Cliente(valueNome, valueSobrenome, valueSenha);
        Console.WriteLine("Cadastro realizado com sucesso.");
        Entrar(cliente);
    }

   public static void Entrar(Cliente cliente) {

    Console.Clear();

    string input = "";
    string valueNome = "";
    int valueSenha = 0;

    Console.WriteLine("----------------------------------------------");

    for (int i = 1; i <= 3; i++)
    {
        Console.WriteLine("Para acessar sua conta, digite seu nome: ");
        valueNome = Console.ReadLine() ?? "";
        if (string.IsNullOrEmpty(valueNome))
        {
            Console.WriteLine("Nome não pode estar em branco.");
        }
        valueNome = char.ToUpper(valueNome[0]) + valueNome.Substring(1);

        Console.WriteLine("Digite sua senha de quatro dígitos:");
        input = Console.ReadLine() ?? string.Empty;
        if (!int.TryParse(input, out valueSenha) || input.Length != 4)
        {
            Console.WriteLine("Senha inválida. Deve conter exatamente QUATRO dígitos NUMÉRICOS.");
        }

        if ((valueNome == cliente.NomeTitular && valueSenha == cliente.Senha) ||
            (valueNome.Equals("Admin", StringComparison.OrdinalIgnoreCase) && valueSenha == 1234))
        {
            Console.WriteLine("Bem-vindo !");
            cliente.Menu();
            return;
        }
        else
        {
            Console.WriteLine("Usuário ou senha incorreto.");
        }
    }
    Console.WriteLine("Número máximo de tentativas excedido. Tente novamente mais tarde.");
}
    
}
