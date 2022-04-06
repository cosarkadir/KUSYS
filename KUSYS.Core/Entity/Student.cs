namespace KUSYS.Core.Entity
{
    public class Student: EntityBase<int>
    {
        public string CourseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual Course Course { get; set; }
    }
}