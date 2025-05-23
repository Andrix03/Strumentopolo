using System.Collections.Generic;
using Prototipo.Strumenti.Meteo;

namespace Prototipo.Grafica
{
    public static class WeatherRenderer
    {
        public static void DrawWeather(WeatherData data)
        {
            DrawTitle();
            DrawSunArt();
            DrawWeatherInfo(data);
            DrawInstruction();
        }

        private static void DrawTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string title = "=== METEO ===";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, 2);
            Console.WriteLine(title);
        }

        private static void DrawSunArt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] sunArt = {
                @"    \   /    ",
                @"     .-.      ",
                @"  ― (   ) ―   ",
                @"     `-᾿      ",
                @"    /   \     "
            };

            for (int i = 0; i < sunArt.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - sunArt[i].Length) / 2, 4 + i);
                Console.WriteLine(sunArt[i]);
            }
        }

        private static void DrawWeatherInfo(WeatherData data)
        {
            string[] weatherInfo = {
                $"Posizione: {data.Location}",
                $"Condizioni: {data.Conditions}",
                $"Temperatura: {data.Temperature}°C",
                $"Umidità: {data.Humidity}%",
                $"Velocità vento: {data.WindSpeed} km/h"
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((Console.WindowWidth - weatherInfo[0].Length) / 2, 10);
            Console.WriteLine(weatherInfo[0]);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((Console.WindowWidth - weatherInfo[1].Length) / 2, 11);
            Console.WriteLine(weatherInfo[1]);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((Console.WindowWidth - weatherInfo[2].Length) / 2, 12);
            Console.WriteLine(weatherInfo[2]);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition((Console.WindowWidth - weatherInfo[3].Length) / 2, 13);
            Console.WriteLine(weatherInfo[3]);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition((Console.WindowWidth - weatherInfo[4].Length) / 2, 14);
            Console.WriteLine(weatherInfo[4]);
        }

        private static void DrawInstruction()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string instruction = "[Premi un tasto per tornare al menu]";
            Console.SetCursorPosition((Console.WindowWidth - instruction.Length) / 2, 16);
            Console.WriteLine(instruction);
            Console.ResetColor();
        }
    }
}