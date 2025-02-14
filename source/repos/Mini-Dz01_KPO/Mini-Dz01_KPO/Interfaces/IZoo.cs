using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Интерфейс для зоопарка – отвечает за хранение и выдачу информации о животных и вещах.
    /// </summary>
    public interface IZoo
    {
        void AddAnimal(Animal animal);
        IEnumerable<Animal> GetAnimals();
        void AddThing(Thing thing);
        IEnumerable<Thing> GetThings();
        int GetTotalFoodConsumption();
        IEnumerable<Herbivore> GetContactableAnimals();

        /// <summary>
        /// Получение всех инвентаризационных объектов – как животных, так и вещей.
        /// </summary>
        IEnumerable<IInventory> GetInventoryItems();
    }
}
