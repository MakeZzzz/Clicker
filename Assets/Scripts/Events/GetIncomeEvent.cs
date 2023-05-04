using EventBase = SimpleEventBus.Events.EventBase;

namespace Events
{
    public class GetIncomeEvent : EventBase
    {
        public float Profit { get; }

        public GetIncomeEvent(float profit)
        {
            Profit = profit;
        }
    }
}
