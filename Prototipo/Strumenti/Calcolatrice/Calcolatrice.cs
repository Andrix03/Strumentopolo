using Prototipo.Grafico;
using System;
using static Prototipo.Strumenti.Calcolatrice.MenuOperazione;


namespace Prototipo.Strumenti.Calcolatrice
{
    public static class StrumentoCalcolatrice
    {
        public static void Calcolatrice()
        {
            Console.Clear();
            CalcolatriceGraficoCompleto.CalcolatriceGrafico();

            Console.SetCursorPosition(90, 40);
            Console.WriteLine("Per favore inserire il primo numero: ");
            Console.SetCursorPosition(105, 41);
            double primoNumero = Convert.ToInt32(Console.ReadLine());



            Console.SetCursorPosition(80, 42);
            Console.WriteLine("Ottima scelta bimbo merda! Adesso inserisci il secondo numero: ");
            Console.SetCursorPosition(105, 43);
            double secondoNumero = Convert.ToInt32(Console.ReadLine());

            Console.SetCursorPosition(80, 44);
            Console.WriteLine("Benissimo! Adesso seleziona l'operazione da eseguire: ");

            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(75, 46);
                MenuOperazione.DrawMainMenuOperazione();

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        opzioneSelezionato = (opzioneSelezionato - 1 + opzioniMenu.Length) % opzioniMenu.Length;
                        break;
                    case ConsoleKey.RightArrow:
                        opzioneSelezionato = (opzioneSelezionato + 1) % opzioniMenu.Length;
                        break;
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(95, 48);
                        MenuOperazione.HandleMenuSelection(primoNumero, secondoNumero);

                        Console.SetCursorPosition(85, 49);
                        Console.WriteLine("Premi ESC per tornare al menù principale...");
                        
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }



        }
    }
}
