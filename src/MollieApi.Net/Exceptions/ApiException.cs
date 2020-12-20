using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Net.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }

        public static async Task<ApiException> CreateFromResponse(HttpResponseMessage response)
        {
            MollieError obj = await ParseResponseBody(response);
            return new ApiException($"Error executing API call ({obj.Status}: {obj.Title}): {obj.Detail}");
        }

        public static async Task<MollieError> ParseResponseBody(HttpResponseMessage response)
        {
            string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            MollieError obj;
            try
            {
                obj = JsonHelper.Deserialize<MollieError>(body);
            }
            catch
            {
                throw new ApiException($"Unable to decode Mollie response: '{body}'.");
            }

            return obj;
        }
    }
}
