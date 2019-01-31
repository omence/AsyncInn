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

namespace AsyncInn.Controllers
{
    public class AmenitiesController : Controller
    {
        /// <summary>
        /// brings in interface
        /// </summary>
        private readonly IAmenitiesManager _context;

        public AmenitiesController(IAmenitiesManager context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays all amenities and search results
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns>Search results and all instances to view</returns>
        public async Task<IActionResult> Index(string SearchString)
        {


            if (!String.IsNullOrEmpty(SearchString))
            {
                return View(await _context.SearchAmenities(SearchString));
            }
            return View(await _context.GetAmeneties());

        }

        /// <summary>
        /// Displays the details of amenity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details to view</returns>
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _context.GetOneAmenety(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Displays the create view
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Amenities amenities)
        {
            if (ModelState.IsValid)
            {
                await _context.CreateAmeneties(amenities);
                return RedirectToAction(nameof(Index));
            }
            return View(amenities);
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _context.UpdateOne(id);
            if (amenities == null)
            {
                return NotFound();
            }
            return View(amenities);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenities amenities)
        {
            if (id != amenities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAmeneties(amenities);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenitiesExists(amenities.ID))
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
            return View(amenities);
        }

        /// <summary>
        /// Displays the delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amenities = await _context.DeleteOne(id);
            if (amenities == null)
            {
                return NotFound();
            }

            return View(amenities);
        }

        /// <summary>
        /// Deletes an instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteAmenities(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks to see if instance exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AmenitiesExists(int id)
        {
            return _context.AmenitiesExist(id);
        }
    }
}
