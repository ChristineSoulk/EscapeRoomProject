using Entities;
using Entities.Models;

namespace Infrastructure.Interfaces
{
    public interface IPaypalPaymentService
    {
        CreatedPaymentModel CreatePaypalPayment(ReservationViewModel model, string requestUrlScheme, string requestUrlAuthority, string Cancel = null);

        bool ExecutePaypalPayment(string payerId, string paymentId, string Cancel = null);
    }
}
