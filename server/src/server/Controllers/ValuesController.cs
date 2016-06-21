using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        Post[] posts = new Post[]
        {
            new Post { Id = 1, Name = "Tomato Soup", Text = "Groceries" },
            new Post { Id = 2, Name = "Yo-yo", Text = "Toys" },
            new Post { Id = 3, Name = "Hammer", Text = "Hardware" }
        };

        // GET api/values
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return posts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return posts[id];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
