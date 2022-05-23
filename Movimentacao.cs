using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iir_helper
{
    public class Movimentacao
    {
        public Movimentacao(IRow row)
        {
            data = Convert.ToDateTime(row.GetCell(0).StringCellValue);
            Tipo = row.GetCell(1).StringCellValue;
            Ticker = row.GetCell(5).StringCellValue;
            Quantidade = (int)row.GetCell(6).NumericCellValue;
            Preco = row.GetCell(7).NumericCellValue;
            ValorTotal = row.GetCell(8).NumericCellValue;
        }

        public DateTime data { get; set; }
        public string Tipo { get; set; }
        public string Ticker { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double ValorTotal { get; set; }


       
    }
}
