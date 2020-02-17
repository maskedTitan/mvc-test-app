using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TestApp.Controllers
{
    public class ChargeController : Controller
    {
        public ActionResult Charge()
        {
            string paymentId = Request.Form["razorpay_payment_id"];
            

            if (paymentId == null)
            {
                ViewData["code"] = Request.Form["error[code]"];
                ViewData["description"] = Request.Form["error[description]"];
                return View();
            }

            Dictionary<string, object> input = new Dictionary<string, object>();

            string key = "rzp_test_xxxxxxxxxxx";
            string secret = "xxxxxxxxxxxxxxxxx";

            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, string> attributes = new Dictionary<string, string>();

            attributes.Add("razorpay_payment_id", paymentId);
            attributes.Add("razorpay_order_id", Request.Form["razorpay_order_id"]);
            attributes.Add("razorpay_signature", Request.Form["razorpay_signature"]);

            Utils.verifyPaymentSignature(attributes);
            ViewData["msg"] = "Payment Sucessfull..!";
            ViewData["id"] = Request.Form["razorpay_payment_id"];

           
            return View();
        }

     
    }
}
