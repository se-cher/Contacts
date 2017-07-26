namespace Contacts.Models
{
    public class FriendConnection
    {
        public int Id { get; set; }

        public int ForId { get; set; }

        public int FriendId { get; set; }

        public string Info { get; set; }

        public virtual ContactModel Friend { get; set; }

        public virtual ContactModel For { get; set; }
    }
}