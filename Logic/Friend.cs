namespace DateMate.Models
{
    public class Friend
    {
        public int ID { get; set; }
        public virtual ApplicationUser From { get; set; }
        public virtual ApplicationUser To { get; set; }
    }
}