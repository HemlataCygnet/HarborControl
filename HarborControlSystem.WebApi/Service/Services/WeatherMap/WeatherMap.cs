using Common.Constants;
using Common.Models.WeatherMap;
using Newtonsoft.Json;
using Service.Contracts.IWeatherMap;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Services.WeatherMap
{
    public class WeatherMap : IWeatherMap
    {

        /// <summary>
        /// Get weather map
        /// http://api.openweathermap.org
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherMapResponse<List<ResponseWeather>>> GetCityWeatherMap(string city)
        {
            var response = new WeatherMapResponse<List<ResponseWeather>>();
            var objLilstWeather = new List<ResponseWeather>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(WeatherMapConstants.BaseURL);
                    var apiResponse = await client.GetAsync($"/data/2.5/weather?q={city}&appid={WeatherMapConstants.APIKey}&units=metric");
                    apiResponse.EnsureSuccessStatusCode();
                    var stringResult = await apiResponse.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<ResponseWeather>(stringResult);
                    objLilstWeather.Add(rawWeather);
                    response.Data = objLilstWeather;
                    response.TotalRecords = Convert.ToString(objLilstWeather.Count);
                    response.Status = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return response;
            }
        }
    }
}
