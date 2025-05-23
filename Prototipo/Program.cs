using static Prototipo.MenuPrincipale;
public class Program
{
    public static void Main()
    {
        Console.CursorVisible = false;

        while (true)
        {

            DrawMainMenu();

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    opzioneSelezionato = (opzioneSelezionato - 1 + opzioniMenu.Length) % opzioniMenu.Length;
                    Console.Beep();
                    break;
                case ConsoleKey.RightArrow:
                    opzioneSelezionato = (opzioneSelezionato + 1) % opzioniMenu.Length;
                    Console.Beep();
                    break;
                case ConsoleKey.Enter:
                    HandleMenuSelection();
                    Console.Beep();
                    break;
                case ConsoleKey.Escape:
                    Console.Beep();
                    return;
            }
        }
    }
}



