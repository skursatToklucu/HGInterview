using HizliGeliyoEcom.DataAccess.Context;
using HizliGeliyoEcom.DataAccess.Repositories.Concrete;
using HizliGeliyoEcom.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HizliGeliyoEcom.WebUI.Controllers
{
    public class ShopController : Controller
    {

        private readonly ProductRepository _productRepository;
        private readonly OrderRepository _orderRepository;
        private readonly OrderDetailRepository _orderDetailRepository;
        private readonly UserRepository _userRepository;

        public ShopController(ProjectContext context, IHttpContextAccessor httpContext)
        {
            _productRepository = new ProductRepository(context);
            _orderRepository = new OrderRepository(context);
            _orderDetailRepository = new OrderDetailRepository(context);
            _userRepository = new UserRepository(context, httpContext);
        }
        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
        }


        [Route("~/Shop/AddToCart/{productID}")]
        public IActionResult AddtoCart(int productID)
        {
            Guid customerID = Guid.Parse(HttpContext.Session.GetString("CustomerID"));

            _orderRepository.Add(_orderRepository.CreateOrder(customerID));
            _orderDetailRepository.Add(_orderDetailRepository.CreateOrderDetail(_orderRepository.GetByLast(x => x.CustomerID == customerID).ID, productID));


            return RedirectToAction("Index", "Shop");
        }


        public IActionResult ShoppingBasket()
        {
            Guid customerID = Guid.Parse(HttpContext.Session.GetString("CustomerID"));

            List<OrderDetail> activeOrderDetails = _orderDetailRepository.GetActive();
            List<Product> activeProducts = new List<Product>();

            foreach (var item in activeOrderDetails)
            {
                activeProducts.Add(_productRepository.GetByDefault(x => x.ID == item.ProductID));
            }

            ViewBag.TotalPrice = _userRepository.CalculateAll(customerID).ToString();

            return View(activeProducts);
        }



        [Route("~/Shop/DismissProduct/{id}")]
        public IActionResult DismissProduct(int id)
        {
            _orderDetailRepository.DeActivate(_orderDetailRepository.GetByDefault(x => x.ProductID == id).ID);

            return RedirectToAction("ShoppingBasket", "Shop");
        }


        public IActionResult Payment()
        {
            //Odeme ve Kredi Karti bilgilerini girme islemini yapmadım.

            return View();
        }
    }
}
