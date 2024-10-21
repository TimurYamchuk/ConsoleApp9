using System;

namespace ConsoleApp9
{
    class Student : Person
    {
        private double average;
        private int numberOfGroup;

        public double Average
        {
            get => average;
            set => average = value;
        }

        public int NumberOfGroup
        {
            get => numberOfGroup;
            set => numberOfGroup = value;
        }

        public Student() : base()
        {
            average = 0.0;
            numberOfGroup = 0;
        }

        public Student(string value_name, string value_surname, int value_age, string value_phone, double value_average, int value_number_of_group)
            : base(value_name, value_surname, value_phone, value_age)
        {
            average = value_average;
            numberOfGroup = value_number_of_group;
        }

        public new void Print()
        {
            base.Print();
            Console.WriteLine($"Average - {average}\nNumber of group - {numberOfGroup}");
        }
    }
}
