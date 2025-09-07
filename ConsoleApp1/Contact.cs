namespace ConsoleApp1
{
    public class Contact
    {
        public Contact(int Id, string Name, string Phone, string Email)
        {
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.Email = Email;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
