using System;
using System.Collections.Generic;
using System.Text;

class MainClass{
static void Main(string[] args)
{
  Keuze keuze1 = new Keuze("You wonder into a cave.");
  Keuze keuze2 = new Keuze("You go further in.");
  Keuze keuze3 = new Keuze("You exit the cave and walk away.");

  Connect(keuze1, keuze2, "Explore.");
  Connect(keuze1, keuze3, "Leave.");

  Keuze keuze4 = new Keuze("There is ancient text written on the wall!");
  Keuze keuze5 = new Keuze("The ground is full of bugs!");
  Keuze keuze6 = new Keuze("The spider scares you!");

  Connect(keuze2, keuze4, "You take out your flashlight.");
  Connect(keuze2, keuze5, "You look at the ground.");
  Connect(keuze2, keuze6, "You notice the spider.");

  Connect(keuze4, keuze3, "You will find the enterence with your flashlight.");
  Connect(keuze5, keuze3, "You will run back to the enterence.");
  Connect(keuze6, keuze3, "You will stumble across the enterence.");

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
