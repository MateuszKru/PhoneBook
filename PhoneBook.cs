using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneBook
    {

        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void DisplayContactDetails(Contact contact)
        {
            Console.WriteLine($"{contact.Name} {contact.Number}");
        }
        public void DisplayContactByNumber(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);
            if (number == null)
            {
                Console.WriteLine("Cannot found contact");
            }
            else
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayAllContacts()
        {
            foreach (var contact in Contacts)
            {
                DisplayContactDetails(contact);
            }
        }

        public void DisplayContactByName(string name)
        {
            var nameContact = Contacts.Where(c => c.Name.Contains(name)).ToList();
            foreach (var contacts in nameContact)
            {
                DisplayContactDetails(contacts);
            }

        }
        public void RemoveContactByNumber(string number)
        {
            var contact = Contacts.FirstOrDefault(c => c.Number == number);
            if (number == null)
            {
                Console.WriteLine("Cannot found contact");
            }
            else
            {
                Contacts.Remove(contact);
            }
        }

        
        public void DisplayInstruction() 
        {
            Console.WriteLine();
            Console.WriteLine("Press 1 to add contact");
            Console.WriteLine("Press 2 to display contact by number");
            Console.WriteLine("Press 3 to search contact");
            Console.WriteLine("Press 4 to display all contacts");
            Console.WriteLine("Press 5 to Remove contact by number");
            Console.WriteLine("Press 0 to exit");
            Console.WriteLine();
        }


    }
}
