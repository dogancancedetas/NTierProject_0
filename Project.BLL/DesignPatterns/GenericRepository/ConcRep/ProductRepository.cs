using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep
{
    public class ProductRepository: BaseRepository<Product>
    {
        //public override void Update(Product item)
        //{
        //    Product toBeUpdated = Find(item.ID);
        //    item.ImagePath = toBeUpdated.ImagePath;
        //}
    }
}
