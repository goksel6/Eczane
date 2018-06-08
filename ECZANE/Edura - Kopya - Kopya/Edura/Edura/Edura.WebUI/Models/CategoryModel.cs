using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
        public int Count { get; set; }
    }
}
