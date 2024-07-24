using System;
using System.Collections.Generic;
using System.Text;

class MainClass{
static void Main(string[] args)
{
  Keuze keuze1 = new Keuze("Je loopt een bos in.");
  Keuze keuze2 = new Keuze("Je volgt het pad dieper het bos in.");
  Keuze keuze3 = new Keuze("Je keert terug naar het begin van het pad.");

  Connect(keuze1, keuze2, "Verken.");
  Connect(keuze1, keuze3, "Keer terug.");

  Keuze keuze4 = new Keuze("Je vindt een oude schatkaart!");
  Keuze keuze5 = new Keuze("Je ziet een groep wilde dieren!");
  Keuze keuze6 = new Keuze("Je hoort mysterieuze geluiden!");

  Connect(keuze2, keuze4, "Je pakt de kaart op.");
  Connect(keuze2, keuze5, "Je verstopt je achter een boom.");
  Connect(keuze2, keuze6, "Je volgt de geluiden.");

  Connect(keuze4, keuze3, "Je besluit terug te keren met de kaart.");
  Connect(keuze5, keuze3, "Je rent terug naar het begin van het pad.");
  Connect(keuze6, keuze3, "Je raakt verdwaald en keert terug.");

    Keuze head = keuze1;

    while (true)
    {
        Console.WriteLine($"{head.antwoord}");
        int count = 1;
        if (head.keuzes.Count == 0)
        {
            break;
        }
        for (int i = 0; i < head.keuzes.Count; i++)
        {
            Console.WriteLine($"{count}. {head.connectionString[i]}");
            count++;
        }
        while(true){
            Console.WriteLine("Kies je pad: ");

            try{
                int input = int.Parse(Console.ReadLine());
                head = head.keuzes[input - 1];
                break;
            } catch (Exception){
                Console.WriteLine("Ongeldige invoer, probeer opnieuw.");

            }
        }
    }
}
    public static bool Connect(Keuze c1, Keuze c2, string connection)
    {
        if (c1.keuzes.Contains(c2))
        {
            return false;
        }
        c1.keuzes.Add(c2);
        c1.connectionString.Add(connection);
        return true;
    }
}

public class Keuze
{
    public string antwoord;
    public List<Keuze> keuzes;
    public List<string> connectionString;

    public Keuze(string antwoord)
    {
        this.antwoord = antwoord;
        keuzes = new List<Keuze>();
        connectionString = new List<string>();
    }
}
