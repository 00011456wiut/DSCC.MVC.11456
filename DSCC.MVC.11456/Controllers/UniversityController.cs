using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSCC.MVC._11456.Models;
using DSCC.MVC._11456.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSCC.MVC._11456.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IApiService _apiService;

        public UniversityController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var universities = await _apiService.GetAllUniversities();
            return View(universities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var university = await _apiService.GetUniversityById(id);
            return View(university);
        }

        // Action method to display the edit form for uni
        public async Task<IActionResult> Edit(int id)
        {
            var university = await _apiService.GetUniversityById(id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // Action method to handle the submission of the edit form for uni
        [HttpPut]
        public async Task<IActionResult> Edit(University university)
        {
            if (!ModelState.IsValid)
            {
                return View(university);
            }

            // Calling API to update the uni
            await _apiService.UpdateUniversity(university.Id, university);

            // Redirecting
            return RedirectToAction(nameof(Index));
        }

        // Action method to handle deletion of uni
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var university = await _apiService.GetUniversityById(id);
            if (university == null)
            {
                return NotFound();
            }

            // Calling API to delete the university
            await _apiService.DeleteUniversity(id);

            // Redirecting
            return RedirectToAction(nameof(Index));
        }

        // Create Uni Page View
        public ActionResult Create()
        {
            return View();
        }

        // Action method to create new uni
        [HttpPost]
        public async Task<IActionResult> Create(University university)
        {
            await _apiService.CreateUniversity(university);

            // Redirecting
            return RedirectToAction(nameof(Index));
        }
    }
}

