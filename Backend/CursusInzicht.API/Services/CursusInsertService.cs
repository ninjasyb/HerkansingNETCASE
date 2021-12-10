using CursusInzicht.API.DTO;
using CursusInzicht.API.Services.Interfaces;
using CursusInzicht.DataAcces.Repositories;
using CursusInzicht.Domain.Interfaces;
using CursusInzicht.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API.Services
{
    public class CursusInsertService : ICursusInsertService
    {
        private readonly ICursusRepository _cursusRepository;
        private readonly ICursusInstantieRepository _cursusInstantieRepository;
        
        public CursusInsertService( ICursusRepository cursusRepository, 
                                    ICursusInstantieRepository cursusInstantieRepository) {
            _cursusInstantieRepository = cursusInstantieRepository;
            _cursusRepository = cursusRepository;
        }

        public async Task<(int, int, int)> Insert(List<CursusInstantie> cursusInstanties) {

            int nieuwCursussen = 0;
            int nieuwInstanties = 0;

            foreach (CursusInstantie cursusInstantie in cursusInstanties) {

                bool cursusBestaat= false;
                bool cursusInstantieBestaat = false;

                (cursusInstantie.Cursus, cursusBestaat) = await _cursusRepository.AddIfNotExist(cursusInstantie.Cursus);
                cursusInstantieBestaat = (await _cursusInstantieRepository.AddIfNotExist(cursusInstantie)).Item2;

                if (!cursusBestaat) {
                    nieuwCursussen++;
                }
                if (!cursusInstantieBestaat) {
                    nieuwInstanties++;
                }

            }
                return (nieuwCursussen, nieuwInstanties, (cursusInstanties.Count - nieuwInstanties));
        }
    }
}
