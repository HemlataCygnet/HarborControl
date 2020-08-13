using Common.Models.WeatherMap;
using Helper.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using UI.Models;
using UI.Utility;

namespace Helper.Helpers
{
    public class WindSpeed
    {
       /// <summary>
       /// Get Wind speed 
       /// Call WeatherMap web Api
       /// </summary>
       /// <returns></returns>
        public static WeatherMapResponse GetWindSpeed()
        {
            WeatherMapResponse weatherMapResponse = new WeatherMapResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    WeatherMapRequest weatherMapRequest = new WeatherMapRequest()
                    {
                        CityName = WeatherMapConstants.City
                    };
                    var responseTask = client.GetAsync(ApiConstant.WebApUrl + ApiConstant.WindSpeedAction + weatherMapRequest.CityName);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();
                        var speed = readTask.Result;

                        var weatherInfo = JObject.Parse(speed).ToString();

                        var response = JsonConvert.DeserializeObject<WeatherMap>(weatherInfo);
                        weatherMapResponse.WindSpeed = response.Result.Data[0].Wind.Speed;
                        return weatherMapResponse;


                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogger exceptionLogger = new ExceptionLogger()
                {
                    ExceptionStackTrace = e.StackTrace,
                    ExceptionMessage = e.Message,
                    LogTime = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
                };
                weatherMapResponse.ExceptionLog = exceptionLogger;
            }
            
            return weatherMapResponse;
        }
    }
}
