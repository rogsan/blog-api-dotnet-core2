using System;
using System.Collections.Generic;

namespace blog_api_dotnet_core2.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public String Url { get; set; }
        public string ImageUrl { get; set;}

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public String Title { get; set; }
        public String Body { get; set; }

        public DateTime CreatedAt { get; set; }
        public String CreatedBy { get; set; }
    }
}