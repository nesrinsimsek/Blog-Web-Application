using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week5CaseStudy.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Content")]
        public string Content { get; set; }
        public string State {  get; set; }
        public DateTime CreatedDate { get; set;}

        [ForeignKey("User")]
        public string User_Id { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; }

        public List<HashtagPostMap> Hashtags { get; set;}
    }
}
