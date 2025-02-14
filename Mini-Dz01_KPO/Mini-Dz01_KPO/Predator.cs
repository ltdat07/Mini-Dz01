using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Абстрактный класс для хищных животных.
    /// </summary>
    public abstract class Predator : Animal
    {
        protected Predator(string name, int food, int number)
            : base(name, food, number)
        {
        }
    }
}
