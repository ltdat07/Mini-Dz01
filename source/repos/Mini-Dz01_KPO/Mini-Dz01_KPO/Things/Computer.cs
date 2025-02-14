using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс компьютер – наследник Thing.
    /// </summary>
    public class Computer : Thing
    {
        public Computer(string name, int number) : base(name, number) { }
    }
}
