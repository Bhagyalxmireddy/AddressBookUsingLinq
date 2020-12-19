using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookUsingLinq
{
    public class AddressBookManagement
    {
        public DataTable dataTable = new DataTable();
        public AddressBookManagement()
        {
            DataColumn dataColumn;
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(Int32);
            dataColumn.ColumnName = "PersonId";
            dataColumn.AutoIncrement = true;
            dataTable.Columns.Add(dataColumn);
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("Zip", typeof(double));
            dataTable.Columns.Add("PhoneNumber", typeof(double));
            dataTable.Columns.Add("Email", typeof(string));
            dataColumn = new DataColumn();
            dataColumn.DataType = typeof(string);
            dataColumn.ColumnName = "PersonType";
            dataColumn.AllowDBNull = false;
            dataTable.Columns.Add(dataColumn);
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = dataTable.Columns["PersonID"];
            dataTable.PrimaryKey = PrimaryKeyColumns;

            dataTable.Rows.Add(1,"Bhagya", "Laxmi", "Nagarkurnool", "MBNR", "TS", 509215, 8410257963, "Bhagi@gmail.com","Family");
            dataTable.Rows.Add(2,"sravani", "sabbesett", "GandhiNagar", "VijayaWada", "Ap", 509000, 8419874102, "Sravani@gmail.com","Friend");
            dataTable.Rows.Add(3,"TejasWini", "Kulkarni", "Mumbai", "RamNagar", "TS", 509211, 8410257900, "Teju@gmail.com","profession");
            dataTable.Rows.Add(4,"Rishitha", "Reddy", "PRP", "JCL", "AP", 509201, 8410257321, "Rishitha@gmail.com","Family");
            dataTable.Rows.Add(5,"SriCharitha", "Reddy", "BPL", "KlKy", "UP", 509206, 8410257123, "Charitha@gmail.com","Family");
            dataTable.Rows.Add(6,"Navya", "Reddy", "MEP", "KlKy", "UP", 509206, 8410257111, "navya@gmail.com","Friend");
        } 
        public void getAllData()
        {
            foreach(var data in dataTable.AsEnumerable())
            {
                Console.WriteLine("FirstName: " + data.Field<string>("Firstname") + "," 
                    + "LastName: " + data.Field<string>("LastName") + ","
                    + "Address: " + data.Field<string>("Address") + ","
                    + "City: " + data.Field<string>("City") + ","  
                    + "State: " + data.Field<string>("State") + ","
                    + "Zip: " + data.Field<double>("Zip") + ","
                    + "PhoneNumber: " + data.Field<double>("PhoneNumber") + ","
                    + "Email: " + data.Field<string>("Email"));
                Console.WriteLine("\n");
            }
        }
        public void UpdatePersonByName()
        {
            Console.WriteLine("Enter FirstName : ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter columnName : ");
            string columnName = Console.ReadLine();
            Console.WriteLine("Enter Upadated Value : ");
            string Updatedvalue = Console.ReadLine();
            DataRow updatedperson = dataTable.Select("FirstName = '" + firstName + "'").FirstOrDefault();
            updatedperson[columnName] = Updatedvalue;
            Console.WriteLine("Contanted is Updated ");
            getAllData();
        }
        public void DeletePersonByName()
        {
            Console.WriteLine("Enter Firstname: ");
            string firstName = Console.ReadLine();
            var data = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName") == firstName);

            foreach (var rows in data.ToList())
            {
                rows.Delete();
            }
            getAllData();
        }
        public void displayContactUsingCityOrState()
        {
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State : ");
            string state = Console.ReadLine();
            var Record = from record in dataTable.AsEnumerable()
                         where record.Field<string>("City").Equals(city) || record.Field<string>("State").Equals(state)
                         select record;

            foreach (var record in Record)
            {
                Console.WriteLine("FirstName :" + record.Field<string>("Firstname") + "," + "City :" + record.Field<string>("City") + "," +
                    "State : " + record.Field<string>("State"));               
            }
        }
        public void displayCountByCityAndState()
        {
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State : ");
            string state = Console.ReadLine();
            var Record = from record in dataTable.AsEnumerable()
                         where record.Field<string>("City").Equals(city) && record.Field<string>("State").Equals(state)
                         select record;
            Console.WriteLine("No.of Records persent in dataTable is " + Record.Count());
        }
        public void OrderedByFirstnameWithGivenCity()
        {
            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();

            var Records = from person in dataTable.AsEnumerable()
                        where person.Field<string>("City").Equals(city)
                        orderby person.Field<string>("FirstName")
                        select person;
            foreach (var record in Records)
            {
                getAllData();
            }

        }
        public void CountByPersonType()
        {
            var element = from contact in dataTable.AsEnumerable()
                          group contact by contact.Field<string>("PersonType") into data
                          select new { PersonTypeName = data.Key, count = data.Count() };
            element.ToList().ForEach(elemen => Console.WriteLine($"ContactType : {elemen.PersonTypeName} \t Count = {elemen.count}"));
        }
    }   
}
