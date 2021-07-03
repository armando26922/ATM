using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATM_CORE.Data;
using ATM_CORE.Models;
using ATM_CORE.Repository.Interface;
using ATM_CORE.Repository.Implements;

namespace ATM_CORE.Services
{
    [Route("[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
 
        IRepositoryCards RepositoryCards;
        IRepositoryOperations RepositoryOperations;

        public CardsController(EntityContext context)
        {
               this.RepositoryCards =new  RepositoryCards(context);
            this.RepositoryOperations = new RepositoryOperations(context);

        }


        [HttpGet("CardsPin/{NumberCards}/{pin}")]
        public ActionResult<Cards> CardsPin( string NumberCards,   int pin)  
        {
             var cards = RepositoryCards.FindXNumberCard(NumberCards);
            if (cards == null)
            {

                return NotFound();
            } else
            {
                if (cards.Pin == pin)
                {
                    cards.NumberAttempts = 0;
                 }
                else {
                    cards.NumberAttempts = cards.NumberAttempts + 1;
 
                }


            }
            if (cards.NumberAttempts >= 4)
            {
                cards.status = "BLOQUEADO";
             }
            RepositoryCards.Update(cards);

            return cards;

        }

        [HttpGet("{NumberCards}")]
        public ActionResult<Cards> GetCards(string NumberCards)
        {
            {
                var cards =   RepositoryCards.FindXNumberCard(NumberCards);
               
                if (cards == null)
                {
                    return NotFound();
                }

                return cards;
            }
        }


        [HttpGet()]
        public ActionResult<List<Cards>> Get()
        {
            {
                var cards = RepositoryCards.FindAll();

                if (cards == null)
                {
                    return NotFound();
                }

                return cards;
            }
        }

        [HttpGet("BalanceCards/{NumberCards}")]
        public ActionResult<Cards> BalanceCards(string NumberCards)
        {
            var cards = RepositoryCards.FindXNumberCard(NumberCards);
            if (cards == null)
            {

                return NotFound();
            }
            Operations operations = new Operations();
            operations.CardsId = cards.Id;
            operations.Amount = 0;
            operations.CreationDate = DateTime.Now;
            RepositoryOperations.Create(operations);
            return cards;

        }


        [HttpGet("ExtractMoney/{NumberCards}/{Amount}")]
        public ActionResult<string> ExtractMoney(string NumberCards,string Amount)
        {
            Double  AmountCard = Convert.ToDouble(Amount);
            string  message= "";
            var cards = RepositoryCards.FindXNumberCard(NumberCards);
            if (cards == null)
            {

                return NotFound();
            }
            if (cards.Amount >=AmountCard)
            {
                Operations operations = new Operations();
                operations.CardsId = cards.Id;
                operations.Amount = AmountCard;
                operations.CreationDate = DateTime.Now;
                cards.Amount= cards.Amount- AmountCard;
                RepositoryCards.Update(cards);
                RepositoryOperations.Create(operations);

            }
            else
            {

                message = "El saldo es insuficiente para el retiro que desea hacer";
            }
            return message;

        } 
    }
}
