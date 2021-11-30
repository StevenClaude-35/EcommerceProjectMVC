using eTicketAPP.Controllers.Data;
using eTicketAPP.Data.Services;
using eTicketAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketAPP.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allcinemas = await _service.GetAll();
            return View(allcinemas);
        }

        //Get:Cinemas/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("Logo","Name","Description")]Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _service.Add(cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET:Cinemas/Details

        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails =await _service.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //GET:Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo", "Name", "Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _service.Update(id,cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET:Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }


        [HttpPost,ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetById(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
