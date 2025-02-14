using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Абстрактный класс для травоядных животных, добавляет характеристику "добротность".
    /// </summary>
    public abstract class Herbivore : Animal
    {
        /// <summary>
        /// Уровень доброты (0-10). Если выше 5 – животное можно использовать в контактном зоопарке.
        /// </summary>
        public int Kindness { get; set; }

        protected Herbivore(string name, int food, int number, int kindness)
            : base(name, food, number)
        {
            Kindness = kindness;
        }
    }
}
