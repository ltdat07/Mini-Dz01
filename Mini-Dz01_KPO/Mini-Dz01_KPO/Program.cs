using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Mini_Dz01_KPO;

namespace ZooERP
{
    /// <summary>
    /// Точка входа в приложение. Настраивает DI-контейнер и запускает главный цикл работы консоли.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка DI-контейнера с использованием Microsoft.Extensions.DependencyInjection.
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IZoo, Zoo>()
                .AddSingleton<IVeterinaryClinic, VeterinaryClinic>()
                .AddSingleton<IZooService, ZooService>()
                .BuildServiceProvider();

            // Добавление предварительных инвентаризационных вещей (для апробации модели).
            var zoo = serviceProvider.GetService<IZoo>();
            zoo.AddThing(new Thing("Основной инвентарь", 100));
            zoo.AddThing(new Table("Кормушка (Стол)", 101));
            zoo.AddThing(new Computer("Сервер учета", 102));

            var zooService = serviceProvider.GetService<IZooService>();

            // Главный цикл консольного приложения с понятным меню.
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Меню Зоопарка ===");
                Console.WriteLine("1. Добавить новое животное");
                Console.WriteLine("2. Показать отчет по животным и потребляемой еде");
                Console.WriteLine("3. Показать животных для контактного зоопарка");
                Console.WriteLine("4. Показать инвентаризационные объекты (животные и вещи)");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        zooService.AddAnimal();
                        break;
                    case "2":
                        zooService.ShowFoodReport();
                        break;
                    case "3":
                        zooService.ShowContactableAnimals();
                        break;
                    case "4":
                        zooService.ShowInventoryItems();
                        break;
                    case "0":
                        Console.WriteLine("Выход из приложения.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
