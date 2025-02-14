using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс обезьяна. Рассматривается как травоядное для возможности контактного зоопарка.
    /// </summary>
    public class Monkey : Herbivore
    {
        public Monkey(string name, int food, int number, int kindness)
            : base(name, food, number, kindness)
        {
        }

        public override string GetAnimalType() => "Обезьяна (Monkey)";
    }
}
