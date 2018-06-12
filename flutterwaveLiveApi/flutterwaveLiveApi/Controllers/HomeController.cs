using Flutterwave_API.Models;
using flutterwaveLiveApi.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace flutterwaveLiveApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.State = false;
            return View();
        }
        [HttpPost]
        public ActionResult Index(ValidationClass User)
        {
            if (ModelState.IsValid)
            {
                ViewBag.State = true;
                ViewBag.Amount = User.Amount;
            }
            else
            {

            }

            return View();
        }
        public ActionResult Validate(string UserId)
        {
           
            var data = new { txref = "rave-1456", SECKEY = "FLWSECK-1258d6215ae79df5ba7716dc25de858a-X", include_payment_entity = 1 };
            var client = new HttpClient(); /*OH - AAED44*/
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseMessage = client.PostAsJsonAsync("https://api.ravepay.co/flwv3-pug/getpaidx/api/xrequery", data).Result;
            var responseStr = responseMessage.Content.ReadAsStringAsync().Result;
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(responseStr);
            if (response.data.status == "successful" && response.data.amount == "10" && response.data.chargecode == "00")
            {

                ViewBag.Status = "Successful";
            }
            else
            {
                ViewBag.Status = "Failed";
            }
            return View();
        }
    }
}