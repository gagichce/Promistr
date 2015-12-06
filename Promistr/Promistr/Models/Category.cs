using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promistr.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeDeleted { get; set; }

        public virtual ICollection<CategoryPromise> CategoryPromises { get; set; }
    }

    public class CategoryPromise
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int PromiseId { get; set; }
        public virtual Promise Promise { get; set; }
        public DateTime TimeAdded { get; set; }
        public DateTime? TimeDeleted { get; set; }
    }
}
