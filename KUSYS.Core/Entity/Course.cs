namespace KUSYS.Core.Entity
{
    public class Course: EntityBase<string>
    {
        public string CourseName { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}