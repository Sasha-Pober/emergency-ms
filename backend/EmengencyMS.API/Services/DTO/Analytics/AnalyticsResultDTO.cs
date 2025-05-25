namespace Services.DTO.Analytics;

public class AnalyticsResultDTO
{
    public string Name { get; set; }
    public double S { get; set; } // сукупне відхилення
    public double R { get; set; } // максимальне відхилення
    public double Q { get; set; } // індекс VIKOR   
}
