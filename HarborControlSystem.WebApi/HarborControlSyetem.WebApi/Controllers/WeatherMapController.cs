using Common.Constants;
using Service.Contracts.IWeatherMap;
using Service.Services.WeatherMap;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UI.ErrorLog;
using UI.Models;

namespace HarborControlSyetem.WebApi.Controllers
{
    [ExceptionHandler]
    public class WeatherMapController : ApiController
    {
        //Weather service readonly object
        private readonly IWeatherMap _WeatherMapService;

        //constructor to initialize readonly weather service object
        public WeatherMapController() {

            _WeatherMapService = new WeatherMap() ;
        }

        /// <summary>
        /// Get weather information vased on city 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]       
        public async Task<HttpResponseMessage> GetWindSpeed(string city)
        {
            try
            {
              
                var responseContent = await _WeatherMapService.GetCityWeatherMap(city);
                return Request.CreateResponse(HttpStatusCode.OK, new WebApiResponse(HttpStatusCode.OK, responseContent, true, WeatherMapConstants.WeatherInfo));
            }
            catch(Exception e)
            {
                ExceptionLogger exceptionLogger = new ExceptionLogger()
                {
                    ExceptionStackTrace = e.StackTrace,
                    ExceptionMessage = e.Message,
                    LogTime = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
                };
                ErrorLogging.LogError(exceptionLogger);
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
