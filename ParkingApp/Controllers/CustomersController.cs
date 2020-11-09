using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.Models;
using ParkingApp.Services;

namespace ParkingApp.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (customer == null)
            {
                return RedirectToAction(nameof(Create));
            }

                customer = await _context.Customers
               //.Include(c => c.Car)
               .Include(c => c.IdentityUser)
               .FirstOrDefaultAsync(m => m.Id == customer.Id);

            return View(customer);

            //var applicationDbContext = _context.Customers.Include(c => c.Car).Include(c => c.IdentityUser);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                //.Include(c => c.Car)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Contractors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,EmailAddress,PhoneNumber,LicenseIDNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;

                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }
      
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "Id", "Id", customer.CarID);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,EmailAddress,PhoneNumber,LicenseIDNumber,IdentityUserId,CarID,PaymentID")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "Id", "Id", customer.CarID);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Car)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        // GET: CustomersController/BookASpot/
        public ActionResult BookASpot(int? id)
        {
            var spot = _context.ParkingSpots.Find(id);
            var reservations = _context.Reservations.Where(c => c.OwnedSpotID == spot.ID);

            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();

            ViewData["OwnedSpotID"] = id;
            ViewData["ReservationDate"] = new DateTime();
            ViewData["StartTime"] = new TimeSpan();
            ViewData["EndTime"] = new TimeSpan();
            return View(reservations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CustomersController/BookASpot/
        public ActionResult BookASpot([Bind("ReservationDate,StartTime,EndTime, OwnedSpotID")] Reservation reservation, int ID)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            //var parkingSpotToReserve = _context.ParkingSpots.Where(c => c.ID == ID).SingleOrDefault();

            if(reservation.EndTime.TimeOfDay < reservation.StartTime.TimeOfDay)
            {
                return RedirectToAction(nameof(BookASpot));
            }
            
            var reservations = _context.Reservations.Where(c => c.OwnedSpotID == reservation.OwnedSpotID)
                .Where(a => a.ReservationDate == reservation.ReservationDate);
           foreach(var item in reservations)
            {
                if ((item.StartTime.TimeOfDay < reservation.StartTime.TimeOfDay && reservation.StartTime.TimeOfDay < item.EndTime.TimeOfDay)
                    || (item.StartTime.TimeOfDay < reservation.EndTime.TimeOfDay && reservation.EndTime.TimeOfDay < item.EndTime.TimeOfDay)
                    || (item.StartTime.TimeOfDay > reservation.StartTime.TimeOfDay && item.EndTime.TimeOfDay < reservation.EndTime.TimeOfDay))
                {
                    return RedirectToAction(nameof(BookASpot));
                }
            }
            var spot = _context.ParkingSpots.Find(reservation.OwnedSpotID);

            reservation.Customer = customer;
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            string subject = "Reservation Confirmed";
            string body = $"{customer.FirstName}, you have reserved a parking spot at {spot.Address} on {reservation.ReservationDate.Date} " +
                $"from {reservation.StartTime.TimeOfDay} to {reservation.EndTime.TimeOfDay}";
            SendMail.SendEmail(customer.EmailAddress, subject, body);
            return RedirectToAction(nameof(Index));
        }


        public ActionResult ReserveTheSpot(Reservation reservation, int ID)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var parkingSpotToReserve = _context.ParkingSpots.Where(c => c.ID == ID).SingleOrDefault();

            reservation.Id = customer.Id;
            parkingSpotToReserve.IsBooked = true;
            _context.ParkingSpots.Update(parkingSpotToReserve);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        // POST: Customers/YourReservations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> YourReservations(int? id)
        {
            var customer = await _context.Customers.FindAsync(id);

            var reservations = _context.Reservations.Where(w => w.Id == customer.Id);

            if (reservations.Any() == false)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(reservations);
        }

        // GET: CustomersController/AddVehicle/
        public ActionResult AddVehicle(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();


            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View();   
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: CustomersController/AddVehicle/
        public ActionResult AddVehicle([Bind("CarMake,CarModel,CarYear")] Car car)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            car.OwnerId = customer.Id; 
                _context.Cars.Add(car);
                _context.SaveChanges();
              
                return RedirectToAction(nameof(Index));
        }


        // GET: CustomersController/ViewVehicles/
        public ActionResult ViewVehicles(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if(customer == null)
            {
                return NotFound();
            }
            var vehicles = _context.Cars.Where(c => c.OwnerId == customer.Id);
            
            if(vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);

        }


        public ActionResult AllSpots()
        {

            var parkingSpots = _context.ParkingSpots;

            if (parkingSpots == null)
            {
                return NotFound();
            }

            return View(parkingSpots);
        }



        //public ActionResult PayBill()
        //{
        //    var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
        //    ViewBag.StripePublishKey = stripePublishKey;
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Charge(string stripeEmail, string stripeToken)
        //{
        //    var customers = new Stripe.CustomerCreateOptions();
        //    var charges = new Stripe.CustomerCreateOptions();

        //    var customer = customers.Create(new CustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        SourceToken = stripeToken
        //    });

        //    var charge = charges.Create(new CustomerCreateOptions
        //    {
        //        Amount = 500,//charge in cents
        //        Description = "Sample Charge",
        //        Currency = "usd",
        //        CustomerId = customer.Id
        //    });

        //    // further application specific code goes here

        //    return View();
        //}


    }
}
