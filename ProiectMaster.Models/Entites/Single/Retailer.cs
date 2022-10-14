using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMaster.Models.Entites
{
    public partial class Retailer : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
