namespace HttpClientLib.Configurations
{
    public class HttpClientOptions
    {
        public string? Name { get; init; }
        public string? BaseAddress { get; init; }
        public int Timeout { get; init; }
    }
}
