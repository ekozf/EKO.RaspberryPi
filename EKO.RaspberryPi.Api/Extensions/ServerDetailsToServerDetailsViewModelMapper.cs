using EKO.RaspberryPi.Api.Models;
using EKO.RaspberryPi.Shared.ServerEntities;

namespace EKO.RaspberryPi.Api.Extensions;

public static class ServerDetailsToServerDetailsViewModelMapper
{
    public static ServerDetailsViewModel ToServerDetailsViewModel(this ServerDetails serverDetails)
    {
        return ServerDetailsViewModel.FromServerDetails(serverDetails);
    }
}
