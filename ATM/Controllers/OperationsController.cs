using ATM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ATM.Controllers
{
    public class OperationsController : Controller
    {


        private readonly ILogger<OperationsController> _logger;
        //Hosted web API REST Service base url
        string Baseurl = "http://localhost:44351/";

        public OperationsController(ILogger<OperationsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public ActionResult OptionSeleted(string option)
        {
            string ViewName = "";
            switch (option)
            {
                case "Balance":
                    ViewName = "Balance";
                    break;

                case "Retiro":
                    ViewName = "ExtractMoney";
                    break;
                case "Salir":
                    ViewName = "ExtractMoney";
                    break;
            }
            return View(ViewName);

        }

        public async Task<ActionResult> CheckBalance(string NumberCard)
        {
            string NroTarj = NumberCard.Replace("-", "");
            string service = Baseurl + "Cards/BalanceCards/" + NroTarj;
            var client = new HttpClient();
            var response = await client.GetStringAsync(service);
            Cards cards = JsonConvert.DeserializeObject<Cards>(response);
            ViewData["NumberCard"] = NumberCard;
            ViewData["DueDate"] = cards.DueDate;
            ViewData["Amount"] = cards.Amount;
            return View("Balance");

        }

        public ActionResult AmountMoney(string NumberCard)
        {
            ViewData["NumberCard"] = NumberCard;

            return View("ExtractMoney");
        }
        public async Task<ActionResult> ExtractMoney(string NumberCard,string Amount)
        {
            string NroTarj = NumberCard.Replace("-", "");
            string service = Baseurl + "Cards/ExtractMoney/" + NroTarj+"/"+ Amount;
            var client = new HttpClient();
            var message = await client.GetStringAsync(service);
             if (message == "")
            {
                ViewData["message"] = "El retiro se realizo de forma exitosa";
                return View("successfull");
            }
            else {
                ViewData["message"] = message;
                return View("error");
            }
        }
        public   ActionResult PageExtractMoney(string NumberCard)
        {
 
            ViewData["NumberCard"] = NumberCard;
           return View("ExtractMoney");

        }
    }
}
