using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class HotelRoomsController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a list of all hotel rooms and sends to view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel);
            return View(await asyncInnDbContext.ToListAsync());
        }

        /// <summary>
        /// Shows details of one hotel room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        /// <summary>
        /// Creates a new instance of a hotel room
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            return View(hotelRoom);
        }

        /// <summary>
        /// Edit the details of the hotel room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (id != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.HotelID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRoom.HotelID);
            return View(hotelRoom);
        }

        /// <summary>
        /// will show an are you sure prompt when you hit delete option
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(decimal? roomID, int? hotelID)
        {
            if (roomID == null || hotelID == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.Include(i => i.Hotel)
                .Include(j => j.Room)
                .FirstOrDefaultAsync(hr => hr.RoomID == roomID && hr.HotelID == hotelID);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        /// <summary>
        /// Deletes a selected hotel room
        /// </summary>
        /// <param name="roomID"></param>
        /// <param name="hotelID"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal roomID, int hotelID)
        {
            var hotelRoom = await _context.HotelRooms.Include(i => i.Hotel).Include(j => j.Room).FirstOrDefaultAsync(hr => hr.RoomID == roomID && hr.HotelID == hotelID);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// Checks to see if the hotel room exitis
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true or false</returns>
        private bool HotelRoomExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
