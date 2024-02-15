using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week5CaseStudy.Models
{
    public class HashtagPostMap
    {
        [ForeignKey("Hashtag")]
        [Key]
        public int Hashtag_Id { get; set; }
        public Hashtag Hashtag { get; set; }

        [ForeignKey("Post")]
        [Key]
        public int Post_Id { get; set; } 
        public Post Post { get; set; }
    }
}
