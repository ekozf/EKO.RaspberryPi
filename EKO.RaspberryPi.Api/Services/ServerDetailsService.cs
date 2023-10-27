using EKO.RaspberryPi.Api.Entities;
using EKO.RaspberryPi.Api.Services.Contracts;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EKO.RaspberryPi.Api.Services;

public class ServerDetailsService : IServerDetailsService
{
    public ServerDetails GetServerDetails()
    {
        return new ServerDetails
        {
            Version = Assembly.GetEntryAssembly()?.GetName().Version ?? new Version(),
            OS = RuntimeInformation.OSDescription,
            Framework = RuntimeInformation.FrameworkDescription,
            Timestamp = DateTime.Now,
            Uptime = DateTime.Now - Process.GetCurrentProcess().StartTime.ToLocalTime()
        };
    }
}
