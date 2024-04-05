namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Pede para o usuário digitar uma placa e adiciona na lista "veiculos"
            Console.WriteLine("\nDigite a placa do veículo para estacionar(7 dígitos): ");
            string placa = Console.ReadLine().ToUpper();

            // Pede a placa em loop se vazia, menor que 7, maior que 8 ou ja cadastrada
            while (string.IsNullOrEmpty(placa) || placa.Length != 7 || veiculos.Any(x => x.Placa.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("\nPlaca inválida ou já cadastrada, digite novamente:");
                placa = Console.ReadLine().ToUpper();
            }

            veiculos.Add(new Veiculo(placa, DateTime.Now));
            Console.WriteLine($"\nVeículo {placa} estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover(7 dígitos):");
            string placa = Console.ReadLine();

            while (string.IsNullOrEmpty(placa) || placa.Length != 7)
            {
                Console.WriteLine("\nPlaca inválida, digite novamente:");
                placa = Console.ReadLine().ToUpper();
            }

            // Verifica se o veículo existe
            Veiculo veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper() == placa.ToUpper());

            if (veiculo != null)
            {
                DateTime horaSaida = DateTime.Now;
                TimeSpan tempoEstacionado = horaSaida - veiculo.HoraEntrada;

                if (tempoEstacionado.TotalMinutes < 0)
                {
                    Console.WriteLine("\nErro: A hora de saída é menor que a hora de entrada.\n" +
                        "Verifique a hora do sistema e tente novamente.");
                    return;
                }

                // Calcula o valor total a ser pago
                int horas = (int)Math.Ceiling(tempoEstacionado.TotalHours);
                decimal valorTotal = 0; 

                if (horas <= 1)
                {
                    valorTotal = precoInicial;
                }
                else
                {
                    valorTotal = precoInicial + (precoPorHora * (horas - 1));

                    // Verifica se há adicional de minutos (30m)
                    if (tempoEstacionado.Minutes > 30)
                    {
                        valorTotal += precoPorHora/2;
                    }
                }

                veiculos.Remove(veiculo);

                Console.WriteLine($"\nO veículo {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa}, Entrada: {veiculo.HoraEntrada}");
                }
            }
            else
            {
                Console.WriteLine("\nAinda não há veículos estacionados.");
            }
        }
    }
}
