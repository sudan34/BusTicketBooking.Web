using BusTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBooking.DataAccess.Infrastructure
{
    public interface ISeatRepository:IGenericRepository<SeatDetails>
    {
        void Update(SeatDetails seat);
    }
}
