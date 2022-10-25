using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Teachers = new List<Teacher>()
            {
                new Teacher() {FirstName="Александр", LastName="Вдовин", BirthDay=DateTime.Parse("10.01.1987"), Displinas=new List<string>(){ "ОБЖ", "Труд"}, G=5, Room="2-204K" },
                new Teacher() {FirstName="Игорь", LastName="Крутой", BirthDay=DateTime.Parse("15.11.1964"), Displinas=new List<string>(){ "Музыка", "ИЗО"}, G=3, Room="4-404С" },
                new Teacher() {FirstName="Илон", LastName="Маск", BirthDay=DateTime.Parse("02.04.1989"), Displinas=new List<string>(){ "Физика", "Информатика"}, G=8, Room="1-104Б" }
            };

            var Students = new List<Student>()
            {
                new Student() {FirstName="Богдан", LastName="Тратам", BirthDay=DateTime.Parse("10.01.1999"), Course=2, FormaObuch="Очная", Number=123654 },
                new Student() {FirstName="Дмитрий", LastName="Кочегар", BirthDay=DateTime.Parse("10.02.2000"), Course=3, FormaObuch="Заочная", Number=36542 },
                new Student() {FirstName="Александр", LastName="Масляков", BirthDay=DateTime.Parse("11.01.2001"), Course=2, FormaObuch="Очная", Number=12542 },
            };

            var Securities = new List<Security>()
            {
                new Security() {FirstName="Герасим", LastName="Авдодтьев", BirthDay=DateTime.Parse("10.01.1846"), How_long_to_work=10, Category=1},
                new Security() {FirstName="Трандуил", LastName="Защитник", BirthDay=DateTime.Parse("13.05.1236"), How_long_to_work=100, Category=1},
                new Security() {FirstName="Колос", LastName="Тротос", BirthDay=DateTime.Parse("14.05.1420"), How_long_to_work=104, Category=3},
            };

            var Cleansiers = new List<Cleanser>()
            {
                new Cleanser() {FirstName="Валентина", LastName="Чертановка", BirthDay=DateTime.Parse("10.01.1826"), Build=2},
                new Cleanser() {FirstName="Марина", LastName="Зынына", BirthDay=DateTime.Parse("12.01.1842"), Build=1},
                new Cleanser() {FirstName="Людмила", LastName="Гурченко", BirthDay=DateTime.Parse("10.02.1846"), Build=1},
            };

            var exit = false;

            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("Выберите какой список вывести: \n 1. Преподаватели \n 2. Студенты \n 3. Охрана \n 4. Уборщики \n 0. Выход");

                var input = Console.ReadKey();

                if (char.IsDigit(input.KeyChar))
                {
                    var select = int.Parse(input.KeyChar.ToString());
                    if (select == 0)
                    {
                        exit = true;
                        continue;
                    }
                    int selectedNumber;
                    switch (select)
                    {
                        case 1:
                            {
                                PrintList<Teacher>(Teachers, out selectedNumber);
                                Console.Clear();

                                Console.WriteLine($"{Teachers[selectedNumber].ToString()}");


                                Console.WriteLine("Для возврата к списку нажмите любую клавишу");

                                Console.ReadKey();

                                break;
                            }
                        case 2:
                            {
                                PrintList<Student>(Students, out selectedNumber);

                                Console.Clear();

                                Console.WriteLine($"{Students[selectedNumber].ToString()}");


                                Console.WriteLine("Для возврата к списку нажмите любую клавишу");

                                Console.ReadKey();

                                break;
                            }
                        case 3:
                            {
                                PrintList<Security>(Securities, out selectedNumber);
                                Console.Clear();

                                Console.WriteLine($"{Securities[selectedNumber].ToString()}");

                                Console.WriteLine("Для возврата к списку нажмите любую клавишу");

                                Console.ReadKey();

                                break;
                            }
                        case 4:
                            {
                                PrintList<Cleanser>(Cleansiers, out selectedNumber);
                                Console.Clear();

                                Console.WriteLine($"{Cleansiers[selectedNumber].ToString()}");

                                Console.WriteLine("Для возврата к списку нажмите любую клавишу");

                                Console.ReadKey();

                                break;
                            }
                    }
                }


            }

        }
        private static void PrintList<T>(List<T> values, out int selectedNumber) where T : Human
        {
            Console.Clear();
            var validInput = false;

            selectedNumber = 0;

            while (!validInput)
            {
                 Console.Clear();
                foreach (var item in values)
                {
                    Console.WriteLine($"{values.IndexOf(item)+1}. {item.FirstName} {item.LastName}");
                }

                var input = Console.ReadKey();
                try
                {
                    var selected = int.Parse(input.KeyChar.ToString());

                    if ((selected >= 1 && selected <= values.Count()) || selected == 0)
                    {
                        selectedNumber = selected-1;
                        validInput = true;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }

    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }

    public class Teacher : Human
    {
        public List<string> Displinas { get; set; }
        public int G { get; set; }
        public string Room {get;set;}

        public override string ToString()
        {
            return $"Я {this.FirstName} {this.LastName}. Преподаю {string.Join(" ", Displinas)}. В кабинете {Room}"; 
        }
    }

    public class Student : Human
    {
        public int Course { get; set; }
        public string FormaObuch { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"Я {this.FirstName} {this.LastName}. Учусь на {Number} курсе. Форма обучения: {FormaObuch}";
        }
    }
    public class Security : Human
    {
        public int How_long_to_work { get; set; }
        [Range(1,3)]
        public int Category { get; set; }
        public override string ToString()
        {
            return $"Я {this.FirstName} {this.LastName}. Охранник {Category} категории со стажем работы {How_long_to_work}";
        }
    }
    public class Cleanser : Human
    {
        [Range(1, 3)]
        public int Build { get; set; }

        public override string ToString()
        {
            return $"Я {this.FirstName} {this.LastName}. Провожу клининг в {Build} корпусе";
        }
    }
}
