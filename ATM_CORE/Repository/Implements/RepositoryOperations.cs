using ATM_CORE.Data;
using ATM_CORE.Models;
using ATM_CORE.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_CORE.Repository.Implements
{
    public class RepositoryOperations : Repository<Operations>, IRepositoryOperations
    {
        public RepositoryOperations(EntityContext EntityContext) : base(EntityContext)
        {

        }
    }
}
