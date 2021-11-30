using eTicketAPP.Controllers.Data;
using eTicketAPP.Data.Base;
using eTicketAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketAPP.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducerService
    {
        public ProducersService(AppDbContext context) : base(context) { }
    }
}
