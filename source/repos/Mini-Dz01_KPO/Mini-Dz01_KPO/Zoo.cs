using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Dz01_KPO
{
    /// <summary>
    /// Класс Зоопарк – содержит коллекции животных и вещей.
    /// </summary>
    public class Zoo : IZoo
    {
        private readonly List<Animal> _animals = new List<Animal>();
        private readonly List<Thing> _things = new List<Thing>();

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public IEnumerable<Animal> GetAnimals() => _animals;

        public void AddThing(Thing thing)
        {
            _things.Add(thing);
        }

        public IEnumerable<Thing> GetThings() => _things;

        /// <summary>
        /// Суммирует количество еды, потребляемой всеми животными.
        /// </summary>
        public int GetTotalFoodConsumption()
        {
            return _animals.Sum(a => a.Food);
        }

        /// <summary>
        /// Выбирает из списка животных травоядных с уровнем доброты выше 5 для контактного зоопарка.
        /// </summary>
        public IEnumerable<Herbivore> GetContactableAnimals()
        {
            return _animals
                .OfType<Herbivore>()
                .Where(h => h.Kindness > 5);
        }

        /// <summary>
        /// Возвращает объединённый список всех инвентаризационных объектов (животные и вещи).
        /// </summary>
        public IEnumerable<IInventory> GetInventoryItems()
        {
            // Приводим список животных к типу IInventory и объединяем с вещами.
            return _animals.Cast<IInventory>().Concat(_things);
        }
    }
}
