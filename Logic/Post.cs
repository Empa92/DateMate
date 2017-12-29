namespace DateMate.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public virtual ApplicationUser From { get; set; }
        public virtual ApplicationUser To { get; set; }
    }
}