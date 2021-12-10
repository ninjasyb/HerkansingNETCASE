using CursusInzicht.DataAcces;
using CursusInzicht.DataAcces.Repositories;
using CursusInzicht.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.Test.DataAcces.test
{
    [TestClass]
    public class CursusInstantieRepositoryTests
    {
        [TestMethod]
        public async Task GetCursusInstantieShouldReturnCursusInstantie() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };
            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = DateTime.Now };

            //Act
            await fixture.Add(cursusInstantie);
            var result = await fixture.Get(cursusInstantie);
            //Assert
            Assert.AreEqual(cursusInstantie, result);
        }

        [TestMethod]
        public async Task AddCursusShouldAddOneCursusInstantie() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };
            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = DateTime.Now };

            int expected = 1;

            //Act
            await fixture.Add(cursusInstantie);
            var result = await fixture.GetAll();
            //Assert
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public async Task AddIfNotExistsShouldAddCursusInstantieIfNotExists() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };

            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 9) };

            int expected = 1;

            //Act
            await fixture.AddIfNotExist(cursusInstantie);

            var result = await fixture.GetAll();

            //Assert
            Assert.AreEqual(expected, result.Count());
        }
        [TestMethod]
        public async Task AddIfNotExistsShouldNotAddCursusInstantieIfItExists() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };

            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 9) };
            CursusInstantie cursusInstantie1 = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 9) };

            int expected = 1;

            //Act
            await fixture.Add(cursusInstantie);
            await fixture.AddIfNotExist(cursusInstantie1);

            var result = await fixture.GetAll();

            //Assert
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public async Task AddIfExistsCursusShouldNotAddCursusInstantie() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };
            
            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 9) };
            CursusInstantie cursusInstantie1 = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 9) };

            int expected = 1;

            //Act
            await fixture.Add(cursusInstantie);
            await fixture.AddIfNotExist(cursusInstantie1);

            var result = await fixture.GetAll();

            //Assert
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public async Task AddIfExistsShouldReturnCursusInstantieAndFalseIfCursusDiffers() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus CNETIN = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };
            Cursus SQLP = new Cursus() { Titel = "SQL programmeren", Duur = 3, CursusCode = "SQL" };

            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = CNETIN, StartDatum = new DateTime(2021, 12, 9) };
            CursusInstantie toBeAdded = new CursusInstantie() { Cursus = SQLP, StartDatum = new DateTime(2021, 12, 9) };

            //Act
            await fixture.Add(cursusInstantie);
            var result = await fixture.AddIfNotExist(toBeAdded);

            //Assert
            Assert.AreEqual(toBeAdded, result.Item1);
            Assert.IsFalse(result.Item2);
        }

        [TestMethod]
        public async Task AddIfExistsShouldReturnExistingCursusInstantieAndTrue() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };

            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 9) };
            CursusInstantie toBeAdded = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021,12,9) };

            //Act
            await fixture.Add(cursusInstantie);
            var result = await fixture.AddIfNotExist(toBeAdded);

            //Assert
            Assert.AreEqual(cursusInstantie, result.Item1);
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public async Task AddIfNotExistsShouldReturnCursusInstantieAndFalseIfDateDiffers() {
            //Arrange
            var fixture = new CursusInstantieRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };

            CursusInstantie cursusInstantie = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 9) };
            CursusInstantie toBeAdded = new CursusInstantie() { Cursus = cursus, StartDatum = new DateTime(2021, 12, 10) };

            //Act
            await fixture.Add(cursusInstantie);
            var result = await fixture.AddIfNotExist(toBeAdded);

            //Assert
            Assert.AreEqual(toBeAdded, result.Item1);
            Assert.IsFalse(result.Item2);
        }
    }

    internal class CursusInstantieRepositoryFixture
    {

        private readonly DbContextOptions _options;
        private readonly CursusInzichtContext _context;

        public CursusInstantieRepositoryFixture() {
            _options = new DbContextOptionsBuilder<CursusInzichtContext>()
                            .UseInMemoryDatabase(databaseName: "TestDB")
                            .Options;

            _context = new CursusInzichtContext(_options);
            _context.Database.EnsureDeleted();
        }
        public async Task Add(CursusInstantie cursusInstantie) {
            var sut = new CursusInstantieRepository(_context);
            await sut.Add(cursusInstantie);
        }

        public async Task<CursusInstantie> Get(CursusInstantie cursusInstantie) {
            var sut = new CursusInstantieRepository(_context);
            return await sut.Get(cursusInstantie);
        }
        public async Task<(CursusInstantie, bool)> AddIfNotExist(CursusInstantie cursusInstantie) {
            var sut = new CursusInstantieRepository(_context);
            return await sut.AddIfNotExist(cursusInstantie);
        }
        public async Task<IEnumerable<CursusInstantie>> GetInstancesFromWeek(DateTime eersteWeekDag) {
            var sut = new CursusInstantieRepository(_context);
            return await sut.GetInstancesFromWeek(eersteWeekDag);
        }
        public async Task<IEnumerable<CursusInstantie>> GetAll() {
            var sut = new CursusInstantieRepository(_context);
            return await sut.GetAll();
        }
    }
}