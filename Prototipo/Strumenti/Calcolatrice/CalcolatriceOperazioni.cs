
namespace Prototipo.Strumenti.Calcolatrice { 

	public class CalcolatriceOperazioni
	{

        public static void Somma(double primoNumero, double secondoNumero)
		{
			double risultato = primoNumero + secondoNumero;
			Console.WriteLine($"La somma tra {primoNumero} e {secondoNumero} è {risultato}");
            
        }

		public static void Sottrazione(double primoNumero, double secondoNumero)
		{
			double risultato = primoNumero - secondoNumero;
            Console.WriteLine($"La sottrazione tra {primoNumero} e {secondoNumero} è {risultato}");
           
        }

		public static void Moltiplicazione(double primoNumero, double secondoNumero)
		{
			double risultato = primoNumero * secondoNumero;
            Console.WriteLine($"La moltiplicazione tra {primoNumero} e {secondoNumero} è {risultato}");
          ;
        }

		public static void Divisione(double primoNumero, double secondoNumero)
		{
			double risultato = primoNumero / secondoNumero;
            Console.WriteLine($"La divisione tra {primoNumero} e {secondoNumero} è {risultato}");
           
        }
	}
}
