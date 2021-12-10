using CursusInzicht.API.DTO;
using CursusInzicht.API.Services.Interfaces;
using CursusInzicht.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CursusInzicht.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileValidatorService _fileValidatorService;
        private readonly ICursusExtractorService _cursusExtractorService;
        private readonly ICursusInsertService _cursusInsertService;

        public UploadController(
            IFileValidatorService fileValidatorService,
            ICursusExtractorService cursusExtractorService,
            ICursusInsertService cursusInsertService) {
            _fileValidatorService = fileValidatorService;
            _cursusExtractorService = cursusExtractorService;
            _cursusInsertService = cursusInsertService;
        }

        // POST api/<UploadController>
        [HttpPost]
        public async Task<UploadResultaat> Post() {

            UploadResultaat resultaat = new UploadResultaat {
                Fout = true
            };

            if (!_fileValidatorService.IsGeldig(Request)) {
                resultaat.Bericht = "Bestand kan niet worden geladen.";
                return resultaat;
            }
            var file = Request.Form.Files[0];

            if (!_fileValidatorService.IsTekstBestand(file)) {
                resultaat.Bericht = "Bestand moet een .txt bestand zijn.";
                return resultaat;
            }

            var fileContent = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream())) {
                while (reader.Peek() >= 0)
                    fileContent.AppendLine(reader.ReadLine());
            }

            int regelNr = _fileValidatorService.ValideerRegels(fileContent.ToString());

            if(regelNr != 0) {
                resultaat.Bericht = $"Er is een fout opgetreden op regel {regelNr}.";
                return resultaat;
            }

            List<CursusInstantie> cursusInstanties = _cursusExtractorService.MaakCursusInstanties(fileContent.ToString());

            (resultaat.NieuwCursussen, resultaat.NieuwInstanties, resultaat.Duplicaten) = await _cursusInsertService.Insert(cursusInstanties);
            resultaat.Fout = false;
            return resultaat;
        }
    }
}
