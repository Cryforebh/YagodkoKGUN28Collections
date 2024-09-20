using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class TaskOne
    {
        readonly List<string> _list = new List<string>();
        private string _rep;

        public void AddStandartTask()
        {
            if (_list.Count == 0)
            {
                _list.Add("Отрезать копыто");
                _list.Add("Отрезать голову");
                _list.Add("Отрезать шкуру");
            }
        }

        public void TaskLoop()
        {
            do
            {
                int numberElement = 0;

                AllList();

                do
                {
                    Console.Write($"\nВведите название нового действия (что хотите отрезать у мертвой туши животного?)\nПример - {_list[0]}: ");
                    _list.Add(Console.ReadLine());

                    Console.Write("\nДействие добавленно в конец списка. Если хотите добавить еще, введите да/yes: ");
                    _rep = Console.ReadLine();

                } while (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы");

                //..........................................................................

                AllList();

                Console.Write("\nЕсли желаете изменить конкретное действие, введите yes/да: ");
                _rep = Console.ReadLine();

                while (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы") ;
                {
                    Console.WriteLine("Номер какого действия желаете изменить?"); numberElement = ReadNumber();
                    Console.Write($"\nВведите название нового действия для замены старого ({_list[numberElement]}): ");
                    _list[numberElement] = Console.ReadLine();

                    Console.Write("\nЕсли желаете изменить еще какое-то действие, введите yes/да: ");
                    _rep = Console.ReadLine();
                }

                Console.Write("\nЕсли желаете повторить задачу введите да/yes: ");
                _rep = Console.ReadLine();

            } while (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы");

        }

        public int ReadNumber()
        {
            int readNumber;
            do
            {
                Console.Write("№: ");
                if (!int.TryParse(Console.ReadLine(), out readNumber) || readNumber > 1 + _list.Count || readNumber < 0)
                {
                    Console.Write("Не коректно заданное число! Введите номер действия указанного выше: ");
                    readNumber = -1;
                }
                readNumber--;
                
            } while (readNumber > 1 + _list.Count || readNumber < 0);

            return readNumber;
        }
        
        public void AllList()
        {
            int numberElement = 0;

            Console.WriteLine("\nСписок доступных действий:");
            foreach (string item in _list)
            {
                numberElement++;
                Console.WriteLine($"№{numberElement} - {item}");
            }
        }
    }

    public class TaskTwo
    {
        readonly Dictionary<string, int> _dictionary = new Dictionary<string, int>();

        private string _name;
        private int _value;
        private string _rep;

        public void TaskLoop()
        {
            do
            {
                Console.WriteLine($"\nВведите имя студента, и его среднюю Оценку (от 2 до 5). ");

                do
                {
                    Console.Write("\nИмя студента: "); _name = ReadName();
                    Console.Write("Оценка студента: "); _value = ReadValue();
                    _dictionary.Add(_name, _value);

                    Console.Write("\nИнформация о студенте добавлена. Если хотите добавить еще студента введите да/yes: ");
                    _rep = Console.ReadLine();

                } while (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы");

                //..........................................................................

                Console.Write("\nЕсли вы ходите узнать оценку конкретного студента, введите да/yes: ");
                _rep = Console.ReadLine();

                while (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы") ;
                {
                    Console.Write("Укажите имя студента, чтобы узнать его среднюю оценку: ");

                    _name = Console.ReadLine();
                    Console.Write("\n");

                    while (!_dictionary.ContainsKey(_name))
                    {
                        Console.Write("\nТакого имени нет в списке студентов! Попробуйте ввести заново: ");
                        _name = Console.ReadLine();
                    }

                    Console.WriteLine($"{_name} имеет среднюю оценку - {_dictionary[_name]}.");

                    Console.Write("\nЕсли вы ходите узнать оценку другого студента, введите да/yes: ");
                    _rep = Console.ReadLine();
                }

                Console.Write("\nЕсли желаете вывести список всех студентов, введите да/yes: ");
                _rep = Console.ReadLine();
                if (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы") ;
                {
                    foreach (var item in _dictionary)
                    {
                        Console.WriteLine($"{item}");
                    }
                }

                Console.Write("\nЕсли желаете повторить задачу введите да/yes: ");
                _rep = Console.ReadLine();

            } while (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы");
        }

        public int ReadValue()
        {
            int readValue;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out readValue) || readValue > 5 || readValue < 2)
                {
                    Console.Write("Не коректно заданное число! Введите оценку от 2 до 5: ");
                    readValue = 0;
                }

            } while (readValue > 5 || readValue < 2);

            return readValue;
        }

        public string ReadName()
        {
            string readName = Console.ReadLine();

            while (_dictionary.ContainsKey(readName))
            {
                Console.Write("Студент с таким именем уже есть в списке! Попробуйте снова: ");
                readName = Console.ReadLine();
            }

            return readName;
        }
    }

    public class TaskThreeLinkedList
    {
        public void TaskLoop()
        {
            Console.WriteLine("\nСоздайте список. ");

            Console.Write("\nУкажите сколько элементов будет добавленно в список от 3 до 10: ");
            int countArray = ReadValue();

            LinkedList<string> linkedList = new LinkedList<string>();

            for (int i = 1; i <= countArray; i++)
            {
                Console.Write($"Укажите содержимое {i} элемента: ");
                linkedList.AddLast(Console.ReadLine());
            }

            Console.WriteLine("\nСодержимое созданого списка:");
            foreach (var item in linkedList)
            {
                Console.Write($"- {item}\n");
            }

            Console.WriteLine("\nСодержимое созданого списка в обратном порядке:");
            
            foreach (var item in linkedList.Reverse())
            {
                Console.Write($"- {item}\n");
            }
        }

        public int ReadValue()
        {
            int readValue;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out readValue) || readValue > 10 || readValue < 3)
                {
                    Console.Write("Не коректно заданное число! Введите размер списка от 3 до 10: ");
                    readValue = -1;
                }

            } while (readValue > 10 || readValue < 3);

            return readValue;
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            string _rep;
            int task;

            do
            {
                Console.Write($"Выберите задачу от (1 - 3): ");

                do
                {
                    if (!int.TryParse(Console.ReadLine(), out task))
                    {
                        Console.Write("Некоректный ввод! Выберите задачу (1 - 3): ");
                        task = -1;
                    }
                } while (task < 0);

                switch (task)
                {
                    case 1:
                        CheckTaskOneFirst();
                        break;
                    case 2:
                        CheckTaskTwoFirst();
                        break;
                    case 3:
                        CheckTaskThreeFirst();
                        break;
                    default:
                        Console.WriteLine("Введен не существующий номер задания!");
                        break;
                }
                
                Console.Write("\nЕсли желаете повторно выбрать задачу введите да/yes: ");
                _rep = Console.ReadLine();

            } while (_rep == "yes" || _rep == "да" || _rep == "lf" || _rep == "нуы");

        }

        private static void CheckTaskOneFirst()
        {
            TaskOne taskOne = new TaskOne();
            taskOne.AddStandartTask();
            taskOne.TaskLoop();
        }

        private static void CheckTaskTwoFirst()
        {
            TaskTwo taskTwo = new TaskTwo();
            taskTwo.TaskLoop();
        }

        private static void CheckTaskThreeFirst()
        {
            TaskThreeLinkedList taskThree = new TaskThreeLinkedList();
            taskThree.TaskLoop();
        }
    }
}
