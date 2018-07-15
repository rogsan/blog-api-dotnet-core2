using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog_api_dotnet_core2.Models
{
    public class Post : BaseModel
    {
        [Required]
        public String Url { get; set; }
        
        [Required]
        public String ImageUrl { get; set; }

        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }

        [Required]
        public String Tags { get; set; }

        [Required]
        public String Title { get; set; }
        
        [Required]
        public String Body { get; set; }
    }
}