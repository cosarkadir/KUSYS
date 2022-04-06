using KUSYS.Web.UI.Models.ResponseModels;

namespace KUSYS.Web.UI.ProxyManagement
{
    public interface IProxyHelper
    {
        ServiceResponse<TResponseModel> ExecuteCall<TResponseModel, TRequestModel>(string url, TRequestModel requestModel, string method = RequestMethod.GET);
    }
}