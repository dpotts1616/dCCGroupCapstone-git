using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Data;
using ParkingApp.Interfaces;
using ParkingApp.Models;
using ParkingApp.Services;

namespace ParkingApp.Controllers
{
    [Authorize(Roles = "Contractor")]
    public class ContractorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGeocodingService _geocodingService;

        public ContractorsController(ApplicationDbContext context, IGeocodingService geocodingService)
        {
            _context = context;
            _geocodingService = geocodingService;
        }

        // GET: Contractors
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var contractor = _context.Contractors.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (contractor == null)
            {
                return RedirectToAction(nameof(Create));
            }

            contractor = await _context.Contractors
                .Include(c => c.IdentityUser)
                .Include(c => c.ParkingSpot)
                .FirstOrDefaultAsync(m => m.Id == contractor.Id);


            return View(contractor);

            //var applicationDbContext = _context.Contractors.Include(c => c.IdentityUser).Include(e => e.ParkingSpot);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractors
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractor == null)
            {
                return NotFound();
            }

            return View(contractor);
        }

        // GET: Contractors/Create
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
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,City,State,ZipCode,IdentityUserId,SpotID")] Contractor contractor)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                contractor.IdentityUserId = userId;

                _context.Add(contractor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", contractor.IdentityUserId);
            return View(contractor);
        }

        // GET: Contractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractors.FindAsync(id);
            if (contractor == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", contractor.IdentityUserId);
            return View(contractor);
        }

        // POST: Contractors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,City,State,ZipCode,IdentityUserId,SpotID")] Contractor contractor)
        {
            if (id != contractor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractorExists(contractor.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", contractor.IdentityUserId);
            return View(contractor);
        }

        // GET: Contractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractor = await _context.Contractors
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contractor == null)
            {
                return NotFound();
            }

            return View(contractor);
        }

        // POST: Contractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractor = await _context.Contractors.FindAsync(id);
            _context.Contractors.Remove(contractor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractorExists(int id)
        {
            return _context.Contractors.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ParkingSpot(int id)
        {
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var contractor = _context.Contractors.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var contractor = await _context.Contractors.FindAsync(id);

            

            var parkingSpots = _context.ParkingSpots.Where(w => w.OwnerId == contractor.Id);

            if (parkingSpots.Any() == false)
            {
                return RedirectToAction(nameof(CreateParkingSpot));
            }

            return View(parkingSpots);
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            //return View();
        }


        //Get for Create Parking Spot
        public IActionResult CreateParkingSpot()
        {
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateParkingSpot([Bind("Id,Address, City, State, ZipCode, HourlyRate, CoveredSpot, Notes")]ParkingSpot parkingSpot)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var contractor = _context.Contractors.Where(c => c.IdentityUserId == userId).SingleOrDefault();

                parkingSpot = await _geocodingService.AttachLatAndLong(parkingSpot);


                 
                //contractor.SpotID = parkingSpot.ID;
                parkingSpot.OwnerId = contractor.Id;
                _context.ParkingSpots.Add(parkingSpot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", contractor.IdentityUserId);
            return View(parkingSpot);
        }


        public IActionResult ViewReservations()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var contractor = _context.Contractors.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var spots = _context.ParkingSpots.Where(c => c.OwnerId == contractor.Id);
            var reservations = new List<Reservation>();
            foreach(var item in spots)
            {
                reservations.AddRange(_context.Reservations.Where(c => c.OwnedSpotID == item.ID).ToList());
            }
            return View(reservations);
        }

        // GET: Cancel Reservtion
        public async Task<IActionResult> CancelReservation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);

            return View(reservation);
        }

        //Cancel Reservation

        [HttpPost, ActionName("CancelReservation")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            var customer = _context.Customers.Find(reservation.BookedCustomerID);
            var spot = _context.ParkingSpots.Find(reservation.OwnedSpotID);

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            string subject = "Reservation Cancelled";
            string body = $"{customer.FirstName}, your parking spot reservation at {spot.Address} on {reservation.ReservationDate.Date} " +
                $"from {reservation.StartTime.TimeOfDay} to {reservation.EndTime.TimeOfDay} has been cancelled by the owner.";
            SendMail.SendEmail(customer.EmailAddress, subject, body);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewCustomerDetails(int id)
        {
            var customer = _context.Customers.Find(id);

            return View(customer);
        }


        [HttpPost]
        public ActionResult PostRating(int rating, int mid)
        {
            StarRating rt = new StarRating();
            rt.Rate = rating;
            rt.CustomerId = mid;

            _context.Ratings.Add(rt);
            _context.SaveChanges();

            return Ok();
        }
    }
}
 