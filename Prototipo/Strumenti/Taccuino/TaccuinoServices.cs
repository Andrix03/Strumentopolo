using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Strumenti.Taccuino
{
    public static class StrumentoTaccuino
    {
        public static void Taccuino()
        {
            var taccuino = new TaccuinoModel();
            bool exit = false;

            while (!exit)
            {
                TaccuinoInterfaccia.DrawTaccuino(taccuino);
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;

                    case ConsoleKey.C:
                        taccuino.Contenuto = string.Empty;
                        taccuino.FileNome = string.Empty;
                        break;

                    case ConsoleKey.S:
                        HandleFileOperation(taccuino, OperazioneFile.Save);
                        break;

                    case ConsoleKey.L:
                        HandleFileOperation(taccuino, OperazioneFile.Load);
                        break;

                    case ConsoleKey.D:
                        HandleFileOperation(taccuino, OperazioneFile.Delete);
                        break;

                    case ConsoleKey.Backspace:
                        if (taccuino.Contenuto.Length > 0)
                            taccuino.Contenuto = taccuino.Contenuto[..^1];
                        break;

                    default:
                        if (!char.IsControl(key.KeyChar))
                        {
                            taccuino.Contenuto += key.KeyChar;
                        }
                        break;
                }
            }
        }

        private static void HandleFileOperation(TaccuinoModel taccuino, OperazioneFile operazione)
        {
            try
            {
                var files = FileManager.GetSavedFiles();
                TaccuinoInterfaccia.DrawListaFile(files, operazione);

                while (true)
                {
                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                        return;

                    if (char.IsDigit(key.KeyChar) && files.Length > 0)
                    {
                        int fileIndex = (int)char.GetNumericValue(key.KeyChar) - 1;
                        if (fileIndex >= 0 && fileIndex < files.Length)
                        {
                            string selectedFile = files[fileIndex];

                            if (operazione == OperazioneFile.Load)
                            {
                                taccuino.Contenuto = FileManager.CaricaFile(selectedFile);
                                taccuino.FileNome = selectedFile;
                                TaccuinoInterfaccia.ShowMessage($"File '{selectedFile}' caricato con successo!", ConsoleColor.Green);
                            }
                            else if (operazione == OperazioneFile.Delete)
                            {
                                FileManager.EliminaFile(selectedFile);
                                TaccuinoInterfaccia.ShowMessage($"File '{selectedFile}' eliminato con successo!", ConsoleColor.Green);
                            }
                            return;
                        }
                    }
                    else if (key.Key == ConsoleKey.N && operazione == OperazioneFile.Save)
                    {
                        Console.SetCursorPosition(3, Console.WindowHeight - 2);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Nome file: ");
                        string fileName = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(fileName))
                        {
                            FileManager.SalvataggioFile(fileName, taccuino.Contenuto);
                            taccuino.FileNome = fileName;
                            TaccuinoInterfaccia.ShowMessage($"File '{fileName}' salvato con successo!", ConsoleColor.Green);
                            return;
                        }
                    }
                    else if (key.Key == ConsoleKey.D && operazione == OperazioneFile.Load && files.Length > 0)
                    {
                        TaccuinoInterfaccia.DrawListaFile(files, OperazioneFile.Delete);
                    }
                }
            }
            catch (Exception ex)
            {
                TaccuinoInterfaccia.ShowMessage($"Errore: {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}