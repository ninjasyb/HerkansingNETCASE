using CursusInzicht.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.Domain.Interfaces
{
    public interface ICursusInstantieRepository
    {
        Task<CursusInstantie> Get(CursusInstantie cursusinstantie);
        Task<IEnumerable<CursusInstantie>> GetInstancesFromWeek(DateTime eersteWeekDag);
        Task Add(CursusInstantie cursusinstantie);
        Task<(CursusInstantie, bool)> AddIfNotExist(CursusInstantie cursusInstantie);
        Task<IEnumerable<CursusInstantie>> GetAll();
    }
}
