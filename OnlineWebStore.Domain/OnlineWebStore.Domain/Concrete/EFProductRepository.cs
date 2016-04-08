using OnlineWebStore.Domain.Astract;
using OnlineWebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWebStore.Domain.Concrete
{
    public class EFProductRepository: IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Entities.Product> Products
        {
            get { return context.Products; }
        }
    }
}
