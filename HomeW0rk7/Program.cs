using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HomeW0rk7
{
    [Serializable]
    class Book
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string name, int price, string author, int year)
        {
            Name = name; Price = price; Author = author; Year = year;
        }

        public void Show()
        {
            Console.WriteLine($"Название: {Name}" +
                $"\nАвтор: {Author}" +
                $"\nГод: {Year}" +
                $"\nЦена: {Price} \n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Book first = new Book("Унесенные ветром", 5000, "Маргарет Митчелл", 2017);
            Book second = new Book("Записки юного врача", 4000, "Михаил Булгаков", 2013);
            List<Book> list = new List<Book>();
            list.Add(first); list.Add(second);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = File.Create("Books.txt"))
            {
                formatter.Serialize(fs, list);
            }

            using (FileStream fs = new FileStream("Books.txt", FileMode.Open))
            {
                List<Book> newList = (List<Book>)formatter.Deserialize(fs);

                foreach (var book in newList)
                {
                    book.Show();
                }
            }
        }
    }
}