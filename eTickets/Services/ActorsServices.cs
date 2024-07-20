using eTickets.Data;
using eTickets.Models;
using eTickets.Repository;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services
{
    public class ActorsServices : EntityBaseRepository<Actor>, IActorsServices
    {
        public ActorsServices(ApplicationDbContext context) : base(context) { }
      

       
         
    }
}
