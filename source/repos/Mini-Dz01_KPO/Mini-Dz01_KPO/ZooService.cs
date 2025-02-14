using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс ZooService – использует зависимости (IZoo и IVeterinaryClinic) через конструктор.
    /// </summary>
    public class ZooService : IZooService
    {
        private readonly IZoo _zoo;
        private readonly IVeterinaryClinic _vet;

        public ZooService(IZoo zoo, IVeterinaryClinic vet)
        {
            _zoo = zoo;
            _vet = vet;
        }

        /// <summary>
        /// Добавление нового животного с предварительной проверкой здоровья.
        /// </summary>
        public void AddAnimal()
        {
            Console.WriteLine("Выберите тип животного для добавления:");
            Console.WriteLine("1. Обезьяна (Monkey)");
            Console.WriteLine("2. Кролик (Rabbit)");
            Console.WriteLine("3. Тигр (Tiger)");
            Console.WriteLine("4. Волк (Wolf)");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();
            Animal animal = null;

            switch (choice)
            {
                case "1":
                    animal = CreateHerbivoreAnimal("Monkey");
                    break;
                case "2":
                    animal = CreateHerbivoreAnimal("Rabbit");
                    break;
                case "3":
                    animal = CreatePredatorAnimal("Tiger");
                    break;
                case "4":
                    animal = CreatePredatorAnimal("Wolf");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            // Проверка состояния здоровья животного
            if (_vet.CheckAnimal(animal))
            {
                _zoo.AddAnimal(animal);
                Console.WriteLine("Животное успешно добавлено в зоопарк.");
            }
            else
            {
                Console.WriteLine("Животное не было добавлено в зоопарк.");
            }
        }

        /// <summary>
        /// Создание травоядного животного (обезьяна или кролик).
        /// </summary>
        private Animal CreateHerbivoreAnimal(string type)
        {
            Console.Write("Введите имя животного: ");
            string name = Console.ReadLine();
            int food = ReadInt("Введите количество килограммов еды в сутки: ");
            int number = ReadInt("Введите инвентаризационный номер: ");
            int kindness = ReadInt("Введите уровень доброты (0-10): ");

            return type switch
            {
                "Monkey" => new Monkey(name, food, number, kindness),
                "Rabbit" => new Rabbit(name, food, number, kindness),
                _ => throw new ArgumentException("Неизвестный тип травоядного животного."),
            };
        }

        /// <summary>
        /// Создание хищного животного (тигр или волк).
        /// </summary>
        private Animal CreatePredatorAnimal(string type)
        {
            Console.Write("Введите имя животного: ");
            string name = Console.ReadLine();
            int food = ReadInt("Введите количество килограммов еды в сутки: ");
            int number = ReadInt("Введите инвентаризационный номер: ");

            return type switch
            {
                "Tiger" => new Tiger(name, food, number),
                "Wolf" => new Wolf(name, food, number),
                _ => throw new ArgumentException("Неизвестный тип хищного животного."),
            };
        }

        /// <summary>
        /// Удобный метод для чтения целочисленного значения с консоли.
        /// </summary>
        private int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    break;
                }
                Console.WriteLine("Неверный ввод. Пожалуйста, введите целое число.");
            }
            return result;
        }

        /// <summary>
        /// Вывод отчета: общее число животных и суммарное потребление еды.
        /// </summary>
        public void ShowFoodReport()
        {
            var animals = _zoo.GetAnimals();
            Console.WriteLine($"Общее количество животных в зоопарке: {animals.Count()}");
            Console.WriteLine($"Общее количество еды, необходимое для животных в день: {_zoo.GetTotalFoodConsumption()} кг");
        }

        /// <summary>
        /// Вывод списка животных, пригодных для контактного зоопарка (травоядных с добротой > 5).
        /// </summary>
        public void ShowContactableAnimals()
        {
            var contactAnimals = _zoo.GetContactableAnimals();
            if (!contactAnimals.Any())
            {
                Console.WriteLine("Нет животных, подходящих для контактного зоопарка.");
                return;
            }

            Console.WriteLine("Животные, подходящие для контактного зоопарка:");
            foreach (var animal in contactAnimals)
            {
                Console.WriteLine($"Тип: {animal.GetAnimalType()}, Имя: {animal.Name}, Инвентаризационный номер: {animal.Number}");
            }
        }

        /// <summary>
        /// Вывод объединенного списка всех инвентаризационных объектов (животные и вещи).
        /// </summary>
        public void ShowInventoryItems()
        {
            var items = _zoo.GetInventoryItems();
            if (!items.Any())
            {
                Console.WriteLine("На балансе зоопарка пока нет инвентаризационных объектов.");
                return;
            }

            Console.WriteLine("Инвентаризационные объекты зоопарка (животные и вещи):");
            foreach (var item in items)
            {
                // Определяем тип объекта для более информативного вывода
                string objectType = item is Animal ? "Животное" : item is Thing ? "Вещь" : "Объект";
                string name = item is Animal animal ? animal.Name : item is Thing thing ? thing.Name : "Неизвестно";
                Console.WriteLine($"Тип: {objectType}, Наименование: {name}, Инвентаризационный номер: {item.Number}");
            }
        }
    }
}
