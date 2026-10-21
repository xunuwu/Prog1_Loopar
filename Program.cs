namespace Prog1_Loopar;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("run code 4.{number}");
        Console.Write("number: ");
        int selection = int.Parse(Console.ReadLine()!);

        Action[] fns = [four_one, four_two, four_three, four_four, four_five, four_six, four_seven, four_eight, four_nine, four_ten, four_eleven, four_twelve];
        fns[--selection]();
    }

    static void four_one()
    {
        for (int i = 10; i <= 30; i++)
        {
            Console.WriteLine(i);
        }

        for (int i = 200; i >= 180; i--)
        {
            Console.WriteLine(i);
        }

        for (int i = 1000; i <= 1400; i+=50)
        {
            Console.WriteLine(i);
        }
    }

    static void four_two()
    {
        int max = int.MinValue;

        while (true)
        {
            Console.Write("ange ett tal: ");
            int num = int.Parse(Console.ReadLine()!);
            max = num > max ? num : max;
            Console.Write("vill du ange ett nytt tal? [y/n] ");

            if (Console.ReadLine()!.Trim().ToLower() == "n")
            {
                break;
            }
        }

        Console.WriteLine($"ditt högsta tal var: {max}");
    }

    static void four_three()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else {
                Console.WriteLine(i);
            }
        }
    }

    static void four_four()
    {
        // står inget om någon loop?

        Console.WriteLine("""
        Välj ett av följande alternativ.
        1. Subtrahera ett tal med ett annat
        2. Dividera ett tal med ett annat
        3. Avsluta programmet
        """);

        int choice = int.Parse(Console.ReadLine()!);
        if (choice != 1 && choice != 2) return;

        Console.Write("tal 1: ");
        int num1 = int.Parse(Console.ReadLine()!);

        Console.Write("tal 2: ");
        int num2 = int.Parse(Console.ReadLine()!);

        if (choice == 1)
        {
            Console.WriteLine($"resultat: {num1 - num2}");
        }
        else
        {
            Console.WriteLine($"resultat: {(double)num1 / num2}");
        }
    }

    static void four_five()
    {
        Console.WriteLine("Skriv in ett tal");
        var res = Console.ReadLine()!.Select(c => (char)(48 + ((1 + int.Parse($"{c}")) % 10)));
        Console.WriteLine($"result: {string.Concat(res)}");
    }

    static void four_six()
    {
        Console.WriteLine("Skriv in ditt meddelande");
        string msg = Console.ReadLine()!;

        Console.Write("hur mycket mellanrum före? ");
        int spaces = int.Parse(Console.ReadLine()!);

        foreach (var c in msg)
        {
            Console.WriteLine($"{string.Concat(Enumerable.Repeat(" ", spaces))}{c}");
        }
    }

    static void four_seven()
    {
        Console.WriteLine("skriv in din text");
        string text = Console.ReadLine()!;
        
        // dåliga instruktioner. vadå programmet ska skriva in??
        Console.WriteLine("skriv in dina två bokstäver");
        string letters = Console.ReadLine()!;

        if (letters.All(text.Contains))
        {
            Console.WriteLine("din text innehåller dina bokstäver");
        }
        else
        {
            Console.WriteLine("din text innehåller inte dina bokstäver");
        }
    }

    static void four_eight()
    {
        Console.WriteLine("ange sidlängd: ");
        Console.WriteLine(string.Join('\n', Enumerable.Range(1, int.Parse(Console.ReadLine()!)).Select(i => string.Concat(Enumerable.Repeat('*', i)))));
    }

    static void four_nine()
    {
        Console.WriteLine("Hur många X per grupp?");
        int x_per_group = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Hur många O per grupp?");
        int o_per_group = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Hur många O-mönster per rad?");
        int o_patterns = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Hur många rader?");
        int rows = int.Parse(Console.ReadLine()!);
        Console.WriteLine();

        // i dont think c# is made for this.. would look a gazillion times
        // nicer in a language like f# probably
        Console.WriteLine(string.Join('\n', Enumerable.Repeat(string.Join(string.Concat(['-', .. Enumerable.Repeat('O', o_per_group), '-']), Enumerable.Repeat(string.Concat(Enumerable.Repeat('X', x_per_group)), o_patterns + 1)), rows)));
    }

    static void four_ten()
    {
        Console.WriteLine("mata in ett ord");
        string input = Console.ReadLine()!;
        foreach (var c in input.AggregateBy(c => c, _ => 0, (acc, c) => ++acc).Where(x => x.Value > 1).Select(x => x.Key))
        {
            Console.WriteLine($"'{c}' förekommer mer än 1 gång");
        }
    }

    static void four_eleven()
    {
        Console.WriteLine("Bestäm kvadratens sidlängd");
        int side = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Bestäm rutnätets bredd");
        int width = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Bestäm rutnätets höjd");
        int height = int.Parse(Console.ReadLine()!);

        string row = string.Join(' ', Enumerable.Repeat(string.Concat(Enumerable.Repeat('*', side)), width));
        string full_row = string.Join('\n', Enumerable.Repeat(row, side));
        string full_grid = string.Join("\n\n", Enumerable.Repeat(full_row, height));

        Console.WriteLine(full_grid);
    }

    static void four_twelve()
    {
        Console.WriteLine("skriv in ord 1");
        string word1 = Console.ReadLine()!;

        Console.WriteLine("skriv in ord 2");
        string word2 = Console.ReadLine()!;

        var counts1 = word1.AggregateBy(c => c, _ => 0, (acc, c) => ++acc);
        KeyValuePair<char, int>[] counts2 = [.. word2.AggregateBy(c => c, _ => 0, (acc, c) => ++acc)];

        foreach (var x in counts1)
        {
            // todo dont use first here!! sort of doesnt work
            var snd = counts2.FirstOrDefault(y => y.Key == x.Key).Value;

            if (snd != 0 && x.Value > snd)
            {
                Console.Write(x.Key);
            }
        }

        Console.WriteLine();
    }
}