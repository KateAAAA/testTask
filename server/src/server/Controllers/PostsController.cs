using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

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

        // GET api/posts
        [HttpGet]
        public List<Post> Get()
        {
            return _dbContext.Posts.ToList();
        }

        // GET api/posts/5
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

        // POST api/posts
        [HttpPost]
        public void Post([FromBody]Post value)
        {
            _dbContext.Posts.Add(value); 
            _dbContext.SaveChanges(); // успешно, если value без PostId
        }

        // PUT api/values/5
        [HttpPut("{id}")] 
        public IActionResult Put(int id, [FromBody]Post value) // edit
        {
            var _posts = _dbContext.Posts.FirstOrDefault(p => p.PostId == id);
            if (_posts == null)
            {
                return new OkObjectResult("error 404");
                //Post(value); // если такого элментенет, то добавлем его
            }// иначе меняем*/
            else
            {
               
                return new OkObjectResult(_posts);
            }
            //!!!
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            /*Post postdel= new Post() { PostId = id };
            _dbContext.Posts.Attach(postdel);
            _dbContext.Posts.
                .DeleteObject(postdel);
            _dbContext.Posts.SaveChanges();*/
        }
    }
}
