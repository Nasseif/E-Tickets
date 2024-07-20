using eTickets.Data;
using eTickets.Models;
using eTickets.Repository;

namespace eTickets.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
