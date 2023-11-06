using System;
using Microsoft.Extensions.Hosting;
using DSCC.MVC._11456.Models;

namespace DSCC.MVC._11456.Services
{
	public interface IApiService
	{
        // For Blogs
        Task<IEnumerable<Blog>> GetAllBlogs();
        Task<Blog> GetBlogById(int id);
        Task UpdateBlog(int id, Blog blog);
        Task DeleteBlog(int id);

        // For University
        Task<IEnumerable<University>> GetAllUniversities();
        Task<University> GetUniversityById(int id);
        Task UpdateUniversity(int id, University university);
        Task DeleteUniversity(int id);
        Task CreateUniversity(University university);
    }
}

