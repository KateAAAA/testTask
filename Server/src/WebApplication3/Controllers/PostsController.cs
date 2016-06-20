using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Diagnostics;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
 
        List<Post> posts = new List<Post>() { new Post { Key = 0, Name = "Name1", Text = "Text1" },
                                              new Post { Key = 1, Name = "Name1", Text = "Text1" }};
        

        // GET api/posts
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return posts;
        }

        // GET api/values/{id}
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            // добавить обработку исключения
            return posts[id];
        }
         
        // POST api/values - создать
        [HttpPost]
        public void Post([FromBody]Post value)
        {
            posts.Add(value);
        }

        // PUT api/values/5 - обновить
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Post value)
        {
            posts[id] = value;
        }

        // DELETE api/values/5 - удалить по id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            posts.RemoveAll(x => x.Key == id);
        }
           
    }
}
