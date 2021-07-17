using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class OrderDetailRepository : SideRepository<OrderDetail>
    {
        private readonly ProjectContext _context;

        public OrderDetailRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }


        public OrderDetail CreateOrderDetail(int orderID, int productID)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                OrderID = orderID,
                ProductID = productID,
                Status = Core.Enum.Status.Active,
                TotalPrice = _context.Products.AsQueryable().Where(x => x.ID == productID).Select(x => x.Price).FirstOrDefault()
            };

            return orderDetail;

        }
    }
}
