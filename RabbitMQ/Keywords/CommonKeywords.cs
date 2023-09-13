namespace RabbitMQ.Keywords;

public static class CommonKeywords
{
    public static class ExchangeTypes
    {
        public const string Direct = "direct";
    }

    public static class ExchangeNames
    {
        public const string BookExchange = "BookExchange";
    }

    public static class QueueNames
    {
        public const string NewBookNotifier = "NewBookNotifier";
    }
}
