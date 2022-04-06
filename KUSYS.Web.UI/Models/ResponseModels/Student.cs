namespace KUSYS.Web.UI.Models.ResponseModels
{
    public class Student
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}