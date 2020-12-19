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
                Console.WriteLine("3.Delete person ");
                Console.WriteLine("4.Retrieve persons Based on City or state");
                Console.WriteLine("5.Retrieve Count Based on City and state ");
                Console.WriteLine("6.Exit");
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
                            management.DeletePersonByName();
                            break;
                        case 4:
                            management.displayContactUsingCityOrState();
                            break;
                        case 5:
                            management.displayCountByCityAndState();
                            break;
                        case 6:
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
