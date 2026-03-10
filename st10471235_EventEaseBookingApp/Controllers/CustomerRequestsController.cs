using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using st10471235_EventEaseBookingApp.Data;
using st10471235_EventEaseBookingApp.Models;

namespace st10471235_EventEaseBookingApp.Controllers
{
    public class CustomerRequestsController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CustomerRequests
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CustomerRequests.Include(c => c.Booking).Include(c => c.Venue);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CustomerRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerRequest = await _context.CustomerRequests
                .Include(c => c.Booking)
                .Include(c => c.Venue)
                .FirstOrDefaultAsync(m => m.CustomerRequestId == id);
            if (customerRequest == null)
            {
                return NotFound();
            }

            return View(customerRequest);
        }

        // GET: CustomerRequests/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location");
            return View();
        }

        // POST: CustomerRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerRequestId,CustomerName,CustomerEmail,CustomerPhone,VenueId,RequestedStart,RequestedEnd,RequestedEventName,Status,BookingId,CreatedAt")] CustomerRequest customerRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", customerRequest.BookingId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location", customerRequest.VenueId);
            return View(customerRequest);
        }

        // GET: CustomerRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerRequest = await _context.CustomerRequests.FindAsync(id);
            if (customerRequest == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", customerRequest.BookingId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location", customerRequest.VenueId);
            return View(customerRequest);
        }

        // POST: CustomerRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerRequestId,CustomerName,CustomerEmail,CustomerPhone,VenueId,RequestedStart,RequestedEnd,RequestedEventName,Status,BookingId,CreatedAt")] CustomerRequest customerRequest)
        {
            if (id != customerRequest.CustomerRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerRequestExists(customerRequest.CustomerRequestId))
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
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", customerRequest.BookingId);
            ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "Location", customerRequest.VenueId);
            return View(customerRequest);
        }

        // GET: CustomerRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerRequest = await _context.CustomerRequests
                .Include(c => c.Booking)
                .Include(c => c.Venue)
                .FirstOrDefaultAsync(m => m.CustomerRequestId == id);
            if (customerRequest == null)
            {
                return NotFound();
            }

            return View(customerRequest);
        }

        // POST: CustomerRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerRequest = await _context.CustomerRequests.FindAsync(id);
            if (customerRequest != null)
            {
                _context.CustomerRequests.Remove(customerRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerRequestExists(int id)
        {
            return _context.CustomerRequests.Any(e => e.CustomerRequestId == id);
        }
    }
}
