using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class ProductRepository : SideRepository<Product>
    {
        private readonly ProjectContext _context;

        public ProductRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }
    }
}
