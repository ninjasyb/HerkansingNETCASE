using CursusInzicht.API.Controllers;
using CursusInzicht.API.DTO;
using CursusInzicht.API.Services;
using CursusInzicht.API.Services.Interfaces;
using CursusInzicht.DataAcces;
using CursusInzicht.DataAcces.Repositories;
using CursusInzicht.Domain.Interfaces;
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
    public class UploadControllerTests
    {
        private readonly UploadControllerFixture sut = new UploadControllerFixture();

        [TestMethod]
        public void PostingOneCorrectCursusInstantieShouldReturnUploadResultaat() {
            
            
            //Arrange
            
            //Act

            //Assert
        }

    }
    internal class UploadControllerFixture
    {
        private readonly UploadController _uploadController;
        private readonly DbContextOptions _options;
        private readonly CursusInzichtContext _context;

        public UploadControllerFixture() {
            _options = new DbContextOptionsBuilder<CursusInzichtContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            _context = new CursusInzichtContext(_options);
            ICursusRepository cursusRepository = new CursusRepository(_context);
            ICursusInstantieRepository cursusInstantieRepository = new CursusInstantieRepository(_context);
            IFileValidatorService fileValidatorService= new FileValidatorService();
            ICursusExtractorService cursusExtractorService = new CursusExtractorService();
            ICursusInsertService cursusInsertService = new CursusInsertService(cursusRepository, cursusInstantieRepository);

            _uploadController = new UploadController(fileValidatorService,cursusExtractorService,cursusInsertService);
        }


        public async Task<UploadResultaat> Post() {
            return await _uploadController.Post();
        }

    }
}
