using OnlineShopingGatewayAPI.Models;
using System.Threading.Tasks;

namespace OnlineShopingGatewayAPI.Utils
{
    public interface IHttpClientHub
    {
        Task<W> PostAsync<W>(JsonObject model, string fullUrl, string extentionGrantToken = "");
        Task<string> PostAsync(string fullUrl, string extentionGrantToken = "");
    }
}
