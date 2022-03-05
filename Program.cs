using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace PhoneBook
{
    class Program : PhoneBook
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook;
            bool isSerializedPhoneBook =
                File.Exists(@"C:\Users\matkr\source\repos\PhoneBook\JSON\phoneBookSerialized.json");
            if (!isSerializedPhoneBook)
            {
                phoneBook = new PhoneBook();
            }
            else
            {
                string serializedPhoneBook =
                    File.ReadAllText(@"C:\Users\matkr\source\repos\PhoneBook\JSON\phoneBookSerialized.json");

                phoneBook = JsonConvert.DeserializeObject<PhoneBook>(serializedPhoneBook);
            }




            Console.WriteLine("Welcome in the phone book");

            phoneBook.DisplayInstruction();

            var UserInput = Console.ReadLine();


            while (true)
            {
                switch (UserInput)
                {
                    case "1":
                        Console.WriteLine("Insert number:");
                        var number = Console.ReadLine();
                        while (UserInput.Length != 9)
                        {
                            if (number.Length != 9)
                            {
                                Console.WriteLine("Contact number must have 9 digits.");

                                Console.WriteLine("Insert number:");
                                number = Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }

                        }
                        Console.WriteLine("Insert name:");
                        var name = Console.ReadLine();
                        while (UserInput.Length < 3)
                        {
                            if (name.Length < 3)
                            {
                                Console.WriteLine("Contact name must have 3 or more letters.");

                                Console.WriteLine("Insert name:");
                                name = Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }
                        }


                        var newContact = new Contact(name, number);

                        phoneBook.AddContact(newContact);
                        Console.WriteLine($"Contact {name} has been added");

                        break;
                    case "2":

                        Console.WriteLine("Insert number:");
                        var searchNumber = Console.ReadLine();

                        phoneBook.DisplayContactByNumber(searchNumber);

                        break;
                    case "3":
                        Console.WriteLine("Insert name:");
                        var searchName = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Contact:");
                        phoneBook.DisplayContactByName(searchName);


                        break;
                    case "4":
                        Console.WriteLine("Your contact List:");

                        phoneBook.DisplayAllContacts();
                        break;
                    case "5":

                        Console.WriteLine("Insert number:");
                        var removeNumber = Console.ReadLine();


                        phoneBook.RemoveContactByNumber(removeNumber);
                        Console.WriteLine($"Contact {removeNumber} has been removed.");


                        break;
                    case "0":
                        string phoneBookSerialized = JsonConvert.SerializeObject(phoneBook);
                        File.WriteAllText(@"C:\Users\matkr\source\repos\PhoneBook\JSON\phoneBookSerialized.json", phoneBookSerialized);
                        Console.WriteLine("Changes saved and application closed");
                        return;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;

                }
                phoneBook.DisplayInstruction();
                UserInput = Console.ReadLine();
            }




        }
    }
}
