using Lab2;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n\nMeniu Principal:");
            Console.WriteLine("1. Utilizează RSA");
            Console.WriteLine("2. Utilizează DES");
            Console.WriteLine("3. Utilizează DSA");
            Console.WriteLine("4. Iesire");
            Console.Write("Alegeti o optiune: ");

            string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Rsa.UseRsa();
                    break;

                case "2":
                    Des.UseDes();
                    break;

                case "3":
                    Dsa.UseDsa();
                    break;

                case "4":
                    Console.WriteLine("Iesire din program.");
                    return;

                default:
                    Console.WriteLine("Opțiune invalidă, încercați din nou.");
                    break;
            }
        }
    }

}
