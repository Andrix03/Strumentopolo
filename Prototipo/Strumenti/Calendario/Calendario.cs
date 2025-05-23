using System;

namespace Prototipo.Strumenti
{
    public static class StrumentoCalendario
    {
        public static void Calendario()
        {
            Console.Clear();
            DateTime giornoAttuale = DateTime.Now;
            int anno = giornoAttuale.Year;
            int mese = giornoAttuale.Month;

            while (true)
            {
                Console.Clear();
                DrawMese(anno, mese);

                var key = Console.ReadKey(true).Key;

                // switch mesi con le frecce
                if (key == ConsoleKey.LeftArrow) mese--;
                if (key == ConsoleKey.RightArrow) mese++;

                // Fix Bug per evitare che si sputtani il mese durante lo scorrimento
                if (mese < 1) { mese = 12; anno--; }
                if (mese > 12) { mese = 1; anno++; }
                if (key == ConsoleKey.Escape) return;
            }
        }

        private static void DrawMese(int anno, int mese)
        {
            // 1. Centrando il mese visualizzando i propri nomi
            string nomeMese = new DateTime(anno, mese, 1).ToString("MMMM yyyy");
            Console.SetCursorPosition((Console.WindowWidth - nomeMese.Length) / 2, 1);
            Console.WriteLine(nomeMese);

            // 2. Centrando il nome dei giorni della settimana
            string giorni = "Su Mo Tu We Th Fr Sa";
            Console.SetCursorPosition((Console.WindowWidth - giorni.Length) / 2, 3);
            Console.WriteLine(giorni);

            // 3. Calcolo del primo giorno del mese e il numero di giorni nel mese
            DateTime primoGiorno = new DateTime(anno, mese, 1);
            int giorniDelMese = DateTime.DaysInMonth(anno, mese);
            int primoGiornoSettimana = (int)primoGiorno.DayOfWeek; // 0 = Domenica, 6 = Sabato

            // 4. Stampa ogni settimana del mese
            int giorno = 1;
            for (int settimana = 0; settimana < 6; settimana++)
            {
                // Visualizza l'intera linea della settimana
                string settimanaLinea = "";
                for (int g = 0; g < 7; g++)
                {
                    if (settimana == 0 && g < primoGiornoSettimana)
                    {
                        settimanaLinea += "   "; // Spazio vuoto prima del primo giorno
                    }
                    else if (giorno > giorniDelMese)
                    {
                        settimanaLinea += "   "; // Spazio vuoto dopo l'ultimo giorno
                    }
                    else
                    {
                        //  Evidenziando il giorno attuale
                        if (giorno == DateTime.Now.Day && mese == DateTime.Now.Month && anno == DateTime.Now.Year)
                            settimanaLinea += $"[{giorno,2}]";
                        else
                            settimanaLinea += $"{giorno,2} ";

                        giorno++;
                    }
                }

                // Infine posizione del cursore per stampare la settimana centrata
                Console.SetCursorPosition((Console.WindowWidth - settimanaLinea.Length) / 2, 5 + settimana);
                Console.WriteLine(settimanaLinea);
            }
        }
    }
}