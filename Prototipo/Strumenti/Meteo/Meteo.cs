using Prototipo.Grafica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Strumenti.Meteo
{
    public static class StrumentoMeteo
    {
        public static void Meteo()
        {
            Console.Clear();

            // test per il meteo
            var weatherData = new WeatherData();

            // renderizazzione interfaccia meteo
            WeatherRenderer.DrawWeather(weatherData);

            Console.ReadKey(); 
        }
    }
}