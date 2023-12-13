using AddressBookConsole.Enums;

namespace AddressBookConsole.Interfaces
{
    public interface IServiceResult
    {
        object Result { get; set; }
        ServiceStatus Status { get; set; }
    }
}