using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Strumenti.Taccuino
{
    public static class TaccuinoInterfaccia
    {
        public static void DrawTaccuino(TaccuinoModel data)
        {
            Console.Clear();
            DrawTitolo(data.FileNome);
            DrawContenuto(data.Contenuto);
            DrawFooter();
        }

        private static void DrawTitolo(string nomeFIle)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string titolo = string.IsNullOrEmpty(nomeFIle)
                ? "=== BLOCCO NOTE ==="
                : $"=== {nomeFIle.ToUpper()} ===";

            Console.SetCursorPosition((Console.WindowWidth - titolo.Length) / 2, 1);
            Console.WriteLine(titolo);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            string divider = new string('═', Console.WindowWidth - 4);
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(divider);
        }

        private static void DrawContenuto(string contenuto)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Contenuto:");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine(new string('─', Console.WindowWidth - 6));

            // aggisuta il contenuto in base alla lunghezza delle frasi
            int yPos = 6;
            int maxWidth = Console.WindowWidth - 6;
            string[] parola = contenuto.Split(' ');
            string linea = "";

            foreach (string parole in parola)
            {
                if ((linea + parole).Length > maxWidth)
                {
                    Console.SetCursorPosition(3, yPos++);
                    Console.WriteLine(linea);
                    linea = "";
                }
                linea += parole + " ";
            }

            if (!string.IsNullOrWhiteSpace(linea))
            {
                Console.SetCursorPosition(3, yPos);
                Console.WriteLine(linea);
            }
        }

        public static void DrawListaFile(string[] files, OperazioneFile operation)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string titolo = $"=== {operation.ToString().ToUpper()} FILE ===";
            Console.SetCursorPosition((Console.WindowWidth - titolo.Length) / 2, 1);
            Console.WriteLine(titolo);

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("File disponibili:");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine(new string('─', Console.WindowWidth - 6));

            if (files.Length == 0)
            {
                Console.SetCursorPosition(3, 6);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Nessun file salvato");
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    Console.SetCursorPosition(3, 6 + i);
                    Console.WriteLine($"{i + 1}. {files[i]}");
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(3, Console.WindowHeight - 3);
            Console.WriteLine("[Numero] Seleziona file  [N] Nuovo file  [ESC] Annulla");

            if (operation == OperazioneFile.Load || operation == OperazioneFile.Delete)
            {
                Console.SetCursorPosition(3, Console.WindowHeight - 2);
                Console.WriteLine("[D] Elimina file (solo in modalità caricamento)");
            }
        }

        public static void ShowMessage(string messaggio, ConsoleColor colore)
        {
            Console.SetCursorPosition(3, Console.WindowHeight - 1);
            Console.ForegroundColor = colore;
            Console.WriteLine(messaggio);
            Task.Delay(1500).Wait();
        }

        private static void DrawFooter()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(3, Console.WindowHeight - 3);
            Console.WriteLine("[F4] Salva  [F5] Carica  [F6] Elimina  [F7] Cancella  [ESC] Esci");
        }
    }

    public enum OperazioneFile
    {
        Save,
        Load,
        Delete
    }
}