using System;
using System.IO;
using System.Linq;
using Xunit;               // xUnit
using ZooERP;             // Пространство имён вашего основного кода
using Moq;                // Для примера моков (при необходимости)

namespace ZooERP.Tests
{
    public class ZooTests
    {
        [Fact]
        public void AddAnimal_IncreasesAnimalCount()
        {
            // Arrange
            var zoo = new Zoo();
            var monkey = new Monkey("Abu", 2, 101, 7);

            // Act
            zoo.AddAnimal(monkey);

            // Assert
            Assert.Single(zoo.GetAnimals());
            Assert.Equal("Abu", zoo.GetAnimals().First().Name);
        }

        [Fact]
        public void GetTotalFoodConsumption_ReturnsCorrectSum()
        {
            // Arrange
            var zoo = new Zoo();
            zoo.AddAnimal(new Monkey("Abu", 2, 101, 7));
            zoo.AddAnimal(new Rabbit("Bugs", 3, 102, 4));

            // Act
            int totalFood = zoo.GetTotalFoodConsumption();

            // Assert
            Assert.Equal(5, totalFood);
        }

        [Fact]
        public void GetContactableAnimals_ReturnsOnlyKindnessAbove5()
        {
            // Arrange
            var zoo = new Zoo();
            var monkey1 = new Monkey("Abu", 2, 101, 7);  // Kindness=7
            var monkey2 = new Monkey("Chico", 2, 102, 5); // Kindness=5
            var rabbit = new Rabbit("Roger", 3, 103, 9);  // Kindness=9

            zoo.AddAnimal(monkey1);
            zoo.AddAnimal(monkey2);
            zoo.AddAnimal(rabbit);

            // Act
            var contactable = zoo.GetContactableAnimals().ToList();

            // Assert
            // Должно вернуться 2 животных (Abu, Roger)
            Assert.Equal(2, contactable.Count);
            Assert.Contains(contactable, a => a.Name == "Abu");
            Assert.Contains(contactable, a => a.Name == "Roger");
            Assert.DoesNotContain(contactable, a => a.Name == "Chico");
        }

        [Fact]
        public void GetInventoryItems_IncludesAnimalsAndThings()
        {
            // Arrange
            var zoo = new Zoo();
            var monkey = new Monkey("Abu", 2, 101, 7);
            var table = new Table("Feeding Table", 201);

            zoo.AddAnimal(monkey);
            zoo.AddThing(table);

            // Act
            var inventory = zoo.GetInventoryItems().ToList();

            // Assert
            // Ожидаем 2 объекта в общей инвентаризации
            Assert.Equal(2, inventory.Count);
            Assert.Contains(inventory, i => i is Animal);
            Assert.Contains(inventory, i => i is Thing);
        }
    }

    public class VeterinaryClinicTests
    {
        [Fact]
        public void CheckAnimal_WhenInputHealthy_ReturnsTrue()
        {
            // Arrange
            var vet = new VeterinaryClinic();
            var monkey = new Monkey("Abu", 2, 101, 7);

            // Подменяем Console.In/Out, чтобы имитировать ввод "здоров"
            using var sw = new StringWriter();
            using var sr = new StringReader("здоров\n");
            Console.SetOut(sw);
            Console.SetIn(sr);

            // Act
            bool result = vet.CheckAnimal(monkey);

            // Assert
            Assert.True(result);
            string output = sw.ToString();
            Assert.Contains("Проводится осмотр животного: Abu", output);
            Assert.Contains("Животное признано здоровым.", output);
        }

        [Fact]
        public void CheckAnimal_WhenInputUnhealthy_ReturnsFalse()
        {
            // Arrange
            var vet = new VeterinaryClinic();
            var wolf = new Wolf("Gray", 5, 200);

            using var sw = new StringWriter();
            using var sr = new StringReader("не здоров\n");
            Console.SetOut(sw);
            Console.SetIn(sr);

            // Act
            bool result = vet.CheckAnimal(wolf);

            // Assert
            Assert.False(result);
            string output = sw.ToString();
            Assert.Contains("Проводится осмотр животного: Gray", output);
            Assert.Contains("Животное не прошло медосмотр. Прием отклонен.", output);
        }
    }
}
