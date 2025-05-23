using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Strumenti.Calcolatrice
{
    public static class MenuOperazione
    {

            public static int opzioneSelezionato = 0;
            public static string[] opzioniMenu =
            {
            "SOMMA",
            "SOTTRAZIONE",
            "MOLTIPLICAZIONE",
            "DIVISIONE"
            };

            public static void DrawMainMenuOperazione()
            {
            
            for (int i = 0; i < opzioniMenu.Length; i++)
                {
                    if (i == opzioneSelezionato)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($" {(i == opzioneSelezionato ? ">" : " ")} {opzioniMenu[i]}");
                    Console.Write("    ");

                    if (i == opzioneSelezionato)
                    {
                        Console.ResetColor();
                    }
                }
            
        }

        public static void HandleMenuSelection(double primoNumero, double secondoNumero)
        {



            switch (opzioneSelezionato)
            {
                case 0:
                    CalcolatriceOperazioni.Somma(primoNumero, secondoNumero);
                    Console.Beep();
                    break;

                case 1:
                    CalcolatriceOperazioni.Sottrazione(primoNumero, secondoNumero);
                    Console.Beep();
                    break;

                case 2:
                    CalcolatriceOperazioni.Moltiplicazione(primoNumero, secondoNumero);
                    Console.Beep();
                    break;

                case 3:
                    CalcolatriceOperazioni.Divisione(primoNumero, secondoNumero);
                    Console.Beep();
                    break;

                case 4:
                    Environment.Exit(0);
                    Console.Beep();
                    break;
            }
        }
    }

}



