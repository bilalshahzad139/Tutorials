
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MVC_AngularJSPrac.Models;

namespace MVC_AngularJSPrac.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public List<PostDTO> GetAllPosts()
        {
            List<PostDTO> posts = new List<PostDTO>();
            posts.Add(new PostDTO() { PostId = 1, Title = "Testing Post 1", PicURL = "pic1.jpg" });
            posts.Add(new PostDTO() { PostId = 2, Title = "Testing Post 2", PicURL = "pic2.jpg" });
            posts.Add(new PostDTO() { PostId = 3, Title = "Testing Post 3", PicURL = "pic3.jpg" });

            return posts;
        }

        [HttpPost]
        public Boolean VerifyUser(UserDTO dto)
        {
            if (dto.UserName == "admin" && dto.Password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
