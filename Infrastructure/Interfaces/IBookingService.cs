using Entities.Models;
using Entities.ViewModels;

namespace Infrastructure.Interfaces
{
    public interface IBookingService
    {
        void Create(BookingViewModel model);

        Booking MapBooking(BookingViewModel model);
    }
}
