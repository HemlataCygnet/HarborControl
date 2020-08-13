

using UI.Models;

namespace Helper.Models
{
    public class WeatherMapResponse
    {
        public string Error { get; set; }
        public double WindSpeed { get; set; }
        public bool IsApiExecute { get; set; }
        public ExceptionLogger ExceptionLog { get; set; }
    }


}
