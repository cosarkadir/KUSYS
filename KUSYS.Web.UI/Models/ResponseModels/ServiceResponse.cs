namespace KUSYS.Web.UI.Models.ResponseModels
{
    public class ServiceResponse<TResult>
    {
        public bool IsSuccessfull { get; set; }
        public TResult Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
