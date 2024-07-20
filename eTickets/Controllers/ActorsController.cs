using eTickets.Data;
using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.UserRoles.Admin)]

    public class ActorsController : Controller
    {
       private readonly IActorsServices _actorsServices;

        public ActorsController(IActorsServices actorsServices)
        {
            _actorsServices = actorsServices;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await _actorsServices.GetAllAsync();
            return View(actors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl,Bio")]Actor actor )
        {

          if (!ModelState.IsValid)
            {
                return View(actor); 
            }
         await _actorsServices.AddAsync(actor);
            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Details (int id )
        {
            var actor =await  _actorsServices.GetByIdAsync(id);
            if (actor == null) 
            {
                return NotFound();   
            }
            return View(actor); 
        }
        public async Task<IActionResult > Edit(int id)
        {
            var actor = await _actorsServices.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [ Bind("id,FullName, ProfilePictureUrl,Bio")] Actor actor)
        {

            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsServices.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorsServices.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }
        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _actorsServices.GetByIdAsync(id);
            if (actor == null)
            
                return NotFound();
            
            await _actorsServices.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
