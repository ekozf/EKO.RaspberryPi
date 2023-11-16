using EKO.RaspberryPi.Shared.ServerEntities;

namespace EKO.RaspberryPi.AppLogic.Services.Contracts;

public interface IServerDetailsService
{
    public ServerDetails GetServerDetails();
}
