using System.Globalization;
using System.Text.Json;

namespace Teste_Target_Sistemas
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnCalcularTeste1_Click(object sender, EventArgs e)
        {
            Console.Clear();
            //Criando as variáveis para calcular
            int indice = 13, soma = 0, k = 0;

            //while para fazer as iterações solicitadas
            while (k < indice)
            {
                k = k + 1;
                soma = soma + k;
                Console.WriteLine(soma);
            }

            txtResTeste1.Text = soma.ToString();//O Resultado é 91
        }

        private void btnCalcularTeste2_Click(object sender, EventArgs e)
        {
            Console.Clear();
            //Conferir se determinado número faz parte da sequência Fibonacci
            int numero = 0, fib1 = 0, fib2 = 1;

            //Primeiro vamos verificar se há erros antes de processar
            if (Int32.TryParse(txtInputTeste2.Text, out numero))
            {

                Console.Write("Teste 2: 0 - 1");
                //Vamos calcular sempre consultando o número
                while (numero > fib2)
                {
                    int proximo = fib1 + fib2;
                    Console.Write($" - {proximo}");
                    fib1 = fib2;
                    fib2 = proximo;


                }

                txtResTeste2.Text = (numero == fib2) ? "Pertence" : "Não Pertence";
            }

        }

        private void btnCalcularTeste3_Click(object sender, EventArgs e)
        {
            Console.Clear();
            string json = File.ReadAllText("dados.json");
            List<FaturamentoDiario> faturamento = JsonSerializer.Deserialize<List<FaturamentoDiario>>(json);

            if (faturamento is null || faturamento.Count == 0)
            {
                Console.WriteLine("Nenhum dado disponível.");
                return;
            }

            //Antes precisamos remover os dias sem faturamento e tratar para possíveis erros
            var diasValidos = faturamento.Where(f => f.valor > 0).ToList();

            if (diasValidos.Count == 0)
            {
                Console.WriteLine("Nenhum dia com faturamento registrado.");
                return;
            }


            //Vamos buscar o menor e maior faturamento
            FaturamentoDiario menorFaturamento = diasValidos.MinBy(f => f.valor);
            FaturamentoDiario maiorFaturamento = diasValidos.MaxBy(f => f.valor);

            //Calcular a média mensal
            double mediaMensal = diasValidos.Average(f => f.valor);

            // Verificar os dias com faturamento acima da média
            var diasAcimaDaMedia = diasValidos.Where(f => f.valor > mediaMensal).Select(f => f.dia).ToList();

            //Mostrar resultados no console e na tela
            Console.WriteLine($"Menor faturamento: {menorFaturamento.valor.ToString("C2")} no dia {menorFaturamento.dia}");
            Console.WriteLine($"Maior faturamento: {maiorFaturamento.valor.ToString("C2")} no dia {maiorFaturamento.dia}");
            Console.WriteLine($"Dias acima da média: {diasAcimaDaMedia.Count} (Dias {string.Join(", ", diasAcimaDaMedia)})");

            txtMenorFaturamentoT3.Text = $"{menorFaturamento.valor.ToString("C2")} no dia {menorFaturamento.dia}";
            txtMaiorFaturamentoT3.Text = $"{maiorFaturamento.valor.ToString("C2")} no dia {maiorFaturamento.dia}";
            txtAcimaMediaT3.Text = $"{diasAcimaDaMedia.Count} (Dias {string.Join(", ", diasAcimaDaMedia)})";

        }

        private void btnCalcularTeste4_Click(object sender, EventArgs e)
        {
            Console.Clear();
            // Vamos criar uma lista de objetos FaturamentoEstado
            List<FaturamentoEstado> faturamentoEstados = new List<FaturamentoEstado>
            {
                new FaturamentoEstado("SP", 67836.43),
                new FaturamentoEstado("RJ", 36678.66),
                new FaturamentoEstado("MG", 29229.88),
                new FaturamentoEstado("ES", 27165.48),
                new FaturamentoEstado("Outros", 19849.53)
            };

            //Agora fazemos o cálculo do faturamento total
            double faturamentoTotal = 0;
            foreach (var estado in faturamentoEstados)
            {
                faturamentoTotal += estado.Valor;
            }

            //Mostrar percentuais de cada estado
            Console.WriteLine("Percentual de representação por estado:");
            foreach (var estado in faturamentoEstados)
            {
                double percentual = (estado.Valor / faturamentoTotal);
                Console.WriteLine($"{estado.Estado}: {percentual.ToString("P2")}");
                txtPartSP.Text = $"{(estado.Estado == "SP" ? percentual.ToString("P2") : txtPartSP.Text)}";
                txtPartRJ.Text = $"{(estado.Estado == "RJ" ? percentual.ToString("P2") : txtPartRJ.Text)}";
                txtPartMG.Text = $"{(estado.Estado == "MG" ? percentual.ToString("P2") : txtPartMG.Text)}";
                txtPartES.Text = $"{(estado.Estado == "ES" ? percentual.ToString("P2") : txtPartES.Text)}";
                txtPartOutros.Text = $"{(estado.Estado == "Outros" ? percentual.ToString("P2") : txtPartOutros.Text)}";
            }
        }

        private void btnInverterTeste5_Click(object sender, EventArgs e)
        {
            //Vamos chamar a função (só pra separar no código e ficar mais prolixo)
            txtResultadoInvertido.Text = InverterString(txtInverterString.Text);
        }

        private string InverterString(string inverter)
        {
            string invertida = string.Empty;
            if (inverter.Length > 0)
            {
                char[] caracteres = inverter.ToCharArray();

                //Invertendo a string manualmente
                for (int i = 0, j = caracteres.Length - 1; i < j; i++, j--)
                {
                    //Trocando os caracteres do fim para o inicio e vice e versa
                    char temp = caracteres[i];
                    caracteres[i] = caracteres[j];
                    caracteres[j] = temp;
                }

                invertida = new string(caracteres);
                Console.WriteLine($"String invertida: {invertida}");
            }

            return invertida;
        }

        private void cbxTeste_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTeste.SelectedText == "Teste 1")
            {
                this.Size = new Size(284, 203);
            }
        }
    }
}
