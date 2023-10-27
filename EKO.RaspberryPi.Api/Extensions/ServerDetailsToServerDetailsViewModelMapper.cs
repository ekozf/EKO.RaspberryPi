using EKO.RaspberryPi.Api.Entities;
using EKO.RaspberryPi.Api.Models;

namespace EKO.RaspberryPi.Api.Extensions;

public static class ServerDetailsToServerDetailsViewModelMapper
{
    public static ServerDetailsViewModel ToServerDetailsViewModel(this ServerDetails serverDetails)
    {
        return ServerDetailsViewModel.FromServerDetails(serverDetails);
    }
}
