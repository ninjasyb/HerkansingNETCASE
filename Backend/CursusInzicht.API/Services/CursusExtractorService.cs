using CursusInzicht.API.Services.Interfaces;
using CursusInzicht.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API.Services
{
    public class CursusExtractorService : ICursusExtractorService
    { 
        public List<CursusInstantie> MaakCursusInstanties(string fileContent) {
            List<CursusInstantie> cursusInstanties = new List<CursusInstantie>();

            string[] paragraven = fileContent.Trim().Split("\r\n\r\n");
            
            foreach (string paragraaf in paragraven) {

                string[] regels = paragraaf.Split("\n");

                if (paragraaf.Length > 1) {
                    Cursus cursus = new Cursus();
                    cursus.Titel = regels[0].Substring(7).Trim();
                    cursus.CursusCode = regels[1].Substring(12).Trim();
                    cursus.Duur = int.Parse(regels[2].Trim().Substring(6, 1));
                    DateTime startDatum = DateTime.Parse(regels[3].Trim().Substring(12));

                    cursusInstanties.Add(new CursusInstantie() { Cursus = cursus, StartDatum = startDatum });
                }
            }
            return cursusInstanties;
        }
    }
}
