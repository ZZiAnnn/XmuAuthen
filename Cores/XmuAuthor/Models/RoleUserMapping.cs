namespace XmuAuthor.Models
{
    public class RoleUserMapping
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid UserID { get; set; }
        public RoleUserMapping(Guid roleID, Guid userID)
        {
            this.ID = Guid.NewGuid();
            this.RoleID = roleID;
            this.UserID = userID;
        }
    }
}