using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;

namespace AsyncInn.Controllers
{
    public class HotelController : Controller
    {
        /// <summary>
        /// Brings in interface
        /// </summary>
        private readonly IHotelManager _context;

        public HotelController(IHotelManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles both the search and show all methods
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string SearchString)
        {
         

            if (!String.IsNullOrEmpty(SearchString))
            {
                return View(await _context.SearchHotels(SearchString));
            }
            
            return View(await _context.GetHotels());
           
        }

        /// <summary>
        /// Displays details of hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            

            var hotel = await _context.GetOneHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        /// <summary>
        /// Displays update view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.UpdateOne(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Updatehotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }

        /// <summary>
        /// displays delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.DeleteOne(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        /// <summary>
        /// Deletes and instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks to see if instance exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool HotelExists(int id)
        {
            return _context.HotelExist(id);
        }
    }
}
