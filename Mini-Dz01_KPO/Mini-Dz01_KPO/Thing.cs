using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Базовый класс для вещей зоопарка.
    /// </summary>
    public class Thing : IInventory
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Thing(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
