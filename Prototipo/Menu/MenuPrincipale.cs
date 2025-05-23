using Prototipo.Grafico;
using static Prototipo.Strumenti.Calcolatrice.StrumentoCalcolatrice;
using static Prototipo.Strumenti.StrumentoCalendario;
using static Prototipo.Strumenti.Meteo.StrumentoMeteo;
using static Prototipo.Strumenti.Taccuino.StrumentoTaccuino;

namespace Prototipo
{
    public static class MenuPrincipale
    {
        public static int opzioneSelezionato = 0;
        public static string[] opzioniMenu = {
        "CALCOLATRICE",
        "CALENDARIO",
        "METEO",
        "BLOCCO NOTE",
        "TELEFONO"
        };

        public static void DrawMainMenu()
        {
            Console.Clear();
            StrumentopoloGrafico.Strumentopolo();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("                                                             ");

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

        public static void HandleMenuSelection()
        {
            switch (opzioneSelezionato)
            {
                case 0:
                    Calcolatrice();
                    Console.Beep();
                    break;
                case 1:
                    Calendario();
                    Console.Beep();
                    break;
                case 2:
                    Meteo();
                    Console.Beep();
                    break;
                case 3:
                    Taccuino();
                    Console.Beep();
                    break;
                case 5:
                     Environment.Exit(0);
                    Console.Beep();
                    break;
                }



            }


        }
    }

