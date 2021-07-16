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
    public class UserRepository : Repository<Customer>
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

    }
}
