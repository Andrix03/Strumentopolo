using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Strumenti.Taccuino
{
    public static class FileManager
    {
        private static readonly string StorageFolder =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BloccoNoteApp");

        static FileManager()
        {
            if (!Directory.Exists(StorageFolder))
            {
                Directory.CreateDirectory(StorageFolder);
            }
        }

        public static void SalvataggioFile(string nomeFile, string contenuto)
        {
            try
            {
                string filePath = Path.Combine(StorageFolder, $"{nomeFile}.txt");
                File.WriteAllText(filePath, contenuto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante il salvataggio: {ex.Message}");
            }
        }

        public static string[] GetSavedFiles()
        {
            return Directory.GetFiles(StorageFolder, "*.txt")
                         .Select(Path.GetFileNameWithoutExtension)
                         .OrderBy(f => f)
                         .ToArray();
        }

        public static string CaricaFile(string nomeFile)
        {
            try
            {
                string filePath = Path.Combine(StorageFolder, $"{nomeFile}.txt");
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante il caricamento: {ex.Message}");
            }
        }

        public static void EliminaFile(string nomeFile)
        {
            try
            {
                string filePath = Path.Combine(StorageFolder, $"{nomeFile}.txt");
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante l'eliminazione: {ex.Message}");
            }
        }
    }
}