using System.Threading.Tasks;

namespace OnlineShoping.Utils
{
    public interface IHttpClientHub
    {
        Task<byte[]> PostForAttachmentAsync<T>(T model, string fullUrl, string extentionGrantToken = "") where T : class;
        Task<W> PostAsync<T, W>(T model, string fullUrl, string extentionGrantToken = "") where T : class;
        Task<W> PostAsync<W>(string fullUrl, string extentionGrantToken = "") where W : class, new();
    }
}
