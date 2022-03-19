using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi7_DependencyInjectionOrnek.Entities
{
    public partial class Category
    {
        public Category()
        {
            Listings = new HashSet<Listing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LargeImage { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
    }
}
