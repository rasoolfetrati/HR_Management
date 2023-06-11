using HR_Management.MVC.Contracts;
using System.Net.Http.Headers;

namespace HR_Management.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions(ApiException exception)
        {
            if (exception.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation errors have ocurred.", ValidationErrors = exception.Message, IsSuccess = false };
            }
            else if (exception.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "Not Found...", IsSuccess = false };
            }
            else
            {
                return new Response<Guid>() { Message = "something went wrong!", IsSuccess = false };
            }
        }
        protected void AddBearerToken()
        {
            if (_localStorage.Exists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
            }
        }
    }
}
