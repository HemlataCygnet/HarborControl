namespace UI.Utility
{
    public  class BoatConstant
    {
        public const  int SpeedBoatSpeed = 30;
        public const int SailBoatSpeed = 15;
        public const int CargoShipSpeed = 5;
        public const double WindMinSpeed = 10;
        public const double WindMaxSpeed = 30;
        public const decimal Perimeter = 10;

    }

    public class ApiConstant
    {
        public const string WebApUrl = "http://localhost:1859/api/";
        public const string WindSpeedAction = "weathermap/windspeed/?city=";


    }

    public class WeatherMapConstants
    {
        public const string City = "Ahmedabad,IN";
    }
}