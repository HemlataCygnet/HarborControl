using Helper.Helpers;
using Helper.Models;
using System;
using System.Collections.Generic;
using UI.Models;

namespace UI.Utility
{
    public class GenerateRandomBoats
    {

        public static double windSpeed = 0;

        /// <summary>
        /// Get randome generated boats
        /// </summary>
        /// <param name="boatCount"></param>
        /// <returns></returns>
        public static Harbor Boats(int boatCount)
        {
            //Initialize indentifiers
            List<Boat> listBoat = new List<Boat>();
            Harbor harbor = new Harbor();

            //Get wind speed
            windSpeed = WindSpeed.GetWindSpeed().WindSpeed;

            //Convert to km/h
            windSpeed = windSpeed * 18 / 5;   
            
            //Loop to generate random boats
            for (int i = 1; i <= boatCount; i++)
            {
                string boatType = string.Empty;

                //Rule for enter sailboat based on wind speed
                do
                {
                    boatType = GetEnumValue.RandomEnumValue<BoatType>().ToString();

                } while (boatType == "SailBoat" && (windSpeed < BoatConstant.WindMaxSpeed || windSpeed > BoatConstant.WindMaxSpeed));

                //Boat class object
                Boat boat = new Boat
                {
                    BoatType = boatType,
                    Id = i
                };
                boat.Speed = Speed(boatType);
                boat.TimeElapse = RoundUp( 10 / boat.Speed) * 60;
                listBoat.Add(boat);
            }
            harbor.Boats = listBoat;
            harbor.WindSpeed = windSpeed;
            return harbor;
        }



        /// <summary>
        /// Speed of boat
        /// </summary>
        /// <param name="boatType"></param>
        /// <returns></returns>
        public static int Speed(string boatType)
        {
            int speed = 0;
            switch (boatType)
            {
                case "Speed":
                    speed = BoatConstant.SpeedBoatSpeed;
                    break;

                case "SailBoat":
                    speed = BoatConstant.SailBoatSpeed;
                    break;

                case "Cargo":
                    speed = BoatConstant.CargoShipSpeed;
                    break;

            }

            return speed;
        }

        /// <summary>
        /// Round up decimal number for 2 places
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal RoundUp(decimal input)
        {
            decimal decimalVar = input;

            decimalVar = decimal.Round(decimalVar, 2, MidpointRounding.AwayFromZero);

            return  Math.Round(decimalVar, 2);
        }

    }
}