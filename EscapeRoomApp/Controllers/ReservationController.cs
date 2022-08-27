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
        public ActionResult MakeReservation(ReservationViewModel rvm)
        {

            var reservation = ReservationMapping(rvm);
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
        
        public ActionResult PaymentWithPaypal(int roomId,string firstName,string lastName,int numberOfPlayers,
            DateTime gameDate,DateTime gameTime, string Cancel = null)
        {
            
            //getting the apiContext  
            APIContext apiContext = PaypalConfiguration.GetAPIContext();
            try
            {
                
                

                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Reservation/PaymentWithPayPal?";

                    var guid = Convert.ToString((new Random()).Next(100000));
                    ReservationViewModel vm = new ReservationViewModel()
                    {
                        RoomId = roomId,
                        FirstName = firstName,
                        LastName = lastName,
                        NumberOfPlayers = numberOfPlayers,
                        GameDate = gameDate,
                        GameTime = gameTime
                    };
                    var reservation = ReservationMapping(vm);

                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid, reservation);
                    

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
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                { 
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executedPayment.state.ToLower() == "approved")
                    {
                        
                       
                    }
                    else
                    {
                        return View("FailureView");
                    }
                   
                }
            }
            catch
            {
                return View("FailureView");
            }
           
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
        private Payment CreatePayment(APIContext apiContext, string redirectUrl,Reservation reservation)
        {
            var room = UnitOfWork.Rooms.GetById(reservation.RoomId);

            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = room.Title,
                currency = "EUR",
                price = reservation.CalculationTotalPrice(room.StartingPricePerPerson,room.DiscountPerPerson,reservation.NumberOfPlayers).ToString("0.00"),
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
                subtotal = reservation.CalculationTotalPrice(room.StartingPricePerPerson, room.DiscountPerPerson, reservation.NumberOfPlayers).ToString("0.00")
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
        public Reservation ReservationMapping(ReservationViewModel rvm)
        {
            Reservation reservation = new Reservation();
            rvm.Room = UnitOfWork.Rooms.GetById(rvm.RoomId);
            reservation.RoomId = rvm.RoomId;
            reservation.FirstName = rvm.FirstName;
            reservation.LastName = rvm.LastName;
            reservation.NumberOfPlayers = rvm.NumberOfPlayers;
            reservation.GameDate = rvm.GameDate;
            reservation.GameTime = rvm.GameTime;
            reservation.TotalPrice = reservation.CalculationTotalPrice(rvm.Room.StartingPricePerPerson, rvm.Room.DiscountPerPerson, rvm.NumberOfPlayers);

            return reservation;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}