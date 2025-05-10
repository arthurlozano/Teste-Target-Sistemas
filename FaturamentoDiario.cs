using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Target_Sistemas
{
    internal class FaturamentoDiario
    {
        //Criada a classe com as variáveis minúsculas para se adequar ao JSON enviado.
        public int dia { get; set; }
        public double valor { get; set; }
    }
}
