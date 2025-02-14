using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Интерфейс ветеринарной клиники – отвечает за проверку состояния здоровья животных.
    /// </summary>
    public interface IVeterinaryClinic
    {
        bool CheckAnimal(Animal animal);
    }
}
