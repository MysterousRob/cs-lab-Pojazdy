using ClassLibrary1.Interfaces;  // For IPojazdWodny, etc.
using ClassLibrary1.Models;      // For Pojazd, Silnik
using ClassLibrary1.Vehicles;    // For Samolot, Rower, Amfibia
using LaboratoriumPojazdy.Enums; // For Srodowisko, TypPaliwa
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace TestProject1
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void Samolot_ShouldTransitionToAir_WhenSpeedExceedsLimit()
        {
            // Arrange
            var plane = new Samolot("Boeing 737", 3, 20000, TypPaliwa.Benzyna);

            // Act
            plane.Przyspiesz(150); 

            // Assert
            Assert.AreEqual(Srodowisko.Powietrzne, plane.AktualneSrodowisko, "Plane should be in the air at 150 km/h.");
        }

        [TestMethod]
        public void Samolot_CannotStopInAir()
        {
            // Arrange
            var plane = new Samolot("Boeing 737", 3, 20000, TypPaliwa.Benzyna);
            plane.Przyspiesz(150); // Take off

            // Act
            plane.Zatrzymaj();

            // Assert
            Assert.IsTrue(plane.CzySiePorusza, "Plane should not stop while in the air environment!");
        }

        [TestMethod]
        public void Amfibia_RespectsWaterSpeedLimit()
        {
            // Arrange
            var amfibia = new Amfibia("Amphibian", 4, 2.5, 150);
            amfibia.PrzelaczSrodowisko(Srodowisko.Wodne);

            // Act
            amfibia.Przyspiesz(100); // Try to go faster than the water limit

            // Assert
            double waterLimit = ((IPojazdWodny)amfibia).MaxSzybkoscWodna;
            Assert.IsTrue(amfibia.AktualnaSzybkosc <= waterLimit, "Amfibia exceeded water speed limit!");
        }

        [TestMethod]
        public void Rower_HasNoEngine_SilnikIsNull()
        {
            // Arrange & Act
            var bike = new Rower("MTB");

            // Assert
            Assert.IsNull(bike.Silnik, "A bicycle should have a null engine property.");
        }
    }
}