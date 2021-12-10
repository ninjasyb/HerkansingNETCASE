using CursusInzicht.Domain.Interfaces;
using CursusInzicht.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.DataAcces.Repositories
{
    public class CursusRepository : ICursusRepository
    {
        private readonly CursusInzichtContext _context;

        public CursusRepository(CursusInzichtContext context) {
            _context = context;
        }

        public async Task Add(Cursus cursus) {
            _context.Cursussen.Add(cursus);
            await _context.SaveChangesAsync();
        }

        public async Task<Cursus> Get(Cursus cursus) {
            return await _context.Cursussen.FirstOrDefaultAsync(c => c.CursusCode == cursus.CursusCode);
        }
        
        public async Task<(Cursus, bool)> AddIfNotExist(Cursus cursus) {
        
            bool exist = (await Get(cursus) != null);
            
            if (!exist){
                await Add(cursus);
            }
            return (await Get(cursus), exist);
        }

        public async Task<IEnumerable<Cursus>> GetAll() {
            return await _context.Cursussen.ToListAsync();
        }
    }
}
