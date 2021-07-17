using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class OrderRepository : SideRepository<Order>
    {
        private readonly ProjectContext _context;

        public OrderRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }


        public Order CreateOrder(Guid customerID)
        {
            Order order = new Order
            {
                CustomerID = customerID,
                Status = Core.Enum.Status.Active,
                OrderDate = DateTime.Now
            };
            return order;
        }
    }
}
