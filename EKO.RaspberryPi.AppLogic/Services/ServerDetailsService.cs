using EKO.RaspberryPi.AppLogic.Services.Contracts;
using EKO.RaspberryPi.Shared.ServerEntities;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EKO.RaspberryPi.AppLogic;

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
