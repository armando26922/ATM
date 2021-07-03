using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Operations
    {
        public int Id { get; set; }

         public float Amount { get; set; }

        public DateTime CreationDate { get; set; }
        public int CardsId { get; set; }

    }
}
