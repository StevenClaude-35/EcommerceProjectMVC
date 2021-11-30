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
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;

        public ProducersController(IProducerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAll();
            return View(allProducers);
        }

        //GET:Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }

        //Get: Producers/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl, FullName, Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View (producer);
            }
            await _service.Add(producer);

            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null) View("NotFound");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureUrl, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await _service.Update(id, producer);

                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //Get: Producers/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null) View("NotFound");

            return View(producerDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetById(id);
            if (producerDetails == null) View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
