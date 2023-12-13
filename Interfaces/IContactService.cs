using AddressBookConsole.Models;
using AddressBookConsole.Models.Responses;

namespace AddressBookConsole.Interfaces;

public interface IContactService
{
    IServiceResult AddContactToList(IContact contact);
    ServiceResult GetContactByEmailFromList(string email);
    IServiceResult GetContactsFromList();
    ServiceResult UpdateContactInList(IContact contact);
    ServiceResult DeleteContactFromList(Func<IContact, bool> predicate);
}
