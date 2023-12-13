using AddressBookConsole.Interfaces;
using AddressBookConsole.Models;
using AddressBookConsole.Models.Responses;
using System.Diagnostics;

namespace AddressBookConsole.Services;
internal class ContactService : IContactService
{
    private static readonly List<IContact> _contacts = new List<IContact>();

    public IServiceResult AddContactToList(IContact contact)
    {
        IServiceResult response = new ServiceResult();
        try
        {
            if (!_contacts.Any(c => c.Email == contact.Email))
            {
                _contacts.Add(contact);
                response.Status = Enums.ServiceStatus.SUCCESSED;
            }
            else
            {
                response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }
        return response;
    }

    public IServiceResult GetContactsFromList()
    {
        IServiceResult response = new ServiceResult();
        try
        {
            response.Status = Enums.ServiceStatus.SUCCESSED;
            response.Result = _contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }
        return response;
    }

    public ServiceResult DeleteContactFromList(Func<IContact, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public ServiceResult GetContactByEmailFromList(string email)
    {
        throw new NotImplementedException();
    }


    public ServiceResult UpdateContactInList(IContact contact)
    {
        throw new NotImplementedException();
    }
}
