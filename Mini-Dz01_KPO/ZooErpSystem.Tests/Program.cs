/*
using Xunit;
using Moq;
using ZooErpSystem;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace ZooErpSystem.Tests
{
    public class ZooTests
    {
        [Fact]
        public void AddHealthyAnimal_ShouldBeAdded()
        {
            // Arrange
            var clinicMock = new Mock<VeterinaryClinic>();
            clinicMock.Setup(c => c.CheckHealth(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(clinicMock.Object);
            var rabbit = new Rabbit(1, 3, true, 8);

            // Act
            zoo.AddAnimal(rabbit);

            // Assert
            Assert.Contains(rabbit, zoo.GetAnimals());
        }

        [Fact]
        public void AddUnhealthyAnimal_ShouldNotBeAdded()
        {
            // Arrange
            var clinicMock = new Mock<VeterinaryClinic>();
            clinicMock.Setup(c => c.CheckHealth(It.IsAny<Animal>())).Returns(false);

            var zoo = new Zoo(clinicMock.Object);
            var tiger = new Tiger(2, 10, false);

            // Act
            zoo.AddAnimal(tiger);

            // Assert
            Assert.DoesNotContain(tiger, zoo.GetAnimals());
        }

        [Fact]
        public void CalculateTotalFood_ShouldReturnCorrectSum()
        {
            // Arrange
            var clinicMock = new Mock<VeterinaryClinic>();
            clinicMock.Setup(c => c.CheckHealth(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(clinicMock.Object);
            zoo.AddAnimal(new Rabbit(1, 3, true, 6));
            zoo.AddAnimal(new Tiger(2, 10, true));
            zoo.AddAnimal(new Wolf(3, 7, true));
            zoo.AddAnimal(new Monkey(4, 4, true, 5));

            // Act
            int totalFood = zoo.CalculateTotalFood();

            // Assert
            Assert.Equal(24, totalFood);
        }

        [Fact]
        public void AddThing_ShouldBeAddedToInventory()
        {
            // Arrange
            var clinicMock = new Mock<VeterinaryClinic>();
            var zoo = new Zoo(clinicMock.Object);
            var table = new Table(101);

            // Act
            zoo.AddThing(table);

            // Assert
            Assert.Contains(zoo.GetInventory(), item => item.Number == 101);
        }

        [Fact]
        public void ShowInventory_ShouldListAllItems()
        {
            // Arrange
            var clinicMock = new Mock<VeterinaryClinic>();
            clinicMock.Setup(c => c.CheckHealth(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(clinicMock.Object);
            var rabbit = new Rabbit(1, 3, true, 7);
            var table = new Table(101);
            var computer = new Computer(102);

            zoo.AddAnimal(rabbit);
            zoo.AddThing(table);
            zoo.AddThing(computer);

            // Act
            var inventory = zoo.GetInventory().ToList();

            // Assert
            Assert.Equal(3, inventory.Count);
            Assert.Contains(inventory, item => item.Number == 1);
            Assert.Contains(inventory, item => item.Number == 101);
            Assert.Contains(inventory, item => item.Number == 102);
        }
    }
}
*/