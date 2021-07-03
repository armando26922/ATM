using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATM_CORE.Data;
using ATM_CORE.Models;

namespace ATM_CORE.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class OperationsController : ControllerBase
    {

        private readonly EntityContext _context;

        public OperationsController(EntityContext context)
        {
            _context = context;
        }

        // GET: api/Operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operations>>> GetOperations()
        {
            return await _context.Operations.ToListAsync();
        }

    }
}
