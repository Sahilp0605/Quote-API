using Newtonsoft.Json;
using QuoteUI.Common;
using QuoteUI.Model;

namespace QuoteUI.Service
{
    public class QuoteService : BaseServices
    {

        ApiResponse ApiResponse = new ApiResponse();

        public QuoteService(IConfiguration config, IHttpClientFactory httpClient) : base(config, httpClient) 
        {

        }


        public async Task<ApiResponse> GetQuoteById(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(apiHostURL + ApiEndPoint.GetQuoteById + id);

            if (response.IsSuccessStatusCode)
            {
                var quote = await response.Content.ReadFromJsonAsync<Quote>();
                return new ApiResponse
                {
                    StatusCode = Enums.Status.Success,
                    Message = "Quote retrieved successfully.",
                    ReturnValue = quote
                };
            }
            else
            {
                return new ApiResponse
                {
                    StatusCode = Enums.Status.Error,
                    Message = "Failed to retrieve quote.",
                    ReturnValue = null
                };
            }
        }

        public async Task<ApiResponse> GetAllQuotes()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(apiHostURL + ApiEndPoint.GetQuote);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var quote = JsonConvert.DeserializeObject<List<QuoteUI.Model.Quote>>(jsonString);

                return new ApiResponse
                {
                    StatusCode = Enums.Status.Success,
                    Message = "Quote retrieved successfully.",
                    ReturnValue = quote
                };
            }
            else
            {
                return new ApiResponse
                {
                    StatusCode = Enums.Status.Error,
                    Message = "Failed to retrieve quote.",
                    ReturnValue = null
                };
            }

        }


    }
}
