using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс волк – представитель хищников.
    /// </summary>
    public class Wolf : Predator
    {
        public Wolf(string name, int food, int number)
            : base(name, food, number)
        {
        }

        public override string GetAnimalType() => "Волк (Wolf)";
    }
}
