using Entities;

namespace Infrastructure.Interfaces
{
    public interface IReservationService
    {
        void Create(ReservationViewModel reservation);

        Reservation MapReservation(ReservationViewModel model);
    }
}
