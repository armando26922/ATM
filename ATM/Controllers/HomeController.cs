using ATM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Hosted web API REST Service base url
        string Baseurl = "http://localhost:44351/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public int VerificarTarjeta()
        //{



        //    return 1;
        //}

        public async Task<ActionResult> VerifyCards(string NumberCard)
        {


            try
            {
                string NroTarj = NumberCard.Replace("-", "");
                string service = Baseurl + "Cards/" + NroTarj;
                var client = new HttpClient();
                var response = await client.GetStringAsync(service);
                Cards cards = JsonConvert.DeserializeObject<Cards>(response);
                if (cards.status == "BLOQUEADO")
                {
                    return View("CardBlocked");

                }
                else
                {
                    ViewData["NumberCard"] = NumberCard;
                    return View("Pin");

                }


            }
            catch (Exception ex)
            {

                ViewData["Error"] = "Ocurrio un error no se consiguio la tarjeta";
                return View("Error");

            }
 
        }
        public ActionResult PageOperations(string NumberCard)
        {


            ViewData["NumberCard"] = NumberCard;
            return View("Operations");

        }
        public async Task<ActionResult> VerifyPin(string pin,string NumberCard)
        {
            try
            {
                string NroTarj = NumberCard.Replace("-", "");
                string service = Baseurl + "Cards/CardsPin/" + NroTarj + "/" + pin;
                var client = new HttpClient();
                var response = await client.GetStringAsync(service);
                Cards cards = JsonConvert.DeserializeObject<Cards>(response);
                if (cards != null)
                {

                    if (cards.Pin == Convert.ToInt32(pin) && cards.status == "ACTIVO")
                    {
                        ViewData["NumberCard"] = NumberCard;
                        return View("Operations");

                    }
                    else
                    {

                        if (cards.status != "ACTIVO")
                        {
                            ViewData["Error"] = "La Tarjeta se encuentra bloqueada";
                            return View("Error");

                        }
                        else
                        {

                            if (cards.Pin != Convert.ToInt32(pin))
                            {
                                ViewData["Error"] = "El Pin es invalido";
                                return View("Error");

                            }


                        }

                    }
                }

            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Ocurrio un error en el sistema";
                return View("Error");
            }

            ViewData["Error"] = "Ocurrio un error en el sistema";
            return View("Error");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
