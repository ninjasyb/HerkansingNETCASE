using CursusInzicht.API.Services;
using CursusInzicht.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.Test.API.test.ServicesTests
{

    //De cursusextractorservice wordt aangeroepen nadat het bestand is gecheckt op fouten (filevalidatorservice), dus word daar in deze service geen rekening mee gehouden.
    // Ik zou kunnen testen met een incorrect format, maar in de code wordt de service pas aangeroepen nadat is vastgesteld dat het format correct is en fouten afgevangen zijn.
    [TestClass]
    public class CursusExtractorServiceTests
    {
        private readonly CursusExtractorFixture sut = new CursusExtractorFixture();

        [TestMethod]
        public void MaakCurusInstantiesShouldReturnOneCursusInstantie() {
            //Arrange
            string filecontent = "Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 7/12/2021";
            int expected = 1;
            //Act
            List<CursusInstantie> result = sut.MaakCursusInstanties(filecontent);
            //Assert
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public void MaakCurusInstantiesShouldReturnTwoCursusInstantie() {
            //Arrange
            string filecontent =
@"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 7/12/2021

Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 8/12/2021";

            int expected = 2;
            //Act
            List<CursusInstantie> result = sut.MaakCursusInstanties(filecontent);
            //Assert
            Assert.AreEqual(expected, result.Count());
        }
    }

    internal class CursusExtractorFixture
    {
        private readonly CursusExtractorService _cursusExtractorService;
        public CursusExtractorFixture() {
            _cursusExtractorService = new CursusExtractorService();
        }

        public List<CursusInstantie> MaakCursusInstanties(string fileContent) {
            return _cursusExtractorService.MaakCursusInstanties(fileContent);
        }
    }
}
