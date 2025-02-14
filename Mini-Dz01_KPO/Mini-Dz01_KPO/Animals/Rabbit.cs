using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс кролик – типичный представитель травоядных.
    /// </summary>
    public class Rabbit : Herbivore
    {
        public Rabbit(string name, int food, int number, int kindness)
            : base(name, food, number, kindness)
        {
        }

        public override string GetAnimalType() => "Кролик (Rabbit)";
    }
}
