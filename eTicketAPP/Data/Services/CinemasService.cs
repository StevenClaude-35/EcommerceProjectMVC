using eTicketAPP.Controllers.Data;
using eTicketAPP.Data.Base;
using eTicketAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketAPP.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>,ICinemasService
    {
       
        public CinemasService(AppDbContext context) : base(context) { }
    }
}
