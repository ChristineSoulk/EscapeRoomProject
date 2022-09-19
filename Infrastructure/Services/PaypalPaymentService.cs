using Entities;
using EscapeRoomApp.Models;
using Infrastructure.Interfaces;
using PayPal.Api;
using System;
using System.Collections.Generic;
using RepositoryServices.Persistance;
using DatabaseLibrary;
using Entities.Exceptions;
using Entities.Models;
using Entities.ViewModels;
using Entities.PaypalModels;

namespace Infrastructure.Services
{
    public class PaypalPaymentService : IPaypalPaymentService
    {
        private Payment payment;

        private readonly ApplicationContext _dbContext = new ApplicationContext();
        private readonly UnitOfWork _unitOfWork;
        private readonly APIContext _paypalApiContext;
        private readonly IBookingService _BookingService;

        public PaypalPaymentService(IBookingService BookingService)
        {
            _unitOfWork = new UnitOfWork(_dbContext);
            _paypalApiContext = PaypalConfiguration.GetAPIContext();
            _BookingService = BookingService;
        }

        public CreatedPaymentModel CreatePaypalPayment(BookingViewModel model, string requestUrlScheme, string requestUrlAuthority, string cancel = null)
        {
            try
            {
                //Here we pass the endpoint that Paypal will hit after creating the payment in order to execute it.
                string baseURI = requestUrlScheme + "://" + requestUrlAuthority + "/PaypalPayment/ExecutePayment?";

                var guid = Convert.ToString(new Random().Next(100000));

                var createdPayment = CreatePayment(_paypalApiContext, baseURI + "guid=" + guid, model);

                var links = createdPayment.links.GetEnumerator();
                string paypalRedirectUrl = null;

                while (links.MoveNext())
                {
                    Links lnk = links.Current;
                    if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        paypalRedirectUrl = lnk.href;
                    }
                }

                return new CreatedPaymentModel
                {
                    PaymentId = createdPayment.id,
                    PaypalRedirectUrl = paypalRedirectUrl
                };

            }
            catch (Exception ex)
            {
                throw new WebAppException(ex.Message, ex);
            }
        }

        public bool ExecutePaypalPayment(string payerId, string paymentId, string cancel = null)
        {
            try
            {
                var executedPayment = ExecutePayment(_paypalApiContext, payerId, paymentId);
                if (executedPayment.state.ToLower() != "approved")
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new WebAppException(ex.Message, ex);
            }
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl, BookingViewModel rvm)
        {
            var room = _unitOfWork.Rooms.GetById(rvm.RoomId);
            var Booking = _BookingService.MapBooking(rvm);

            var itemList = new ItemList()
            {
                items = new List<Item>()
            };

            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = room.Title,
                currency = "EUR",
                price = Booking.CalculationTotalPrice(room.StartingPricePerPerson, room.DiscountPerPerson, Booking.NumberOfPlayers).ToString("0.00"),
                quantity = "1",
                sku = "sku"
            });

            var payer = new Payer()
            {
                payment_method = "paypal"
            };

            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "1",
                shipping = "0.00",
                subtotal = Booking.CalculationTotalPrice(room.StartingPricePerPerson, room.DiscountPerPerson, Booking.NumberOfPlayers).ToString("0.00")
            };

            //Final amount with details  
            var amount = new Amount()
            {
                currency = "EUR",
                total = (Convert.ToDecimal(details.subtotal) + Convert.ToDecimal(details.tax) + Convert.ToDecimal(details.shipping)).ToString("0.00"), // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };

            var transactionList = new List<Transaction>();

            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = Convert.ToString((new Random()).Next(10000000)), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            // Create a payment using a APIContext  
            return payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            payment = new Payment()
            {
                id = paymentId
            };

            return payment.Execute(apiContext, paymentExecution);
        }
    }
}
