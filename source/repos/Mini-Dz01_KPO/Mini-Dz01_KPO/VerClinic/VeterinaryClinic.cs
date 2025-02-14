using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс Ветеринарная клиника – реализует метод проверки здоровья животного.
    /// </summary>
    public class VeterinaryClinic : IVeterinaryClinic
    {
        public bool CheckAnimal(Animal animal)
        {
            Console.WriteLine($"Проводится осмотр животного: {animal.Name} ({animal.GetAnimalType()}).");
            Console.Write("Введите состояние здоровья животного (здоров/не здоров): ");
            string input = Console.ReadLine();
            bool isHealthy = input.Trim().ToLower() == "здоров" || input.Trim().ToLower() == "healthy";
            if (isHealthy)
            {
                Console.WriteLine("Животное признано здоровым.");
            }
            else
            {
                Console.WriteLine("Животное не прошло медосмотр. Прием отклонен.");
            }
            return isHealthy;
        }
    }
}
