using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Microsoft.AspNetCore.Cors;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private ModelsContext _dbContext;
        public PostsController(ModelsContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/posts - получить список всех постов
        [HttpGet]
        public List<Post> Get()
        {
            return _dbContext.Posts.ToList();
        }

        // GET api/posts/5 - получить пост номер N
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _posts = _dbContext.Posts.FirstOrDefault(p => p.PostId == id);

            if (_posts == null)
            {
                return new OkObjectResult("error 404");
            }

            return new OkObjectResult(_posts);
        }

        // POST api/posts - добавить новый пост
        [HttpPost]
        public void Post([FromBody]Post value)
        {
            _dbContext.Posts.Add(value); 
            _dbContext.SaveChanges(); // успешно, если value без PostId
        }

        // PUT api/values/5 - изменить пост с номером N , если с таким номером нет, то добавит новый
        [HttpPut("{id}")] 
        public void Put(int id, [FromBody]Post value) 
        {
            var _posts = _dbContext.Posts.FirstOrDefault(p => p.PostId == id);
           
            if (_posts != null) // если пост с таким id есть, то меняем
            {
                _dbContext.Posts.First(p => p.PostId == id).Name = value.Name;
                _dbContext.Posts.First(p => p.PostId == id).Text = value.Text;
                _dbContext.Posts.First(p => p.PostId == id).Author = value.Author;
                _dbContext.Posts.First(p => p.PostId == id).BlogId = value.BlogId;
                _dbContext.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _posts = _dbContext.Posts.FirstOrDefault(p => p.PostId == id);
            if (_posts != null) // если пост с таким id есть, то удаляем
            {
                _dbContext.Posts.Remove(_posts);
                _dbContext.SaveChanges();
            }
        }
    }
}
