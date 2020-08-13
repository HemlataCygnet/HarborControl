using System.Collections.Generic;

namespace Common.Models.WeatherMap
{


    public class WeatherMap {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Result Result { get; set; }
        public bool Status { get; set; }
    }


    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }


    public class ResponseWeather
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Result
    {
        public bool Status { get; set; }
        public List<Datum> Data { get; set; }
        public string TotalRecords { get; set; }
    }

    public class Datum
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
