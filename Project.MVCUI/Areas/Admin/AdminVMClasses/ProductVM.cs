using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Areas.Admin.AdminVMClasses
{
    public class ProductVM //PaginationVM ile neredeyse aynı görevi yapıyor gibi gözükebilir. Çok benzer görevleri yapmaktadır. PaginationVM sadece alışveriş tarafında kullanılacak ve sayfalandırmayı yapacak bir VM iken ProductVM sadece Admin tarafında kullanılması için tasarlanmış bir VM'dir
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}