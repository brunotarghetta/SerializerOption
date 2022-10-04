namespace WebApplication4
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int temperatureC { get; set; }

        public int TemperatureF => 32 + (int)(temperatureC / 0.5556);

        public string? Summary { get; set; }

        public string? SummaryCamelCase { get { return "Hola mundo 2"; } }

        public string? SummaryPlusCamelCase { get { return "Hola mundo"; } }
    }
}