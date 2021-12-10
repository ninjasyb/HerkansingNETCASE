using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CursusInzicht.Domain.Models
{
    public class Cursus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursusId { get; set; }
        public string Titel { get; set; }
        public string CursusCode { get; set; }
        public int Duur { get; set; }
    }
}
