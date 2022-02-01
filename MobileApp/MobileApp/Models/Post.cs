namespace MobileApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Tittle { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}