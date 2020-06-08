using System;

namespace Lab41
{
    public class Student
    {
        private string name;
        private string lastName;
        private string group;
        private int year;
        private string adress;
        private string passport;
        private int age;
        private string telephon;
        private int rating;
        public Student() {}
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Group
        {
            get {return group; }
            set { group = value; }
        }
        public int Year
        {
            get {return year; }
            set { year = value; }
        }
        public string Adress
        {
            get {return adress; }
            set { adress = value; }
        }
        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Telephon
        {
            get {return telephon; }
            set { telephon = value; }
        }
        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public string StudentRating(int rating)
        {
            string r = " ";
            if (rating >= 90)
            {
                r = "Вiтаємо вiдмiнника";
            }

            if (rating >= 75 & rating < 90)
            {
                r = "Mожна вчитися краще";
            }

            if (rating < 75)
            {
                r = "Варто більше уваги приділяти навчанню";
            }

            return r;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Student st = new Student() ;
            st.Name = "Остап";
            st.LastName = "Мельник";
            st.Group = "IТ-10";
            st.Year = 2022;
            st.Adress = "Müller-Breslau-Straße 14A, 10623 Berlin";
            st.Passport = "000000000";
            st.Age = 19;
            st.Telephon = "(000) 000 0000";
            st.Rating = 81;
            string r = st.StudentRating(st.Rating);
            
            Console.WriteLine("Iм'я: " + st.Name);
            Console.WriteLine("Прiзвище: " + st.LastName);
            Console.WriteLine("Група: " + st.Group);
            Console.WriteLine("Рiк вступу: " + st.Year);
            Console.WriteLine("Адреса: " + st.Adress);
            Console.WriteLine("Паспорт: " + st.Passport );
            Console.WriteLine("Вiк: " + st.Age);
            Console.WriteLine("Номер телефону: " + st.Telephon);
            Console.WriteLine("Rating: " + st.Rating);
            Console.WriteLine(r);
            Console.ReadKey();
        }
    }
}
