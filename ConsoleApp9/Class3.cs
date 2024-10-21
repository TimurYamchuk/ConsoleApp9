using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp9
{
    class Academy_Group
    {
        private List<Student> students;

        public Academy_Group()
        {
            students = new List<Student>();
        }

        // Метод добавляет студентов в группу 
        public void Add(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Студент {student.Name} {student.Surname} добавлен");
        }

        // Метод удаляет студентов из группы
        public void Remove(string studentSurname)
        {
            var student = students.Find(s => s.Surname.Equals(studentSurname, StringComparison.OrdinalIgnoreCase));
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Студент {studentSurname} удалён из группы");
            }
            else
            {
                Console.WriteLine($"Студент {studentSurname} не найден в группе.");
            }
        }

        // Метод позволяет редактировать студента
        public void Edit(string studentSurname, Student newStudent)
        {
            var index = students.FindIndex(s => s.Surname.Equals(studentSurname, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                students[index] = newStudent;
                Console.WriteLine($"Студент {studentSurname} редактирован на студента {newStudent.Surname}");
            }
        }

        // Выводим всю группу 
        public void Print()
        {
            foreach (var student in students)
            {
                student.Print();
            }
        }

        // Сохраняем группу в файл
        public void Save()
        {
            using (StreamWriter writeToFile = new StreamWriter("Group.txt", false))
            {
                foreach (var student in students)
                {
                    writeToFile.WriteLine($"Имя - {student.Name}\nФамилия - {student.Surname}\nТелефон - {student.Phone}\nВозраст - {student.Age}\nСредний балл - {student.Average}\nНомер группы - {student.NumberOfGroup}\n");
                }
            }
            Console.WriteLine("Данные о студентах сохранены в файл");
        }

        // Загружаем данные из файла
        public void Load()
        {
            students.Clear();
            using (StreamReader readFile = new StreamReader("Group.txt"))
            {
                string line;
                while ((line = readFile.ReadLine()) != null)
                {
                    string name = line.Split('-')[1].Trim();
                    string surname = readFile.ReadLine().Split('-')[1].Trim();
                    string phone = readFile.ReadLine().Split('-')[1].Trim();
                    int age = int.Parse(readFile.ReadLine().Split('-')[1].Trim());
                    double average = double.Parse(readFile.ReadLine().Split('-')[1].Trim());
                    int numberOfGroup = int.Parse(readFile.ReadLine().Split('-')[1].Trim());

                    students.Add(new Student(name, surname, age, phone, average, numberOfGroup));
                    readFile.ReadLine(); // Пропускаем пустую строку
                }
            }
            Console.WriteLine("Данные о студентах загружены из файла.");
        }

        // Метод для поиска студентов по заданному критерию
        public void Search(int criterionNumber)
        {
            Console.Write("Введите значение для поиска: ");
            string searchValue = Console.ReadLine();
            bool found = false;

            foreach (var student in students)
            {
                bool matches = criterionNumber switch
                {
                    1 => student.Name.Equals(searchValue, StringComparison.OrdinalIgnoreCase),
                    2 => student.Surname.Equals(searchValue, StringComparison.OrdinalIgnoreCase),
                    3 => student.Phone.Equals(searchValue, StringComparison.OrdinalIgnoreCase),
                    4 => student.Age.ToString() == searchValue,
                    5 => student.Average.ToString() == searchValue,
                    6 => student.NumberOfGroup.ToString() == searchValue,
                    _ => false
                };

                if (matches)
                {
                    Console.WriteLine("Такой студент есть:");
                    student.Print();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Такого студента нет.");
            }
        }
    }
}
