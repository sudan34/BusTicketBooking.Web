using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBooking.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        IBusRepository BusRepository { get; }
        ISeatRepository SeatRepository { get; }
        void Save();
    }
}
