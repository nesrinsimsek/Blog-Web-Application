namespace Week5CaseStudy.Models
{
    public class Hashtag
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<HashtagPostMap> Posts { get; set; }
    }
}
