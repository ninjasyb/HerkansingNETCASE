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
    public class WeekNumberServicesTests
    {

        [TestMethod]
        public void GetWeekOfYearShouldReturn49() {
            //Arrange
            var sut = new WeekNumberServiceFixture();
            DateTime date = new DateTime(2021, 12, 6);
            int expected = 49;
            //Act
            int actual = sut.GetWeekOfYear(date);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GetWeekOfYearShouldReturn1() {

            //Arrange Dit is een lastige datum om goed te krijgen
            var sut = new WeekNumberServiceFixture();
            DateTime date = new DateTime(2012, 12, 31);
            int expected = 1;   // 31 december 2012 hoort volgens de ISO standaard bij week 1 van 2013
            //Act
            int actual = sut.GetWeekOfYear(date);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWeekOfYearShouldReturn52() {
            //Arrange 
            var sut = new WeekNumberServiceFixture();
            DateTime date = new DateTime(2012, 12, 30);
            int expected = 52;
            //Act
            int actual = sut.GetWeekOfYear(date);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetWeekOfYearShouldReturn53() {
            //Arrange 
            var sut = new WeekNumberServiceFixture();
            DateTime date = new DateTime(2020, 12, 28);
            int expected = 53;
            //Act
            int actual = sut.GetWeekOfYear(date);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFirstDateOfWeekShouldReturn6December2021() {
            //Arrange
            var sut = new WeekNumberServiceFixture();
            int year = 2021;
            int weekNr = 49;
            DateTime expected = new DateTime(2021, 12, 6);
            
            //Act
            DateTime actual = sut.GetFirstDateOfWeek(year, weekNr);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFirstDateOfWeekShouldReturn31December2012() {
            //Arrange
            var sut = new WeekNumberServiceFixture();
            int year = 2013;
            int weekNr = 1;
            DateTime expected = new DateTime(2012, 12, 31);

            //Act
            DateTime actual = sut.GetFirstDateOfWeek(year, weekNr);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }

    internal class WeekNumberServiceFixture
    {
        private readonly IWeekNumberService _weekNumberService;

        public WeekNumberServiceFixture() {
            _weekNumberService = new WeekNumberService();
        }

        public int GetWeekOfYear(DateTime time) {
            return _weekNumberService.GetIso8601WeekOfYear(time);
        }

        public DateTime GetFirstDateOfWeek(int year, int week) {
            return _weekNumberService.FirstDateOfWeekISO8601(year, week);
        }
    }
}
