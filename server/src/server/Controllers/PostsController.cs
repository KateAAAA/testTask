using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using System.Diagnostics;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private static List<Post> posts = new List<Post>
        {
            new Post { Id = 0, Name = "Tomato Soup", Text = "Groceries" },
            new Post { Id = 1, Name = "Yo-yo", Text = "Toys" },
            new Post { Id = 2, Name = "Hammer", Text = "Hardware" }
        };

        // GET api/posts - получаем все посты
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return posts;
        }
        // GET api/values/{id} - пост по id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var _posts = posts.FirstOrDefault(p => p.Id == id);

            if (_posts == null)
            {
                return new OkObjectResult("error 404");
            }

            return new OkObjectResult(_posts);
        }
        

        /*public Post Get(int id)
        {
            return posts[id];
        }*/

        // POST api/posts - добавление поста
        [HttpPost]
        public void POST([FromBody]Post value)
        {
            posts.Add(value);
        }

        // PUT api/posts/5 - изменение поста
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Post value)
        {
            var _posts = posts.FirstOrDefault(p => p.Id == id);

            if (_posts == null)
            {
                POST(value); // если такого элментенет, то добавлем его
            }// иначе меняем
            posts[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _posts = posts.FirstOrDefault(p => p.Id == id);

            if (_posts != null)
            {
                posts.Remove(posts[id]);
            }            
        }
    }
}
