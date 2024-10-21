using System;

namespace ConsoleApp9
{
    class Person
    {
        protected string name;
        protected string surname;
        protected string phone;
        protected int age;

        public Person()
        {
            name = string.Empty;
            surname = string.Empty;
            phone = string.Empty;
            age = 0;
        }

        public Person(string n, string s, string p, int a)
        {
            name = n;
            surname = s;
            phone = p;
            age = a;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public void Print()
        {
            Console.WriteLine($"Имя - {name}\nФамилия - {surname}\nТелефон - {phone}\nВозраст - {age}");
        }
    }
}
