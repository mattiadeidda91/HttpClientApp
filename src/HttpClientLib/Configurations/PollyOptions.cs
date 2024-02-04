namespace HttpClientLib.Configurations
{
    public class PollyOptions
    {
        public bool? RetryPolicyEnable { get; init; }
        public Configuration? Configuration { get; init; }
    }

    public class Configuration
    {
        public int HandlerLifeTime { get; init; }
        public int MaxRetry { get; init; }
        public int RetryDelay { get; init; }
        public bool? isOnlyGetMethod { get; init; }
    }
}
