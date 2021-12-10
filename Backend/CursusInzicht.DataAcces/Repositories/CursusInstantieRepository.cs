using CursusInzicht.Domain.Interfaces;
using CursusInzicht.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.DataAcces.Repositories
{
    public class CursusInstantieRepository : ICursusInstantieRepository
    {
        private readonly CursusInzichtContext _context;
        public CursusInstantieRepository(CursusInzichtContext context) {
            _context = context;
        }
        public async Task Add(CursusInstantie cursusInstantie) {
            _context.CursusInstanties.Add(cursusInstantie);
            await _context.SaveChangesAsync();
        }

        public async Task<CursusInstantie> Get(CursusInstantie cursusInstantie) {
            return await _context.CursusInstanties.FirstOrDefaultAsync(c => c.Cursus.CursusCode == cursusInstantie.Cursus.CursusCode
                                                                            && c.StartDatum == cursusInstantie.StartDatum);
        }
        public async Task<(CursusInstantie, bool)> AddIfNotExist(CursusInstantie cursusInstantie) {

            bool exist = (await Get(cursusInstantie) != null);

            if (!exist) {
                await Add(cursusInstantie);
            }
            return (await Get(cursusInstantie), exist);
        }

        public async Task <IEnumerable<CursusInstantie>> GetInstancesFromWeek(DateTime eersteWeekDag) {
            var instanties = await _context.CursusInstanties
                                            .Where(i => i.StartDatum >= eersteWeekDag && i.StartDatum < eersteWeekDag.AddDays(7))
                                            .Include(c => c.Cursus)
                                            .ToListAsync();
            instanties.Sort((x, y) => DateTime.Compare(x.StartDatum, y.StartDatum));
            return instanties;
        }

        public async Task<IEnumerable<CursusInstantie>> GetAll() {
            return await _context.CursusInstanties.ToListAsync();
        }
    }
}
