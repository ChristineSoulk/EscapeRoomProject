using Entities;
using EscapeRoomApp.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoomApp.Controllers
{
    public class ReservationController : BaseClassController
    {
        // GET: Reservation
        public ActionResult Index()
        {

            return View();
        
        }
        public ActionResult MakeReservation(int roomId)
        {
            var room = UnitOfWork.Rooms.GetById(roomId);
            var reservation = new Reservation();
            reservation.RoomId = roomId;
            reservation.Room = room;
            
            DateTime startTime = DateTime.Parse("18:00:00");
            DateTime endTime = DateTime.Parse("22:00:00");

            List<SelectListItem> list = new List<SelectListItem>();
            while (startTime <= endTime)
            {
                list.Add(new SelectListItem() { Text = startTime.ToShortTimeString() + "-" + startTime.AddMinutes(room.Duration).ToShortTimeString(), Value = startTime.ToShortTimeString() });
                startTime = startTime.AddMinutes(room.Duration);

            }

            ViewBag.HourList = list;

            return View(reservation);
        }
        [HttpPost]
        public ActionResult MakeReservation(ReservationViewModel dto)
        {
            Reservation reservation = new Reservation();
            dto.Room = UnitOfWork.Rooms.GetById(dto.RoomId);
            reservation.RoomId = dto.RoomId;
            reservation.Room = dto.Room;
            reservation.FirstName = dto.FirstName;
            reservation.LastName = dto.LastName;
            reservation.NumberOfPlayers = dto.NumberOfPlayers;
            reservation.GameDate = dto.GameDate;
            reservation.GameTime = dto.GameTime;
            reservation.TotalPrice = reservation.CalculationTotalPrice(reservation.Room.StartingPricePerPerson, reservation.Room.DiscountPerPerson, reservation.NumberOfPlayers);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var postTask = client.PostAsJsonAsync<Reservation>("ReservationApi", reservation);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server Error!");
            }
            return View(reservation);

         }
        public ActionResult GetAllReservations()
        {
            IEnumerable<Reservation> reservations = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/");
                var responseTask = client.GetAsync("ReservationApi");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Reservation>>();
                    reservations = readTask.Result;
                }
                else
                {
                    reservations = Enumerable.Empty<Reservation>();
                    ModelState.AddModelError(string.Empty, "Server Error");
                }
            }
            return View(reservations);
        }
        
        public ActionResult PaymentWithPaypal(ReservationViewModel rvm, string Cancel = null)
        {
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Reservation/PaymentWithPayPal?";
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid,rvm);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("FailureView");
                    }
                }
            }
            catch
            {
                return View("FailureView");
            }
            MakeReservation(rvm);
            //on successful payment, show success page to user.  
            return View("SuccessView");
        }
        private PayPal.Api.Payment payment;
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apiContext, paymentExecution);
        }
        private Payment CreatePayment(APIContext apiContext, string redirectUrl,ReservationViewModel rvm)
        {
            var room = UnitOfWork.Rooms.GetById(rvm.RoomId);
            Reservation reservation = new Reservation();
            reservation.NumberOfPlayers = rvm.NumberOfPlayers;
            reservation.Room = room;
            var totalPrice = reservation.CalculationTotalPrice(room.StartingPricePerPerson, room.DiscountPerPerson, reservation.NumberOfPlayers);

            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = room.Title,
                currency = "EUR",
                price = totalPrice.ToString("0.00"),
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
                subtotal = totalPrice.ToString("0.00")
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
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return this.payment.Create(apiContext);
        }

    }
}