using eTickets.Data;
using eTickets.Models;
using eTickets.Repository;

namespace eTickets.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
