using System;
using System.Text.RegularExpressions;
using System.Text;

public class SistemaDePagamento
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        string respostaProximoCliente;
        
        string regexNomeValido = @"^[a-zA-Z\s]+$";
        
        do
        {
            Console.Clear();
            Console.WriteLine("--- Sistema de Pagamento da Padaria ---");

            string nomeCliente;
            bool nomeValido;

            do
            {
                Console.WriteLine("\nPor favor, digite o nome do cliente (apenas letras sem acento e espaços):");
                nomeCliente = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(nomeCliente))
                {
                    nomeValido = false;
                    Console.WriteLine("O nome não pode ser vazio. Por favor, tente novamente.");
                }
                else
                {
                    nomeValido = Regex.IsMatch(nomeCliente, regexNomeValido);
                    if (!nomeValido)
                    {
                        Console.WriteLine("O nome só pode conter letras sem acento e espaços. Por favor, tente novamente.");
                    }
                }
            } while (!nomeValido);
            
            double valorTotalCompra;
            bool entradaValida;

            do
            {
                Console.WriteLine("Por favor, digite o valor total da compra (Ex: 25,00 ou 25.00):");
                entradaValida = double.TryParse(Console.ReadLine(), out valorTotalCompra);

                if (!entradaValida)
                {
                    Console.WriteLine("Formato inválido. Por favor, tente novamente com um valor numérico (Ex: 25,00).");
                }
            } while (!entradaValida);
            
            double valorPago;

            do
            {
                Console.WriteLine("Por favor, digite o valor pago pelo cliente (Ex: 200,00 ou 200.00):");
                entradaValida = double.TryParse(Console.ReadLine(), out valorPago);

                if (!entradaValida)
                {
                    Console.WriteLine("Formato inválido. Por favor, tente novamente com um valor numérico (Ex: 200,00).");
                }
            } while (!entradaValida);

            Console.WriteLine($"\nNome: {nomeCliente}");
            Console.WriteLine($"Valor total da compra R$: {valorTotalCompra:F2}");
            Console.WriteLine($"Valor Pago R$: {valorPago:F2}");
            Console.WriteLine("-------------------------------------");

            if (valorPago < valorTotalCompra)
            {
                Console.WriteLine("Valor insuficiente para realizar a compra!");
            }
            else
            {
                double trocoTotal = valorPago - valorTotalCompra;
                Console.WriteLine($"\nTroco: {trocoTotal:F2}");

                int trocoEmCentavos = (int)Math.Round(trocoTotal * 100);

                int[] notas = { 20000, 10000, 5000, 2000, 1000, 500, 200, 100 };
                string[] nomesNotas = { "200", "100", "50", "20", "10", "5", "2", "1" };

                Console.WriteLine("Notas de Troco:");

                for (int i = 0; i < notas.Length; i++)
                {
                    int valorNota = notas[i];
                    int quantidadeNotas = trocoEmCentavos / valorNota;

                    Console.WriteLine($"Notas de {nomesNotas[i]}: {quantidadeNotas}");

                    trocoEmCentavos %= valorNota;
                }
            }
            
            Console.WriteLine("\n=====================================");
            Console.WriteLine("Deseja ir para o próximo cliente? (S para Sim / Qualquer outra tecla para Sair)");
            respostaProximoCliente = Console.ReadLine();

        } while (respostaProximoCliente.ToUpper() == "S" || respostaProximoCliente.ToUpper() == "SIM");

        Console.WriteLine("\nObrigado por usar o sistema! Encerrando...");
    }
}
