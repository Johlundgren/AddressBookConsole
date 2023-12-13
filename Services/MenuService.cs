using AddressBookConsole.Interfaces;
using AddressBookConsole.Models;

namespace AddressBookConsole.Services;

public interface IMenuService
{
    void ShowMainMenu();

}


public class MenuService : IMenuService
{
    private readonly IContactService _contactService = new ContactService();
    public void ShowMainMenu()
    {
        while (true)
        {
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine($"{"1.",-4} Add New Contact");
            Console.WriteLine($"{"2.",-4} View Contact List");
            Console.WriteLine($"{"0.",-4} Exit Application");
            Console.WriteLine();
            Console.Write("Enter your Option: ");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    ShowAddContactOption();
                    break;

                case "2":
                    ShowViewContactListOption();
                    break;

                case "0":
                    ShowExitApplicationOption();
                    break;

                default:
                    Console.WriteLine("\nInvalid Option, press any key to try again.");
                    Console.ReadKey();
                    break;

            }
        }
    }

    private void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to EXIT this application? (y/n): ");
        var option = Console.ReadLine();

        if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Environment.Exit(0);
        }
    }
    private void ShowAddContactOption()
    {
        IContact contact = new Contact();

        DisplayMenuTitle("Add New Customer");
        Console.Write("First name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("E-Mail: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Address: ");
        contact.Address = Console.ReadLine()!;

        var res = _contactService.AddContactToList(contact);

        switch(res.Status)
        {
            case Enums.ServiceStatus.SUCCESSED:
                Console.WriteLine("The customer was added successfully!");
                break;

            case Enums.ServiceStatus.ALREADY_EXISTS:
                Console.WriteLine("The customer already exists in the Addressbook.");
                break;

            case Enums.ServiceStatus.FAILED:
                Console.WriteLine("Failed when trying to add contact to Addressbook.");
                Console.WriteLine("See error message :: " + res.Result.ToString());
                break;
        }

        DisplayPressAnyKey();
    }

    private void ShowViewContactListOption()
    {
        DisplayMenuTitle("Contact List");
        var res = _contactService.GetContactsFromList();

        if (res.Status == Enums.ServiceStatus.SUCCESSED)
        {
            if (res.Result is List<IContact> contactList)
            {
                if (!contactList.Any())
                {
                    Console.WriteLine("No contacts found.");
                }
                else
                {
                    foreach (var contact in contactList)
                    {
                        Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}> {contact.PhoneNumber} {contact.Address}");
                    }
                }
            }
        }
            DisplayPressAnyKey();
    }

    private void ShowContactDetailOption()
    {

    }

    private void ShowDeleteContactOption()
    {

    }

    private void ShowUpdateContactOption()
    {

    }

    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"##### {title} #####");
        Console.WriteLine();
    }

    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}