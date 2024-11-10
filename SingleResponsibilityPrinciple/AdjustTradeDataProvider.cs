using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly ITradeDataProvider _tradeDataProvider;

        public AdjustTradeDataProvider(ITradeDataProvider tradeDataProvider)
        {
            _tradeDataProvider = tradeDataProvider;
        }

        public async Task<IEnumerable<string>> GetTradeData()
        {
            IEnumerable<string> trades = await _tradeDataProvider.GetTradeData();

            // Adjust Trades from GBP to EUR in all the text lines.
            trades = trades.Select(trade => trade.Replace("GBP", "EUR"));

            return trades;
        }
    }
}