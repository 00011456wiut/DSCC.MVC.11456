using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using DSCC.MVC._11456.Models;
using DSCC.MVC._11456.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSCC.MVC._11456.Controllers
{
    public class BlogController : Controller
    {
        private readonly IApiService _apiService;

        public BlogController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _apiService.GetAllBlogs();
            return View(blogs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _apiService.GetBlogById(id);
            return View(blog);
        }

        // Action method to display the edit form for blog
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _apiService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // Action method to handle the submission of the edit form for blog
        [HttpPost]
        public async Task<IActionResult> Edit(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            // Calling API to update the blog
            await _apiService.UpdateBlog(blog.Id, blog);

            // Redirecting
            return RedirectToAction(nameof(Index));
        }

        // Action method to handle deletion of blog
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _apiService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }

            // Calling API to delete the blog
            await _apiService.DeleteBlog(id);

            // Redirecting
            return RedirectToAction(nameof(Index));
        }
    }
}

