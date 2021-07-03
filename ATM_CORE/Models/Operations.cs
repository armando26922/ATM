using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_CORE.Models
{
    public class Operations
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public DateTime CreationDate { get; set; }
        public  int CardsId  { get;set;}

     }
}
