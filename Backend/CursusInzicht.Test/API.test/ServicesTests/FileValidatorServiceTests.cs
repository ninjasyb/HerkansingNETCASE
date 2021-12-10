using CursusInzicht.API.Services;
using CursusInzicht.API.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.Test.API.test.ServicesTests
{
    [TestClass]
    public class FileValidatorServiceTests
    {
        private readonly FileValidatorFixture sut = new FileValidatorFixture();

        [TestMethod]
        public void ValideerRegelsShouldReturn0() {
            //Arrange
            int expected = 0;
            string content = "Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 7/12/2021";
            //Act
            int actual = sut.ValideerRegels(content);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValideerRegelsShouldReturn2() {
            //Arrange
            int expected = 2;
            string content = "Titel: C# Programmeren\r\nCursuscode CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 7/12/2021";


            //Act
            int actual = sut.ValideerRegels(content);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ValideerRegelsShouldReturn0WithMultipleParagraphs() {
            //Arrange
            int expected = 0;
            string content = 
@"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 7/12/2021

Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 8/12/2021";
            //Als ik deze content juist laat indenten wordt er een \r\n toegevoegd tussen regels en werkt het niet
            // En ja, het doet ook pijn aan mijn ogen


            //Act
            int actual = sut.ValideerRegels(content);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValideerRegelsShouldReturn8WithMultipleParagraphs() {
            //Arrange
            int expected = 8;
            string content =
@"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 7/12/2021

Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 
Startdatum: 8/12/2021";

            //Act
            int actual = sut.ValideerRegels(content);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsTitelCorrectShouldReturnTrue() {
            //Arrange
            string titelRegel = "Titel: C# Programmeren";

            //Act
            bool result = sut.IsTitelCorrect(titelRegel);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsTitelCorrectShouldReturnFalseIfLineIsEmpty() {
            //Arrange
            string regel = "";

            //Act
            bool result = sut.IsTitelCorrect(regel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTitelCorrectShouldReturnFalseIfTitelLineIsInvalid() {
            //Arrange
            string titelRegel = "Titel C# Programmeren";

            //Act
            bool result = sut.IsTitelCorrect(titelRegel);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsTitelCorrectShouldReturnFalseIfLineIsCursusCode() {
            //Arrange
            string titelRegel = "Cursuscode: CNETIN";

            //Act
            bool result = sut.IsTitelCorrect(titelRegel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsDuurCorrectShouldReturnTrue() {
            //Arrange
            string duurRegel = "Duur: 5 dagen";

            //Act
            bool result = sut.IsDuurCorrect(duurRegel);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsDuurCorrectShouldReturnFalseIfLineIsEmpty() {
            //Arrange
            string regel = "";

            //Act
            bool result = sut.IsDuurCorrect(regel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsDuurCorrectShouldReturnFalseIfLineIsIncorrect() {
            //Arrange
            string duurRegel = "Duur: 5";

            //Act
            bool result = sut.IsDuurCorrect(duurRegel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsDuurCorrectShouldReturnFalseIfLineIsCursusCodeLine() {
            //Arrange
            string duurRegel = "Cursuscode: CNETIN";

            //Act
            bool result = sut.IsDuurCorrect(duurRegel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCodeCorrectShouldReturnTrue() {
            //Arrange
            string cursusCodeRegel = "Cursuscode: CNETIN";

            //Act
            bool result = sut.IsCodeCorrect(cursusCodeRegel);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCodeCorrectShouldReturnFalseIfLineIsEmpty() {
            //Arrange
            string regel = "";

            //Act
            bool result = sut.IsCodeCorrect(regel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCodeCorrectShouldReturnFalseIfLineIsIncorrect() {
            //Arrange
            string cursusCodeRegel = "Cursuscode CNETIN";

            //Act
            bool result = sut.IsCodeCorrect(cursusCodeRegel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCodeCorrectShouldReturnFalseIfLineIsDuur() {
            //Arrange
            string cursusCodeRegel = "Duur: 5 dagen";

            //Act
            bool result = sut.IsCodeCorrect(cursusCodeRegel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStartDatumCorrectShouldReturnTrue() {
            //Arrange
            string startDatumRegel = "Startdatum: 7/12/2021";

            //Act
            bool result = sut.IsStartDatumCorrect(startDatumRegel);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStartDatumCorrectShouldReturnFalseIfDateIsNotSeperatedBySlashes() {
            //Arrange
            string startDatumRegel = "Startdatum: 7-12-2021";

            //Act
            bool result = sut.IsStartDatumCorrect(startDatumRegel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStartDatumCorrectShouldReturnFalseIfDateIsIncorrectFormat() {
            //Arrange
            string startDatumRegel = "Startdatum: 2021/12/7";

            //Act
            bool result = sut.IsStartDatumCorrect(startDatumRegel);
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStartDatumCorrectShouldReturnFalseIfDateLineIsIncorrect() {
            //Arrange
            string startDatumRegel = "Start: 7/12/2021";

            //Act
            bool result = sut.IsStartDatumCorrect(startDatumRegel);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsStartDatumCorrectShouldReturnFalseIfDateLineIsDuur() {
            //Arrange
            string startDatumRegel = "Duur: 5 dagen";

            //Act
            bool result = sut.IsStartDatumCorrect(startDatumRegel);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsStartDatumCorrectShouldReturnFalseIfLineIsEmpty() {
            //Arrange
            string regel = "";

            //Act
            bool result = sut.IsStartDatumCorrect(regel);
            //Assert
            Assert.IsFalse(result);
        }

    }

    internal class FileValidatorFixture
    {
        private readonly IFileValidatorService _fileValidatorService;
        public FileValidatorFixture() {
            _fileValidatorService = new FileValidatorService();
        }

        public int ValideerRegels(string content) {
            return _fileValidatorService.ValideerRegels(content);
        }
        public bool IsTitelCorrect(string titel) {
            return _fileValidatorService.IsTitelCorrect(titel);
        }
        public bool IsDuurCorrect(string duur) {
            return _fileValidatorService.IsDuurCorrect(duur);
        }
        public bool IsCodeCorrect(string code) {
            return _fileValidatorService.IsCodeCorrect(code);
        }
        public bool IsStartDatumCorrect(string startdatum) {
            return _fileValidatorService.IsStartDatumCorrect(startdatum);
        }
    }
}
