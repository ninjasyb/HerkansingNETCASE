using CursusInzicht.API.DTO;
using CursusInzicht.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API.Services.Interfaces
{
    public interface ICursusInsertService
    {
        Task<(int, int, int)> Insert(List<CursusInstantie> cursusInstanties);
    }
}
