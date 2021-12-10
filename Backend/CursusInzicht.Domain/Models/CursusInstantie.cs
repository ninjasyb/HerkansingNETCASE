using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CursusInzicht.Domain.Models
{
    public class CursusInstantie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursusInstantieId { get; set; }
        public DateTime StartDatum { get; set; }
        public virtual Cursus Cursus { get; set; }
    }
}
