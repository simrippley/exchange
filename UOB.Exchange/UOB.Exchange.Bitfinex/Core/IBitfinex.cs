using System.Threading.Tasks;
using UOB.Exchange.Bitfinex.Models;

namespace UOB.Exchange.Bitfinex.Core
{
    public interface IBitfinex
    {
        Task<GetSymbolsResult> GetSymbolsPairsAsync();
        Task<GetSymbolsResult> GetSymbolsAsync();
        Task<GetOrderBooksResult> GetOrderBooksAsync(GetOrderBooksRequest request);
        Task<object> CreateOrderAsync(SubmitOrderRequest request);
    }
}
