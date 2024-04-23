using Newtonsoft.Json;
using QuoteUI.Common;
using QuoteUI.Model;
using System.Net.Http;
using System.Net.Http.Headers;

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

        public async Task<ApiResponse> CreateQuote(Quote quote)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync(apiHostURL + ApiEndPoint.AddQuote, quote);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        StatusCode = Common.Enums.Status.Success,
                        Message = "Quote created successfully.",
                        ReturnValue = null
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        StatusCode = Common.Enums.Status.Error,
                        Message = "Failed to create quote.",
                        ReturnValue = null
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating quote: {ex.Message}");
                return new ApiResponse
                {
                    StatusCode = Common.Enums.Status.Error,
                    Message = "An error occurred while creating quote.",
                    ReturnValue = null
                };
            }
        }

        public async Task<ApiResponse> UpdateQuote(Quote quote)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync(apiHostURL + ApiEndPoint.UpdateQuote + quote.Id, quote);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        StatusCode = Common.Enums.Status.Success,
                        Message = "Quote updated successfully.",
                        ReturnValue = null
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        StatusCode = Common.Enums.Status.Error,
                        Message = "Failed to update quote.",
                        ReturnValue = null
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating quote: {ex.Message}");
                return new ApiResponse
                {
                    StatusCode = Common.Enums.Status.Error,
                    Message = "An error occurred while updating quote.",
                    ReturnValue = null
                };
            }
        }

        public async Task<ApiResponse> DeleteQuote(int quoteId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.DeleteAsync(apiHostURL + ApiEndPoint.DeleteQuote + quoteId);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        StatusCode = Enums.Status.Success,
                        Message = "Quote deleted successfully."
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        StatusCode = Enums.Status.Error,
                        Message = "Failed to delete quote."
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting quote: {ex.Message}");
                return new ApiResponse
                {
                    StatusCode = Common.Enums.Status.Error,
                    Message = "An error occurred while deleteting quote.",
                    ReturnValue = null
                };
            }
        }

    }
}
