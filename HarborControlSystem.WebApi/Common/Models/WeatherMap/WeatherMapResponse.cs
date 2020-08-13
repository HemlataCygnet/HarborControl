namespace Common.Models.WeatherMap
{
    public class WeatherMapResponse<T> where T : class
    {
        public bool Status { get; set; }
        public T Data { get; set; }
        public string TotalRecords { get; set; }
    }
}
