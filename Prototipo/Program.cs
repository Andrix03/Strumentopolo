using static Prototipo.MenuPrincipale;
using System.Media;
public class Program
{
    public static void Main()
    {
        Console.CursorVisible = false;

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        player.Stream = Prototipo.Properties.Resources.OST;
        player.PlayLooping();

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



