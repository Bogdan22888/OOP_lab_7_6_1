using System;

namespace Lab07___6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file name to get info: ");
            string filename = Console.ReadLine();

            Magazines magazines = new Magazines();
            magazines.ReadData(filename);

            Array.Sort(magazines.GetArray(), new Magazine.SortByRating());

            int index = 1;
            foreach (Magazine m in magazines.GetArray())
            {
                Console.WriteLine("Person #" + index + ":");
                Console.WriteLine("Size: " + m.height + "x" + m.width);
                Console.WriteLine("Pages amount:" + m.pagesAmount);
                Console.WriteLine("Price: $" + m.price);
                Console.WriteLine("Rating: " + m.rating + "/100");
                Console.WriteLine();
                index++;
            }

            Console.ReadKey();
        }
    }
}
