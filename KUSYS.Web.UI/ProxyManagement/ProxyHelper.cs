using KUSYS.Web.UI.Models.ResponseModels;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace KUSYS.Web.UI.ProxyManagement
{
    public class ProxyHelper : IProxyHelper
    {
        private readonly IConfiguration _config;
        public ProxyHelper(IConfiguration config)
        {
            _config = config;
        }

        public ServiceResponse<TResponseModel> ExecuteCall<TResponseModel, TRequestModel>(string url, TRequestModel requestModel, string method)
        {
            string jsonInput = string.Empty;
            byte[]? data = null;
            if (requestModel != null)
            {
                jsonInput = JsonConvert.SerializeObject(requestModel);
                data = Encoding.ASCII.GetBytes(jsonInput);
            }

            ServiceResponse<TResponseModel> response = new ServiceResponse<TResponseModel>();
            try
            {
                HttpWebRequest httpWebRequest = null;
                httpWebRequest = GetWebRequest(url, method, data);

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<ServiceResponse<TResponseModel>>(result);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var streamReader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        private HttpWebRequest GetWebRequest(string serviceUrl, string requestMethod, byte[] data)
        {
            var apiUrl = _config.GetValue<string>("ApiUrl");
            string url = Path.Combine(apiUrl, serviceUrl);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = requestMethod;
            if (data != null)
            {
                httpWebRequest.ContentLength = data.Length;
                using (var stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return httpWebRequest;
        }
    }
}
