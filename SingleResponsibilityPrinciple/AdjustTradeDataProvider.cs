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

        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> trades = _tradeDataProvider.GetTradeData();

            // Adjust Trades from GBP to EUR in all the text lines.
            trades = trades.Select(trade => trade.Replace("GBP", "EUR"));

            return trades;
        }
    }
}