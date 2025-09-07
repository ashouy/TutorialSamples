using ConsoleApp1;

List<Contact> Contacts = new List<Contact>();
bool ProgramRunning = true;

while (ProgramRunning)
{
    Console.WriteLine("\nContact Agenda");
    Console.WriteLine("1 - Add contact");
    Console.WriteLine("2 - List contacts");
    Console.WriteLine("3 - Search contact");
    Console.WriteLine("4 - Remove contact");
    Console.WriteLine("0 - Exit");
    Console.Write("Choose an option: ");

    var Option = Console.ReadLine();

    switch (Option)
    {
        case "1":
            AddContact();
            break;
        case "2":
            ListContacts();
            break;
        case "3":
            SearchContact();
            break;
        case "4":
            RemoveContact();
            break;
        case "0":
            ProgramRunning = false;
            break;
        default:
            ProgramRunning = false;
            break;
    }
}

void RemoveContact()
{
    Console.Write("Enter the name of the contact to remove: ");
    var nameToRemove = Console.ReadLine();
    var removed = Contacts.RemoveAll(c => c.Name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase));

    if (removed > 0)
        Console.WriteLine("Contact removed!");
    else
        Console.WriteLine("Contact not found.");
}

void SearchContact()
{
    Console.Write("Enter the name to search: ");
    var searchName = Console.ReadLine();
    var found = Contacts.FindAll(c => c.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));

    if (found.Count == 0)
    {
        Console.WriteLine("No contacts found.");
        return;
    }

    foreach (var contact in found)
    {
        Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}");
    }
}

void ListContacts()
{
    if (Contacts.Count == 0)
    {
        Console.WriteLine("No contacts registered.");
        return;
    }

    foreach (var contact in Contacts)
    {
        Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}");
    }
}

void AddContact()
{
    Console.Write("Name: ");
    var name = Console.ReadLine();
    Console.Write("Phone: ");
    var phone = Console.ReadLine();
    Console.Write("Email: ");
    var email = Console.ReadLine();
    int newId = GetNewId(Contacts);
    Contacts.Add(new Contact(newId, name, phone, email));
}

int GetNewId(List<Contact> contacts)
{
    if (contacts.Count == 0)
    {
        return 1;
    }
    else
    {
        return contacts.MaxBy(c => c.Id).Id + 1;
    }
}