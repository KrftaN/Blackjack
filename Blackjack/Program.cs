using System;

Random random = new Random();
string senasteVinnaren = "Ingen har vunnit än";
string menyVal = "0";

while (menyVal != "4")
{
    // Skriv ut huvudmenyn
    Console.WriteLine("Välj från följande alternativ");
    Console.WriteLine("1. Spela Blackjack");
    Console.WriteLine("2. Visa senaste vinnaren");
    Console.WriteLine("3. Spelets regler");
    Console.WriteLine("4. Avsluta spelet");
    menyVal = Console.ReadLine();

    // Tom rad innan användarens val körs
    Console.WriteLine();

    switch (menyVal)
    {
        case "1": // Spela en omgång av 21:an
            int datornsPoäng = 0;
            int spelarensPoäng = 0;
            Console.WriteLine("Nu kommer båda spelarna dra två kort var");
            datornsPoäng += random.Next(1, 21);
            spelarensPoäng += random.Next(1, 21);
            Console.WriteLine($"Din poäng: {spelarensPoäng}");
            Console.WriteLine($"Datorns poäng: {datornsPoäng}");

            string val = "Ingenting";

            while (val != "n" && spelarensPoäng <= 21)
            {
                Console.WriteLine("Vill du ha ett till kort? (y/n)");
                val = Console.ReadLine();

                switch (val.ToLower())
                {
                    case "y":
                        int nyPoäng = random.Next(1, 11);
                        spelarensPoäng += nyPoäng;
                        Console.WriteLine($"Ditt nya kort är värt {nyPoäng} poäng");
                        Console.WriteLine($"Din totalpoäng är {spelarensPoäng}");

                        break;
                    case "n":
                        while (datornsPoäng <= 15)
                        {
                            int nyPoängDator = random.Next(1, 11);
                            datornsPoäng += nyPoängDator;
                            Console.WriteLine($"Datorn drog {nyPoängDator}");
                        }
                        break;

                    default:
                        Console.WriteLine("Du kan ENDAST välja mellan y/n.");
                        break;
                }

                if (spelarensPoäng > 21)
                {
                    Console.WriteLine("Du har mer än 21 och har förlorat");
                    break;
                }
                if (datornsPoäng < 15)
                {
                    int nyPoängDator = random.Next(1, 11);
                    datornsPoäng += nyPoängDator;
                    Console.WriteLine($"Datorn drog {nyPoängDator}");
                }

                Console.WriteLine($"Din poäng: {spelarensPoäng}");
                Console.WriteLine($"Datorns poäng: {datornsPoäng}");

                if (datornsPoäng > 21 || (val == "n" && (datornsPoäng < spelarensPoäng)))
                {
                    Console.WriteLine("Du har vunnit!");
                    Console.WriteLine("Skriv in ditt namn");
                    senasteVinnaren = Console.ReadLine();
                }
                else if (val == "n" && (datornsPoäng > spelarensPoäng))
                {
                    Console.WriteLine("Datorn har vunnit!");
                }
            }

            break;

        case "2": // Visa senaste vinnaren

            Console.WriteLine($"Senaste vinnaren: {senasteVinnaren}");
            break;

        case "3": // Spelets regler

            Console.WriteLine(
                "Ditt mål är att få så nära 21 poäng du kan utan att överstiga det.\nDatorn har exakt samma mål som dig och ifall datorn är närmare 21 än dig förlorar du.\nFör varje nytt kort du väljer kommer du få mellan 1-10 poäng."
            );

            break;

        case "4": // Avsluta spelet

            break;

        default:
            Console.WriteLine("Du valde inte ett giltigt alternativ");
            break;
    }

    // Tom rad innan nästa körning
    Console.WriteLine();
}
