using BusTicketBooking.DataAccess.Infrastructure;
using BusTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBooking.DataAccess.Repositories
{
    public class SeatRepository : GenericRepository<SeatDetails>, ISeatRepository
    {
        private readonly ApplicationDbContext _context;
        public SeatRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(SeatDetails seat)
        {
            var SeatfromDb = _context.SeatDetails.FirstOrDefault(x => x.Id == seat.Id);
            if (SeatfromDb != null)
            {
                SeatfromDb.SeatNo = seat.SeatNo;
                SeatfromDb.BusId = seat.BusId;
                SeatfromDb.Description = seat.Description;
            }
        }

    }
}
