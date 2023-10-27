using EKO.RaspberryPi.Api.Entities;

namespace EKO.RaspberryPi.Api.Models;

public record ServerDetailsViewModel
{
    public required Version Version { get; init; }
    public required string OS { get; init; }
    public required string Framework { get; init; }
    public required DateTime Timestamp { get; init;  }
    public required TimeSpan Uptime { get; init; }

    public static ServerDetailsViewModel FromServerDetails(ServerDetails serverDetails)
    {
        return new ServerDetailsViewModel
        {
            Version = serverDetails.Version,
            OS = serverDetails.OS,
            Framework = serverDetails.Framework,
            Timestamp = serverDetails.Timestamp,
            Uptime = serverDetails.Uptime
        };
    }
}
