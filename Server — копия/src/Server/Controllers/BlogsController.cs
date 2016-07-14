using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private ModelsContext _dbContext;
        public BlogsController(ModelsContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/values
        [HttpGet]
        public List<Blog> Get()
        {
            return _dbContext.Blogs.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _blogs = _dbContext.Blogs.FirstOrDefault(p => p.BlogId == id);

            if (_blogs == null)
            {
                return new OkObjectResult("error 404");
            }

            return new OkObjectResult(_blogs);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Blog value)
        {
            _dbContext.Blogs.Add(value);
            _dbContext.SaveChanges(); // 
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Blog value)
        {
            var _blogs = _dbContext.Blogs.FirstOrDefault(p => p.BlogId == id);

            if (_blogs != null) // если пост с таким id есть, то меняем
            {
                _dbContext.Blogs.First(p => p.BlogId == id).Url = value.Url;
                _dbContext.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _blogs = _dbContext.Blogs.FirstOrDefault(p => p.BlogId == id);
            if (_blogs != null) // если пост с таким id есть, то удаляем
            {
                _dbContext.Blogs.Remove(_blogs);
                _dbContext.SaveChanges();
            }
        }
    }
}
