using ATM_CORE.Data;
using ATM_CORE.Models;
using ATM_CORE.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_CORE.Repository.Implements
{
    public class RepositoryCards:Repository<Cards>,IRepositoryCards
    {

        public RepositoryCards(EntityContext EntityContext) : base(EntityContext)
        {

        }

        public Cards FindCardAndPin(string NumberCard, int pin)
        {
            Cards cards = null;
            try
            {

                cards = entityContext.Cards.Where(c => c.CardNumber == NumberCard && c.Pin== pin).First();


            }
            catch (Exception ex)
            {
            }
            return cards;
        }

        public   Cards  FindXNumberCard(string NumberCard)
        {
                Cards cards = null;
                try
                {

                    cards =   entityContext.Cards.Where(c => c.CardNumber == NumberCard).First();

                }
                catch (Exception ex)
                {
                 }
                return cards;
        }
        public List<Cards> FindAll()
        {
            List<Cards> cards = null;
            try
            {

                cards = entityContext.Cards.ToList();

            }
            catch (Exception ex)
            {
            }
            return cards;
        }



    }
}
