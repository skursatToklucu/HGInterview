using HizliGeliyoEcom.Core.Entity.Concrete;
using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.DataAccess.Repositories.Abstract;
using HizliGeliyoEcom.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Repositories.Concrete
{
    public class UserRepository : CoreRepository<Customer>
    {

        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;

        public UserRepository(ProjectContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }


        public Customer CreateCustomer(Customer customer)
        {
            customer.Status = Core.Enum.Status.Active;
            customer.Password = GenerateToken(8);

            return customer;
        }

        /// <summary>
        /// Sepetteki tüm ürünlerin fiyatını hesaplar.
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public double CalculateAll(Guid customerID)
        {
            double TotalPrice = 0;
            List<Order> orders = _context.Orders.AsQueryable().Where(x => x.CustomerID == customerID && x.Status == Core.Enum.Status.Active).ToList();
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (var item in orders)
            {
                //orderDetails.Add(_orderDetailRepository.GetByDefault(x => x.OrderID == item.ID));
                orderDetails.Add(_context.OrderDetails.FirstOrDefault(x => x.OrderID == item.ID));

            }

            foreach (var item in orderDetails)
            {
                TotalPrice += item.TotalPrice;
            }

            return TotalPrice;
        }

    }
}
