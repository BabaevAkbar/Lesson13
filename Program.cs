using System;
using Exceptions;

namespace Lesson13
{
    class UserProcessing
    {
        private string? Name{ get; set; }
        private int Age{ get; set; }
        private double Salary{ get; set; }

        public UserProcessing(string name, int age, double salary)
        {
            try
            {
                if(name.Length != 0)
                {
                    Name = name;
                    if(age > 18 && 65 > age)
                    {
                        Age = age;
                        if(salary > 0)
                        {
                            Salary = salary;
                            Console.WriteLine("Пользователь успешно добавлен в список.");
                        }
                        else
                        {
                            throw new InvalidSalaryException("Зарплата должна быть больше 0!");
                        }
                    }
                    else
                    {
                        throw new InvalidAgeException("Возраст должен быть в пределах от 18 до 65 лет!");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Введите Имя!");
                }
                
                
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка формата: {ex.Message}");
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Зарплата: {Salary}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<UserProcessing> Users = new List<UserProcessing>();
            while(true)
            {
                Console.WriteLine("Выберите действие:\n*Добавить пользователя(1).\n*Список пользователей(2).");
                int action = int.Parse(Console.ReadLine());
                if(action == 1)
                {
                    Console.WriteLine("Введите имя:");
                    string? name = Console.ReadLine();
                    Console.WriteLine("Введите возраст:");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите зарплату:");
                    double salary = double.Parse(Console.ReadLine());
                    UserProcessing user = new UserProcessing(name, age, salary);
                    Users.Add(user);
                }
                else if(action == 2)
                {
                    foreach (var item in Users)
                    {
                        item.PrintInfo();
                    }
                }
                else
                {
                    Console.WriteLine("Некорректные данные!");
                }
            }
        }
    }
}