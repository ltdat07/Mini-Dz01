using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Абстрактный базовый класс для всех животных. Реализует IAlive и IInventory.
    /// </summary>
    public abstract class Animal : IAlive, IInventory
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public int Number { get; set; }

        protected Animal(string name, int food, int number)
        {
            Name = name;
            Food = food;
            Number = number;
        }

        /// <summary>
        /// Метод для получения типа животного.
        /// </summary>
        public abstract string GetAnimalType();
    }
}
