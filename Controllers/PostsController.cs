using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blog_api_dotnet_core2.Models;
using blog_api_dotnet_core2.Interfaces;

namespace blog_api_dotnet_core2.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : BaseController<Post>
    {
        public PostsController(IRepository<Post> postRepository) : base(postRepository) { }

        public override String ApiUrl
        {
            get
            { 
                return "posts";
            }
        }
    }
}
