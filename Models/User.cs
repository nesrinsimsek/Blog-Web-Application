using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Week5CaseStudy.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public List<Post> Posts { get; set; }

    }
}
