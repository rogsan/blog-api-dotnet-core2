using System;
using System.ComponentModel.DataAnnotations;

namespace blog_api_dotnet_core2.Models
{
    public class Category : BaseModel
    {
        [Required]
        public String Name { get; set; }

        public Guid? ParentId { get; set; }
    }
}