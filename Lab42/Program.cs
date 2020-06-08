using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public class First
    {
        public string Name { get; set; }
        public uint Value1 { get; set; }

        public uint Price { get; set; }
    }

    public class Second
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<First> product = new List<First>();
            List<Second> product2 = new List<Second>();
            List<First> result = new List<First>();
            uint quant,value1;
            Console.WriteLine("Кiлькiсть виробiв:"); 
            string quant1 = Console.ReadLine();
            while (!uint.TryParse(quant1, out quant))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Кiлькiсть виробiв:");
                quant1 = Console.ReadLine();
            }
            quant = Convert.ToUInt32(quant1);
            for (int i = 0; i < quant; i++)
            {
                Console.WriteLine("\nНазва " + (i + 1) + " виробу: ");
                string name = Console.ReadLine();
                Console.WriteLine("Вартiсть одиницi виробу:");
                string val1 = Console.ReadLine();
                while (!uint.TryParse(val1, out value1))
                {
                    Console.WriteLine("Невiрне значення");
                    Console.Write("Вартiсть одиницi виробу:");
                    val1 = Console.ReadLine();
                }
                value1 = Convert.ToUInt32(val1);
                product.Insert(i,new First(){Name=name,Value1 = value1});
            }
            
            uint quant2, val3;
            Console.WriteLine("Кiлькiсть записiв:"); 
            string quant3 = Console.ReadLine();
            while (!uint.TryParse(quant3, out quant2))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Кiлькiсть записiв:");
                quant3 = Console.ReadLine();
            }
            quant2 = Convert.ToUInt32(quant3);
            for (int i = 0; i < quant2; i++)
            {
                Console.WriteLine("\nДата(дд.мм.рр):");
                DateTime date;
                string date1=Console.ReadLine();
                while (!DateTime.TryParse(date1, out date))
                {
                    Console.WriteLine("Невiрне значення");
                    Console.Write("Дата(дд.мм.рр):");
                    date1 = Console.ReadLine();
                }
                date = Convert.ToDateTime(date1);
                var dateonly = date.ToShortDateString();
                Console.WriteLine("Назва " + (i + 1) + " виробу: ");
                string name1 = Console.ReadLine();
                Console.WriteLine("Кiлькiсть:");
                string val2 = Console.ReadLine();
                while (!uint.TryParse(val2, out val3))
                {
                    Console.WriteLine("Невiрне значення");
                    Console.Write("Кiлькiсть:");
                    val2 = Console.ReadLine();
                }
                uint quantity = Convert.ToUInt32(val3);
                product2.Insert(i,new Second(){Date = dateonly, Name=name1,Quantity = quantity});
            }
            Console.WriteLine("|{0,-30}|{1,-25}|","Назва виробу","Вартiсть одиницi виробу");
            foreach (var variable in product) 
            {
                Console.WriteLine("|{0,-30}|{1,-25}|" ,variable.Name, variable.Value1);
            }
            Console.WriteLine("\n|{0,-11}|{1,-30}|{2,-10}|","Дата","Назва виробу","Кiлькiсть");
            foreach (var variable1 in product2)
            {
                Console.WriteLine("|{0,-11}|{1,-30}|{2,-10}|",variable1.Date,variable1.Name,variable1.Quantity);
            }
            int j = 0;
            foreach (var name in product)
            {
                foreach (var name2 in product2)
                {
                    if (name.Name == name2.Name)
                    {
                        result.Insert(j, new First() {Name = name.Name, Price = name2.Quantity * name.Value1, Value1 = name.Value1});
                    }
                }
                j++;
            }
            List<First> sorted = result.OrderBy(one => one.Value1).ToList();
            Console.WriteLine("\n|{0,-30}|{1,-30}|{2,-20}|","Назва виробу","Загальна вартiсть","Вартiсть одиницi виробу");
            foreach (var variable in sorted)
            {
                Console.WriteLine("|{0,-30}|{1,-30}|{2,-23}|",variable.Name,variable.Price,variable.Value1);
            }
            
        }
    }
}