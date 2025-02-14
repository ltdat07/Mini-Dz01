using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Интерфейс сервиса зоопарка – инкапсулирует бизнес-логику работы с животными и вещами.
    /// </summary>
    public interface IZooService
    {
        void AddAnimal();
        void ShowFoodReport();
        void ShowContactableAnimals();
        void ShowInventoryItems();
    }
}
