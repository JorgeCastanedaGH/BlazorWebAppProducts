using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BlazorWebAppProducts.Models
{
    public class OpenMeteoApiClient(HttpClient hc)
    {
        public async Task<WeatherForecastOM> GetWeatherAsync(CancellationToken cancellationToken = default)
        {
            WeatherForecastOM? wom = null;
            try
            {
                var vRes = await hc.GetAsync("v1/forecast?latitude=19.43411&longitude=-99.20024&current=temperature_2m&hourly=temperature_2m&timezone=auto&models=best_match", cancellationToken);
                var vCon = vRes.Content.ReadAsStringAsync();
                string strRes = vCon.Result.ToString() ?? string.Empty;
                JObject jo = JObject.Parse(strRes);
                DateTime dt = (DateTime)jo["current"]["time"];
                int i = (int)jo["current"]["temperature_2m"];
                string s = (string)jo["timezone"];
                wom = new WeatherForecastOM(dt.Date, i, s);
            }
            catch (Exception ex) { }
            return wom;
        }
    }
    public record WeatherForecastOM(DateTime Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

}
