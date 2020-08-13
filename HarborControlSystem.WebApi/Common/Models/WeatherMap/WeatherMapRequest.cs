namespace Common.Models.WeatherMap
{
    public class WeatherMapRequest<T> where T : class
    {
        public string CityName { get; set; }
    }
}
