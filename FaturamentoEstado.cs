using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Target_Sistemas
{
    internal class FaturamentoEstado
    {
        public string Estado { get; set; }
        public double Valor { get; set; }

        public FaturamentoEstado(string estado, double valor)
        {
            Estado = estado;
            Valor = valor;
        }

    }
}
