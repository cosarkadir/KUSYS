namespace KUSYS.Core.Entity
{
    public class Role : EntityBase<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}