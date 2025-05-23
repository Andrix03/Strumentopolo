using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Strumenti.Meteo
{
    public class WeatherData
    {
        public string Location { get; set; } = "Roma, Italia";
        public string Conditions { get; set; } = "Soleggiato";
        public int Temperature { get; set; } = 24;
        public int Humidity { get; set; } = 45;
        public int WindSpeed { get; set; } = 10;
    }
}