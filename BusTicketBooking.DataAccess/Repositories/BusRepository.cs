using BusTicketBooking.DataAccess.Infrastructure;
using BusTicketBooking.Models;
using BusTicketBooking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBooking.DataAccess.Repositories
{
    public class BusRepository : GenericRepository<Bus>, IBusRepository
    {
        private readonly ApplicationDbContext _context;
        public BusRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public void Update(Bus bus)
        {
           var busfromDb = _context.Bus.FirstOrDefault(x => x.Id == bus.Id);
            if (busfromDb != null)
            {
                busfromDb.BusNumber = bus.BusNumber;
                busfromDb.SeatCapacity = bus.SeatCapacity;
            }
        }

    }
}
