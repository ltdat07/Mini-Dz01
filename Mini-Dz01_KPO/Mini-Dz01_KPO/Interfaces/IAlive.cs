using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Интерфейс для живых существ – определяет свойство потребления еды.
    /// </summary>
    public interface IAlive
    {
        int Food { get; }
    }
}