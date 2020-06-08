using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab43
{
    class  MetaData
    {
        private string date;
        private string city;
        private int presure;
        private int temperature;
        private double speed;
        public MetaData(){}

        public string Date
        {
            get { return date;}

            set { date = value;}
        }
        public string City
        {
            get { return city;}
            set { city = value;}
        }
        public int Presure
        {
            get { return presure;}
            set { presure = value;}
        }
        public int Temperature
        {
            get { return temperature;}
            set { temperature = value;}
        }
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private string Checkdate(string date1)
        {
            DateTime dateTime;
            while (!DateTime.TryParse(date1, out dateTime))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Дата(дд/мм/рр):");
                date1 = Console.ReadLine();
            }
            dateTime = Convert.ToDateTime(date1);
            date1=dateTime.ToShortDateString();
            return date1;
        }

        private string Checkcity(string city1)
        {
            while (string.IsNullOrEmpty(city1))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Місто:");
                city1 = Console.ReadLine();
            }

            return city1;
        }

        private int Checkpresure(string presure)
        {
            int result = 0;
            while (!int.TryParse(presure, out result))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Атмосферний тиск:");
                presure = Console.ReadLine();
            }
            result = Convert.ToInt32(presure);
            
            return result;
        }

        private int Checktemperature(string temperature)
        {
            int result;
            while (!int.TryParse(temperature, out result))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Температура повітря:");
                temperature = Console.ReadLine();
            }
            result = Convert.ToInt32(temperature);
            return result;
        }

        private double Checkspeed(string speed)
        {
            double result;
            while (!double.TryParse(speed, out result))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Швидкість вітру:");
                speed = Console.ReadLine();
            }
            result = Convert.ToDouble(speed);
            return result;
        }
        public void Add()
        {
            Console.InputEncoding= Encoding.Unicode;
            MetaData add=new MetaData();
            Console.WriteLine("Дата(дд.мм.рр):");
            string date1=Console.ReadLine();
            add.Date = Checkdate(date1);
            Console.WriteLine("Місто:");
            string city1 = Console.ReadLine();
            add.City = Checkcity(city1);
            Console.WriteLine("Атмосферний тиск(у межах 684—809 мм рт. ст.):");
            string presure1 = Console.ReadLine();
            add.Presure = Checkpresure(presure1);
            while (add.Presure<684 || add.Presure >809)
            {
                Console.WriteLine("Діапазон значень тиску: 684-809 мм рт. ст.");
                presure1 = Console.ReadLine();
                add.Presure = Checkpresure(presure1);
            }
            Console.WriteLine("Температура повітря(°C):");
            string temperature = Console.ReadLine();
            add.Temperature = Checktemperature(temperature);
            while (add.Temperature < -100 || add.Temperature > 60)
            {
                Console.WriteLine("Діапазон значень температури: -100° - +60°");
                temperature = Console.ReadLine();
                add.Temperature = Checktemperature(temperature);
            }
            Console.WriteLine("Швидкість вітру (м/с):");
            string speed = Console.ReadLine();
            add.Speed = Checkspeed(speed);
            while (add.Speed<0 || add.Speed >113)
            {
                Console.WriteLine("Діапазон швидкості вітру: 0-113 м/с");
                speed = Console.ReadLine();
                add.Speed = Checkspeed(speed);
            }
            Console.WriteLine("\nЗбереження змін - Enter, відміна - будь-яка інша клавіша.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                using(StreamWriter f = new StreamWriter("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt",true))
                    f.WriteLine("{0,-12}{1,-16}{2,-8}{3,-8}{4,-3}",add.Date,add.City,add.Presure,add.Temperature,add.Speed);
            }
            else{Console.WriteLine("\nЗмiни не збережено\n");}
        }
        private int Checknum(string number1)
        {
            int result = 0;
            while (!int.TryParse(number1, out result))
            {
                Console.WriteLine("Невiрне значення");
                Console.Write("Номер:");
                number1 = Console.ReadLine();
            }
            result = Convert.ToInt32(number1);
            return result;
        }
        public void Edit()
        {
            MetaData edit = new MetaData();
            int length = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt").Length;
            Console.WriteLine("Номер рядку:");
            int number = Checknum(Console.ReadLine());
            while(number>length-1 || number <=0)
            {
                Console.WriteLine("Номер рядку не може бути менше нуля або більше "+(length-1));
                number = Checknum(Console.ReadLine());
            }
            string[] str = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt");
            string line = str[number-1];
            edit.Date = line.Substring(0, 11);
            edit.City = line.Substring(12, 15);
            edit.Presure = Convert.ToInt32(line.Substring(28, 7));
            edit.Temperature = Convert.ToInt32(line.Substring(36, 7));
            edit.Speed = Convert.ToDouble(line.Substring(44, 3));
            Console.WriteLine("Введiть номер елементу стовпчика, який потрібно змінити: ");
            int number1 = Checknum(Console.ReadLine());
            while(number1>5 || number1 <=0)
            {
                Console.WriteLine("Номер стовпчика не може бути менше нуля або більше п'яти");
                number1 = Checknum(Console.ReadLine());
            }

            if (number1 == 1)
            {
                Console.WriteLine("Дата(дд/мм/рр):");
                string date1=Console.ReadLine();
                edit.Date = Checkdate(date1);
            }

            if (number1 == 2)
            {
                Console.WriteLine("Місто:");
                string city1 = Console.ReadLine();
                edit.City = Checkcity(city1);
            }

            if (number1 == 3)
            {
                Console.WriteLine("Атмосферний тиск(у межах 684—809 мм рт. ст.):");
                string presure1 = Console.ReadLine();
                edit.Presure = Checkpresure(presure1);
                while (edit.Presure<684 || edit.Presure >809)
                {
                    Console.WriteLine("Діапазон значень тиску: 684-809 мм рт. ст.");
                    presure1 = Console.ReadLine();
                    edit.Presure = Checkpresure(presure1);
                }
            }

            if (number1 == 4)
            {
                Console.WriteLine("Температура повітря(°C):");
                string temperature = Console.ReadLine();
                edit.Temperature = Checktemperature(temperature);
                while (edit.Temperature < -100 || edit.Temperature > 60)
                {
                    Console.WriteLine("Діапазон значень температури -100° - +60°");
                    temperature = Console.ReadLine();
                    edit.Temperature = Checktemperature(temperature);
                }
            }

            if (number1 == 5)
            {
                Console.WriteLine("Швидкість вітру (м/с):");
                string speed = Console.ReadLine();
                edit.Speed = Checkspeed(speed);
                while (edit.Speed<0 || edit.Speed >113)
                {
                    Console.WriteLine("Діапазон швидкості вітру: 0-113 м/с");
                    speed = Console.ReadLine();
                    edit.Speed = Checkspeed(speed);
                }
            }
            Console.WriteLine("\nЗбереження змін - Enter, відміна - будь-яка інша клавіша.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                using (StreamWriter f = new StreamWriter("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt")) 
                    for (int i = 0; i < length; i++)
                    {
                        if(i!=number-1) f.WriteLine(str[i]);
                        else f.WriteLine("{0,-12}{1,-16}{2,-8}{3,-8}{4,-3}",edit.Date,edit.City,edit.Presure,edit.Temperature,edit.Speed);
                    }
                Console.WriteLine("Змiни збережено\n");
            }
            else
            {
                Console.WriteLine("\nЗмiни не збережено\n");
            }
        }

        public void Delete()
        {
            MetaData delete = new MetaData();
            int length = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt").Length;
            Console.WriteLine("Номер рядку:");
            int number = Checknum(Console.ReadLine());
            while(number>length-1 || number <=0)
            {
                Console.WriteLine("Номер рядку не може бути менше нуля або більше "+(length-1));
                number = Checknum(Console.ReadLine());
            }
            string[] str = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt");
            Console.WriteLine("\nЗбереження змін - Enter, відміна - будь-яка інша клавіша.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                using (StreamWriter f = new StreamWriter("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt"))
                    for (int i = 0; i < length ; i++)
                    {
                        if (i != number - 1)
                        {
                            f.WriteLine(str[i]);
                        }

                    }
                Console.WriteLine("Змiни збережено\n");
            }
            else{Console.WriteLine("\nЗмiни не збережено\n");}
        }

        public void Output()
        {
            MetaData output = new MetaData();
            int length = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt").Length;
            string[] str = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt");
            Console.WriteLine("{0,-12}{1,-16}{2,-8}{3,-8}{4,-3}", "Дата","Місто","Тиск","Темп.","Швидкість вітру");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(str[i]);
            }
        }

        public void Search()
        {
            MetaData search = new MetaData();
            int length = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt").Length;
            string[] str = File.ReadAllLines("C:\\Users\\s\\RiderProjects\\Lab43\\Lab43\\database.txt");
            Console.WriteLine("\nВведiть місто, яке хочете знайти у списку:");
            string cityname = Console.ReadLine();
            search.City = Checkcity(cityname);
            bool statement=false;
            int index = 0;
            for (int i = 0; i < length; i++)
            {
                string result = string.Concat(str[i].Substring(12, 15).Where(c => !char.IsWhiteSpace(c)));
                if (result == search.city)
                {
                    statement = true;
                    index = i;
                }
            }

            if (statement)
            {
                Console.WriteLine("Дані про місто, яке ви шукали:");
                Console.WriteLine("{0,-12}{1,-16}{2,-8}{3,-8}{4,-3}", "Дата","Місто","Тиск","Темп.","Швидкість вітру");
                Console.WriteLine(str[index]);
            }
            if (!statement)
            {
                Console.WriteLine("Місто не знайдено");
            }
        }
    }
   
    class Program
    {
        static void Main()
        {
            MetaData m = new MetaData();
            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\nВибір режиму роботи: ");
                Console.WriteLine("Додавання записiв - Enter");
                Console.WriteLine("Редагування записiв - E");
                Console.WriteLine("Знищення записiв - Delete");
                Console.WriteLine("Виведення iнформацiї з файла на екран - Tab");
                Console.WriteLine("Пошук потрiбної iнформацiї за конкретною ознакою - S");
                ConsoleKeyInfo choice;
                choice = Console.ReadKey(true);
                if (choice.Key == ConsoleKey.Enter)
                    m.Add();
                if (choice.Key == ConsoleKey.E)
                {
                    m.Edit();
                }

                if (choice.Key == ConsoleKey.Delete)
                {
                    m.Delete();
                }

                if (choice.Key == ConsoleKey.Tab)
                {
                    m.Output();
                }

                if (choice.Key == ConsoleKey.S)
                {
                    m.Search();
                }
                
            }
        }
    }
}