using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Utility
{
    public static class GetEnumValue
    {

        public static Random _R = new Random();

        /// <summary>
        /// Generic method to pick enum values ramdom
        /// </summary>
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }
    }
}