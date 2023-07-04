using BusTicketBooking.Models;
using BusTicketBooking.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketBooking.DataAccess.Infrastructure
{
    public interface IBusRepository : IGenericRepository<Bus>
    {
        void Update(Bus bus);
    }
}
