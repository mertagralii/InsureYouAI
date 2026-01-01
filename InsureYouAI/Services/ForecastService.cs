using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace InsureYouAI.Services;

public class PolicySalesData
{
    public DateTime Date { get; set; } // Tarih (Örn: 16 Aralık 2025)
    public float SaleCount { get; set; }  // O gün satılan poliçe sayısı (Örn: 15 adet)
}

public class PolicySalesForecast
{
    public float[] ForecastedValues { get; set; } // Tahmini Satışlar
    public float[] LowerBoundValues { get; set; } // En Kötü Senaryo (Alt Sınır)
    public float[] UpperBoundValues { get; set; } // En İyi Senaryo (Üst Sınır)
}
public class ForecastService
{
    private readonly MLContext _mlContext;

    public ForecastService()
    {
        _mlContext = new MLContext();
    }

    public PolicySalesForecast GetForecast(List<PolicySalesData> salesData, int horizon = 3)
    {
        if (salesData.Count < 8) // En az 8 veri noktası gereklidir
        {
            throw new ArgumentException("En az 8 veri noktası gereklidir.");
        }
        var dataView = _mlContext.Data.LoadFromEnumerable(salesData); // Veriyi ML.NET DataView formatına dönüştür
        int windowSize = Math.Max(2, salesData.Count / 4); // Pencere boyutunu veri sayısının çeyreği olarak ayarla, en az 2 olmalı
        int seriesLength = Math.Max(windowSize + 1, salesData.Count / 2); // Seri uzunluğunu pencere boyutunun bir fazlası veya veri sayısının yarısı olarak ayarla
        int trainSize = salesData.Count; // Eğitim veri seti boyutu
        if (trainSize <= 2 * windowSize) // Eğitim veri seti, pencere boyutunun iki katından küçükse pencere boyutunu ayarla
        {
            windowSize = (trainSize / 2) - 1; // Pencere boyutunu eğitim veri setinin yarısının bir eksiği olarak ayarla
            windowSize = Math.Max(2, windowSize); // En az 2 olmalı
        }
        seriesLength = Math.Max(seriesLength, windowSize + 1); //  // seriesLength >= windowSize olmalı 
        seriesLength = Math.Min(seriesLength, trainSize); // seriesLength, trainSize'dan büyük olamaz
        var forecastingPipeline = _mlContext.Forecasting.ForecastBySsa( // SSA tabanlı zaman serisi tahmin modeli oluştur
            outputColumnName: "ForecastedValues", // Tahmin edilen değerler için çıkış sütunu adı
            inputColumnName: "SaleCount", // Giriş sütunu adı
            windowSize: windowSize, // Pencere boyutu
            seriesLength: seriesLength, // Seri uzunluğu
            trainSize: trainSize, // Eğitim veri seti boyutu
            horizon: horizon, // Tahmin ufku (kaç adım ileriye tahmin edilecek)
            confidenceLevel: 0.95f, // Güven aralığı seviyesi
            confidenceLowerBoundColumn: "LowerBoundValues", // Alt sınır sütunu adı
            confidenceUpperBoundColumn: "UpperBoundValues" // Üst sınır sütunu adı
        );
        var model = forecastingPipeline.Fit(dataView); // Modeli eğit
        var forecastingEngine = model.CreateTimeSeriesEngine<PolicySalesData, PolicySalesForecast>(_mlContext); // Zaman serisi tahmin motoru oluştur
        return forecastingEngine.Predict(); // Tahminleri döndür
    }

    
}