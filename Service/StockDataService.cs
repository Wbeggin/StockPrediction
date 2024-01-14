using CsvHelper;
using CsvHelper.Configuration;
using StockPredictionWeb.Models;
using System.Globalization;


public class StockDataService
{
    private readonly HttpClient httpClient;

    public StockDataService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<StockData>> GetStockDataAsync()
    {
        var csvContent = await httpClient.GetStringAsync("data/stock_prediction_data.csv");

        using (var reader = new StringReader(csvContent))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<StockData>().ToList();
        }
    }
}
