namespace EKO.RaspberryPi.Shared.ServerEntities;

public record ServerDetails
{
    public required Version Version { get; init; }
    public required string OS { get; init; }
    public required string Framework { get; init; }
    public required DateTime Timestamp { get; init;  }
    public required TimeSpan Uptime { get; init; }
}
