using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TestApp.Models;

namespace MVC_TestApp.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Payments()
        {
            Orders o = new Orders();
            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);

            //RazorPay API ID and secret key
            string key = "rzp_test_xxxxxxxxxxx";
            string secret = "xxxxxxxxxxxxxxxxx";

            RazorpayClient client = new RazorpayClient(key, secret);

            //order creation
            Razorpay.Api.Order order = client.Order.Create(input);

            //order id of new order
            o.orderId = order["id"].ToString();
            return View(o);
        }
    }
}
