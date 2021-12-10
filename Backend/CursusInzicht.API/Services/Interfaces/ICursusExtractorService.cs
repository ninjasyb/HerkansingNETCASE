using CursusInzicht.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API.Services.Interfaces
{
    public interface ICursusExtractorService
    {
        List<CursusInstantie> MaakCursusInstanties(string fileContent);
    }
}
