namespace QuoteUI.Service
{
    public class BaseServices
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly string apiHostURL;

        public BaseServices(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            apiHostURL = configuration["URL:APIHostURL"].ToString();
            _httpClientFactory = httpClientFactory;
        }

    }
}
