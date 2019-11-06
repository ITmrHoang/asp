using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NauAn.Models.Entities
{
    public class Rank
    {
        public int ID { get; set; }
        public string RankName { get; set; }
        public string Color { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
