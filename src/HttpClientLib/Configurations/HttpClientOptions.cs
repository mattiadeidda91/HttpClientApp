namespace HttpClientLib.Configurations
{
    public class HttpClientOptions
    {
        public string? Name { get; init; }
        public string? BaseAddress { get; init; }
        public int Timeout { get; init; }
        public bool? RetryPolicyEnable { get; init; }
        public int PollyLifeTime { get; init; }
        public int Retry { get; init; }
        public int RetryDelay { get; init; }
    }
}
