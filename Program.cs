
using iir_helper;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

var movimentations = new List<Movimentacao>();


IWorkbook wb = new XSSFWorkbook(args[0]);

ISheet sheet1 = wb.GetSheetAt(0);

for (int i = 1; i <= sheet1.LastRowNum; i++)
{
    var row = sheet1.GetRow(i);
    movimentations.Add(new Movimentacao(row));
}

Console.WriteLine($"{movimentations.Count} movimentações encontradas.");
Console.ReadKey();


var byTicker = movimentations.OrderBy(x => x.data).GroupBy(movimentation => movimentation.Ticker);

foreach (var grouping in byTicker) {
    GetPrecoMedio(grouping);
}


void GetPrecoMedio(IGrouping<string,Movimentacao> movimentacoes) {

    var qntTotalAcoes = 0;
    var valorTotal = 0.0;

    var liquidacoes = new List<EventoLiquidacao>();

    foreach (var movimentation in movimentacoes)
    {
        if (movimentation.Tipo == "Venda")
            liquidacoes.Add(new EventoLiquidacao(movimentation.Quantidade, movimentation.Preco, valorTotal / qntTotalAcoes, movimentation.data));

        qntTotalAcoes += movimentation.Tipo == "Compra" ? movimentation.Quantidade : -movimentation.Quantidade;
        valorTotal += movimentation.Tipo == "Compra" ? movimentation.ValorTotal : -movimentation.ValorTotal;


    }
    
    Console.WriteLine($"{movimentacoes.Key} - POSICAO 31/12/2021 = {qntTotalAcoes}  {WritePrecoMedio()} ");

    foreach (var liquidacao in liquidacoes) {
       Console.WriteLine($"    Venda - {liquidacao.date.ToString("dd/MM/yyyy")} - LUCRO = {liquidacao.Lucro}");
    }
    Console.WriteLine("");
    string WritePrecoMedio()
    {
        return qntTotalAcoes > 0 ? $"- PRECO MEDIO = {valorTotal / qntTotalAcoes}" : "";
    }
}



