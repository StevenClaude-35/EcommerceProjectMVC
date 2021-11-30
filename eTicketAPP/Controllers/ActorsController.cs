using eTicketAPP.Controllers.Data;
using eTicketAPP.Data.Services;
using eTicketAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketAPP.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actor/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
            {
                return View("Notfound");
            }
            return View(actorDetails);
        }

        public async Task <IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
            {
                return View("Notfound");
            }
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.Update(id,actor);
            return RedirectToAction(nameof(Index));
        }

        //Get:Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
            {
                return View("Notfound");
            }
            return View(actorDetails);
        }

       
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetById(id);
            if (actorDetails == null)
            {
                return View("Notfound");
            }
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
