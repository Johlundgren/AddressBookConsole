﻿using AddressBookConsole.Interfaces;

namespace AddressBookConsole.Models;

public class Contact : IContact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}
