using Entities;
using Entities.Models;
using Entities.PaypalModels;
using Entities.ViewModels;

namespace Infrastructure.Interfaces
{
    public interface IPaypalPaymentService
    {
        CreatedPaymentModel CreatePaypalPayment(BookingViewModel model, string requestUrlScheme, string requestUrlAuthority, string Cancel = null);

        bool ExecutePaypalPayment(string payerId, string paymentId, string Cancel = null);
    }
}
