using SimpleEventBus.Events;
using Systems;

namespace Events
{
    public class GetProfitEvent : EventBase
    {
        public TotalBalanceController GetTotalBalanceController { get; }
        public ProfitSystem ProfitSystem { get; }

        public GetProfitEvent(TotalBalanceController totalBalanceController,ProfitSystem profitSystem)
        {
            GetTotalBalanceController = totalBalanceController;
            ProfitSystem = profitSystem;
        }
        public TotalBalanceController GetBalance()
        {
            return GetTotalBalanceController;
        }

        public ProfitSystem GetProfit()
        {
            return ProfitSystem;
        }

    }
}
