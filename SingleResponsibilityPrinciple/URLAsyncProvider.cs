using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class URLAsyncProvider : ITradeDataProvider
    {
        ITradeDataProvider origProvider;

        public URLAsyncProvider(ITradeDataProvider origProvider)
        {
            this.origProvider = origProvider;
        }

        public IEnumerable<string> GetTradeData()
        {
            Task<IEnumerable<string>> task = Task.Run(() => GetDataAsync());
            task.Wait();


            return task.Result;
        }

        private Task<IEnumerable<string>> GetDataAsync() {

            return Task.Run(() => origProvider.GetTradeData());
        }

    }
}