using CursusInzicht.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.Domain.Interfaces
{
    public interface ICursusRepository
    {
        Task<Cursus> Get(Cursus cursus);
        Task Add(Cursus cursus);
        Task<(Cursus, bool)> AddIfNotExist(Cursus cursus);
        Task<IEnumerable<Cursus>> GetAll();
    }
}
