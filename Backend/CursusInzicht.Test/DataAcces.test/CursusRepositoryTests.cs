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
using Xunit;

namespace CursusInzicht.Test.DataAcces.test
{
    [TestClass]
    public class CursusRepositoryTests 
    {
        [TestMethod]
        public async Task GetCursusShouldReturnCursus() {
            //Arrange
            var fixture = new CursusRepositoryFixture();
            Cursus expected = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };
            //Act
            await fixture.Add(expected);
            var result = await fixture.Get(expected);
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public async Task AddCursusShouldAddCursus() {
            //Arrange
            var fixture = new CursusRepositoryFixture();
            Cursus cursus = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };
            int expected = 1;
            
            //Act
            await fixture.Add(cursus);
            var result = await fixture.GetAll();
            //Assert
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public async Task AddIfNotExistsShouldAddCursus() {
            //Arrange
            var fixture = new CursusRepositoryFixture();
            Cursus alreadyInDatabase = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN", CursusId = 1 };
            Cursus toBeAdded = new Cursus() { Titel = "SQL", Duur = 2, CursusCode = "SQLP", CursusId = 2 };
            int expected = 2;
            //Act
            await fixture.Add(alreadyInDatabase);
            await fixture.AddIfNotExist(toBeAdded);

            var result = await fixture.GetAll();
            //Assert
            Assert.AreEqual(expected, result.Count());
        }

        [TestMethod]
        public async Task AddIfNotExistsShouldNotAddCursus() {
            //Arrange
            var fixture = new CursusRepositoryFixture();
            Cursus alreadyInDatabase = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN"};
            Cursus toBeAdded = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN"};
            int expected = 1;

            //Act
            await fixture.Add(alreadyInDatabase);
            await fixture.AddIfNotExist(toBeAdded);

            var result = await fixture.GetAll();
            //Assert
            Assert.AreEqual(expected, result.Count());
        }
        [TestMethod]
        public async Task AddIfNotExistsShouldReturnExistingCursusAndFalseIfCususExists() {
            //Arrange
            var fixture = new CursusRepositoryFixture();
            Cursus alreadyInDatabase = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN" };
            Cursus toBeAdded = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN" };

            //Act
            await fixture.Add(alreadyInDatabase);
            var result = await fixture.AddIfNotExist(toBeAdded);

            //Assert
            Assert.AreEqual(alreadyInDatabase, result.Item1);
            Assert.IsTrue(result.Item2);
        }

        [TestMethod]
        public async Task AddIfNotExistsShouldReturnNewCursusAndTrueIfCususExists() {
            //Arrange
            var fixture = new CursusRepositoryFixture();
            Cursus alreadyInDatabase = new Cursus() { Titel = "C# programmeren", Duur = 3, CursusCode = "CNETIN" };
            Cursus toBeAdded = new Cursus() { Titel = "SQL", Duur = 2, CursusCode = "SQLP" };

            //Act
            await fixture.Add(alreadyInDatabase);
            var result = await fixture.AddIfNotExist(toBeAdded);

            //Assert
            Assert.AreEqual(toBeAdded, result.Item1);
            Assert.IsFalse(result.Item2);
        }
    }


    internal class CursusRepositoryFixture
    {
        private readonly DbContextOptions _options;
        private readonly CursusInzichtContext _context;

        public CursusRepositoryFixture() {
            _options = new DbContextOptionsBuilder<CursusInzichtContext>()
                            .UseInMemoryDatabase(databaseName: "TestDB")
                            .Options;

            _context = new CursusInzichtContext(_options);
            _context.Database.EnsureDeleted();
        }
        
        public async Task<Cursus> Get(Cursus cursus) {
            var sut = new CursusRepository(_context);
            return await sut.Get(cursus);
        }
        public async Task Add(Cursus cursus) {
            var sut = new CursusRepository(_context);
            await sut.Add(cursus);
        }
        public async Task<(Cursus, bool)> AddIfNotExist(Cursus cursus) {
            var sut = new CursusRepository(_context);
            return await sut.AddIfNotExist(cursus);
        }
        public async Task<IEnumerable<Cursus>> GetAll() {
            var sut = new CursusRepository(_context);
            return await sut.GetAll();
        }
    }
}
