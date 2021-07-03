using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_CORE.Models
{
    public class Cards
    {

        public int Id { get; set; }

        public string CardNumber { get; set; }
        public int Pin { get; set; }
        public double Amount { get; set; }

        public string status { get; set; }
        public int NumberAttempts { get; set; }

        public DateTime DueDate { get; set; }

        public List<Operations> ListOperations { get; set; }

    }
}
