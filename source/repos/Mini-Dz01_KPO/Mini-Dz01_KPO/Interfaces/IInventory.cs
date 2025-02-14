using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Интерфейс для объектов, подлежащих инвентаризации – содержит инвентаризационный номер.
    /// </summary>
    public interface IInventory
    {
        int Number { get; }
    }
}
