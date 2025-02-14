using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс стол – наследник Thing.
    /// </summary>
    public class Table : Thing
    {
        public Table(string name, int number) : base(name, number) { }
    }
}
