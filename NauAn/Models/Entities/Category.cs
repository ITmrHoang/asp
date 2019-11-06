using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NauAn.Models.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParrentId { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
