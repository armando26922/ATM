using ATM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_CORE.Repository.Interface
{
    public interface IRepositoryCards:IRepository<Cards>
    {

         Cards getCard(int id)
        {

            return new Cards(); 
        }

        public Cards FindXNumberCard(string NumberCard);
        public Cards FindCardAndPin(string NumberCard,int pin);
        public List<Cards> FindAll();

    }
}
