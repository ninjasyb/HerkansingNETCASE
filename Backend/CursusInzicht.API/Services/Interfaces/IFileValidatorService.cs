using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API.Services.Interfaces
{
    public interface IFileValidatorService
    {
        bool IsGeldig(HttpRequest request);

        bool IsTekstBestand(IFormFile file);
        int ValideerRegels(string content);
        bool IsTitelCorrect(string lijn);
        bool IsCodeCorrect(string lijn);

        bool IsDuurCorrect(string lijn);
        bool IsStartDatumCorrect(string lijn);
    }
}