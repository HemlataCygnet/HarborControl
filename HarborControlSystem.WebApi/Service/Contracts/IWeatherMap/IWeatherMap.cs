using Common.Models.WeatherMap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts.IWeatherMap
{
    public interface IWeatherMap
    {

        /// <summary>
        /// Interface for get weather map of city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task<WeatherMapResponse<List<ResponseWeather>>> GetCityWeatherMap(string city);
    }
}
