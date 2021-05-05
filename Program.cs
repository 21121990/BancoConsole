using System;
using System.Collections.Generic;

namespace BancoConsole
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
            Conta conta = new Conta();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        SacarConta();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso Banco, volte sempre!!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            ListContas[indiceContaOrigem].Transferir(valorTransferencia, ListContas[indiceContaDestino]);

        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depostado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Depositar(valorDeposito);
        }

        private static void SacarConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double ValorSaque = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Sacar(ValorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (ListContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta Cadastrada");
                return;
            }
            for (int i = 0; i < ListContas.Count; i++)
            {
                Conta conta = ListContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inseir Nova Conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Juridica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            //Referenciando nome dos parâmetros dentro do constutor
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
            saldo: entradaSaldo,
            credito: entradaCredito,
            nome: entradaNome);

            ListContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DVS Banco Online");
            Console.WriteLine("informe a opção desejada");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Cadastrar Nova Conta");
            Console.WriteLine("3- Transferência");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;


        }
    }
}
