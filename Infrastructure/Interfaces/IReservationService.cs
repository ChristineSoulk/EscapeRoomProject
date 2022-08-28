using Entities;

namespace Infrastructure.Interfaces
{
    public interface IReservationService
    {
        void Create(ReservationViewModel model);

        Reservation MapReservation(ReservationViewModel model);
    }
}
