using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iir_helper
{
    class EventoLiquidacao
    {
        public EventoLiquidacao(double qntVenda, double precoVenda, double precoMedio, DateTime data )
        {
           double lucroPorAcao =  precoVenda - precoMedio;
           Lucro = qntVenda * lucroPorAcao;

            date = data;
        }

        public DateTime date { get; set; }
        public double Lucro { get; private set; }
    }
}
