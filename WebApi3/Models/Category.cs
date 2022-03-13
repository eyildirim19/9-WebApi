using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApi3.Models
{
    public partial class Category
    {
        public Category()
        {
            Listings = new HashSet<Listing>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Kategori Adı Zorunlu")]
        [StringLength(20,ErrorMessage = "Kategori Adı Max. 20 karakter girilebilir")]
       public string Name { get; set; }
        public string IconPath { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage ="Açıklama zorunlu")]
        public string Description { get; set; }
        public string LargeImage { get; set; }

        public virtual ICollection<Listing> Listings { get; set; }
    }
}
