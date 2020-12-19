using System;

namespace AddressBookUsingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Using Linq");
            AddressBookManagement management = new AddressBookManagement();
            bool i = true;
            while (i)
            {
                Console.WriteLine("1.GetAllRecords");
                Console.WriteLine("2.Update The person ");
                Console.WriteLine("3.Exit");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1 :
                            management.getAllData();
                            break;
                        case 2:
                            management.UpdatePersonByName();
                            break;
                        case 3:
                            i = false;
                            break;
                        default:
                            Console.WriteLine("Choose proper option");
                            break;
                    }
                }
                catch (System.FormatException formatException)
                {
                    Console.WriteLine(formatException);
                }
            }
        }
    }
}
