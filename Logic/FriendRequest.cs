namespace DateMate.Models
{
    public class FriendRequest
    {
        public int ID { get; set; }
        public virtual ApplicationUser From { get; set; }
        public virtual ApplicationUser To { get; set; }
        public bool Accept { get; set; }
    }
}