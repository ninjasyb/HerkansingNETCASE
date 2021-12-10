using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursusInzicht.API.DTO
{
    public class UploadResultaat
    {
        public int NieuwCursussen { get; set; }
        public int NieuwInstanties { get; set; }
        public int Duplicaten { get; set; }
        public bool Fout { get; set; }
        public string Bericht { get; set; }
    }
}
