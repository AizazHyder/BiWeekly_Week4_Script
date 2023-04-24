//Made Some Changes in the Code 
//Added a missing namespace declaration at the beginning of the code using System;
//Fixed a for loop condition inside the Main method that was iterating over the number of players instead of the number of users.
using System;

namespace MyApplication
{
    class Player
    {
        public string name;
        public string type;
        public string jersey;
        public float total_price;

        public Player(string n, string t, string j)
        {
            name = n;
            type = t;
            jersey = j;
            total_price = 0;
        }

        public void calculate_price()
        {
            if ((type.ToLower()) == "kids")
            {
                if ((jersey.ToLower()) == "yes")
                {
                    total_price = 150 + 100;
                }
                else
                {
                    total_price = 150;
                }
            }
            if ((type.ToLower()) == "adults")
            {
                if ((jersey.ToLower()) == "yes")
                {
                    total_price = 230 + 120;
                }
                else
                {
                    total_price = 230;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int no_of_user;
            int no_of_registration;
            int no_of_player;
            String name;
            String type;
            String jersey;

            Console.WriteLine("Welcome to Tigers Soccer Club");
            Console.WriteLine("Enter the total number of registrations:");
            no_of_registration = Convert.ToInt32(Console.ReadLine());

            do
            {
                Console.WriteLine("Enter the number of players per registration (1-4):");
                no_of_player = Convert.ToInt32(Console.ReadLine());
                if (no_of_player < 1 || no_of_player > 4)
                {
                    Console.WriteLine("The number of players per registration must be between 1 and 4");
                }
            } while (no_of_player < 1 || no_of_player > 4);

            Console.WriteLine("---------------------------------------------------\n");

            no_of_user = no_of_registration * no_of_player;
            Player[] p = new Player[no_of_user];

            for (int i = 0; i < no_of_user; i++)
            {
                Console.WriteLine("Enter player name:");
                name = Console.ReadLine();

                Console.WriteLine("Enter registration type (kids or adults):");
                type = Console.ReadLine();

                Console.WriteLine("Enter yes/no to indicate whether you want a jersey:");
                jersey = Console.ReadLine();

                p[i] = new Player(name, type, jersey);
                p[i].calculate_price();

                Console.WriteLine("---------------------------------------------------\n");
            }

            Console.WriteLine("                    Summary of Registration\n");
            float max = p[0].total_price;
            float min = p[0].total_price;

            for (int i = 0; i < no_of_user; i++)
            {
                if (p[i].total_price > max)
                {
                    max = p[i].total_price;
                }
                if (p[i].total_price < min)
                {
                    min = p[i].total_price;
                }
            }

            Console.WriteLine("---------------------------------------------------\n");
            Console.WriteLine("Name                 Type         Jersey     Cost");

            for (int i = 0; i < no_of_user; i++)
            {
                Console.WriteLine($"{p[i].name,-20}{p[i].type,-12}{p[i].jersey,-10}{p[i].total_price:C}");
            }

            Console.WriteLine("---------------------------------------------------\n");
            string output = "The player spending most:    ";

            for (int i = 0; i < no_of_user; i++)
            {
                if (p[i].total_price == max)
                {
                    output += p[i].name + ", ";
                }
            }
            output = output.TrimEnd(',', ' '); // Remove the last comma and space from the string
Console.WriteLine(output);
    // Calculate and display the total registration cost
        float total_cost = 0;
        for (int i = 0; i < no_of_user; i++)
        {
            total_cost += p[i].total_price;
        }
        Console.WriteLine("\n\nTotal registration cost: $" + total_cost);

        Console.WriteLine("\n\nPress any key to exit.");
        Console.ReadKey();
    }

}