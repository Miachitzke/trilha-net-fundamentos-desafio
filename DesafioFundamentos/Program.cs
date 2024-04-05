using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.Write("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial: ");
// Recebe o valor do preço inicial e do preço por hora em loop se não for um valor valido
while (!decimal.TryParse(Console.ReadLine(), out precoInicial))
{
    Console.WriteLine("Valor inválido, digite novamente: ");
}

Console.Write("Agora digite o preço por hora: ");
// Recebe o valor do preço por hora em loop se não for um valor valido
while (!decimal.TryParse(Console.ReadLine(), out precoPorHora))
{
    Console.WriteLine("Valor inválido, digite novamente: ");
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar\n");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione enter para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
