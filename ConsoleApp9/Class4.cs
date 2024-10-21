using System;

namespace ConsoleApp9
{
    class ClassMenu
    {
        private readonly Academy_Group academyGroup = new Academy_Group();
        private bool running = true;

        public void Menu()
        {
            while (running)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Редактировать студента");
                Console.WriteLine("4. Показать группу");
                Console.WriteLine("5. Сохранить данные");
                Console.WriteLine("6. Загрузить данные");
                Console.WriteLine("7. Поиск студента");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                ExecuteChoice(choice);
            }
        }

        private void ExecuteChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    RemoveStudent();
                    break;
                case "3":
                    EditStudent();
                    break;
                case "4":
                    academyGroup.Print();
                    break;
                case "5":
                    academyGroup.Save();
                    break;
                case "6":
                    academyGroup.Load();
                    break;
                case "7":
                    SearchStudent();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }
        }

        private void AddStudent()
        {
            Student student = GetStudentData();
            academyGroup.Add(student);
        }

        private void RemoveStudent()
        {
            Console.Write("Введите фамилию студента для удаления: ");
            string removeSurname = Console.ReadLine();
            academyGroup.Remove(removeSurname);
        }

        private void EditStudent()
        {
            Console.Write("Введите фамилию студента для редактирования: ");
            string editSurname = Console.ReadLine();
            Student newStudent = GetStudentData();
            academyGroup.Edit(editSurname, newStudent);
        }

        private Student GetStudentData()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.Write("Введите телефон: ");
            string phone = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Введите средний балл: ");
            double average = double.Parse(Console.ReadLine());
            Console.Write("Введите номер группы: ");
            int numberOfGroup = int.Parse(Console.ReadLine());

            return new Student(name, surname, age, phone, average, numberOfGroup);
        }

        private void SearchStudent()
        {
            Console.WriteLine("Выберите критерий для поиска:");
            Console.WriteLine("1. Имя");
            Console.WriteLine("2. Фамилия");
            Console.WriteLine("3. Телефон");
            Console.WriteLine("4. Возраст");
            Console.WriteLine("5. Средний балл");
            Console.WriteLine("6. Номер группы");
            Console.Write("Ваш выбор: ");
            int searchCriterion = int.Parse(Console.ReadLine());
            academyGroup.Search(searchCriterion);
        }
    }
}
