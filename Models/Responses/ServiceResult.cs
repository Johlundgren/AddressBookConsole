using AddressBookConsole.Enums;
using AddressBookConsole.Interfaces;

namespace AddressBookConsole.Models.Responses;
public class ServiceResult : IServiceResult
{
    public ServiceStatus Status { get; set; }
    public object Result { get; set; } = null!;
}
