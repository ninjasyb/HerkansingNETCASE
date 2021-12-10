using CursusInzicht.API.Controllers;
using CursusInzicht.API.Services;
using CursusInzicht.API.Services.Interfaces;
using CursusInzicht.DataAcces;
using CursusInzicht.DataAcces.Repositories;
using CursusInzicht.Domain.Interfaces;
using CursusInzicht.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.Test.API.test.ControllerTests
{
    [TestClass]
    public class CursusInstantieControllerTests
    {
        private readonly CursusInstantieControllerFixture sut = new CursusInstantieControllerFixture();
        
        [TestMethod]
        public async Task getCursusInstantiesShouldReturnOneCursusInstantie() {
            //Arrange
            sut.AddCursusInstantie();
            int expected = 1;

            //Act
            var result = await sut.Get(2021, 49);

            //Assert
            Assert.AreEqual(expected, result.Count());

            //Geen tijd meer
        }
    }

    internal class CursusInstantieControllerFixture
    {
        private readonly DbContextOptions _options;
        private readonly ICursusInstantieRepository _cursusInstantieRepository;
        private readonly IWeekNumberService _weekNumberService;
        private readonly CursusInzichtContext _context;
        private readonly CursusInstantieController _controller;

        public CursusInstantieControllerFixture() {
            _options = new DbContextOptionsBuilder<CursusInzichtContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new CursusInzichtContext(_options);
            _cursusInstantieRepository = new CursusInstantieRepository(_context);
            _weekNumberService = new WeekNumberService();

            _controller = new CursusInstantieController(_cursusInstantieRepository, _weekNumberService);
        }
        public CursusInstantieController GetController() {
            return _controller;
        }
        public void AddCursusInstantie() {
            Cursus cursus = new Cursus() { Titel = "C# programmeren", CursusCode = "CNETIN", Duur = 4 };
            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 10) };
            _context.CursusInstanties.Add(cursusInstantie);
        }

        public async Task<IEnumerable<CursusInstantie>> Get(int year, int week) {
            return await _controller.Get(year, week);
        }

    }
}
