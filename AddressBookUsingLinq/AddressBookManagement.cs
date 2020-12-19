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
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("Zip", typeof(double));
            dataTable.Columns.Add("PhoneNumber", typeof(double));
            dataTable.Columns.Add("Email", typeof(string));

            dataTable.Rows.Add("Bhagya", "Laxmi", "Nagarkurnool", "MBNR", "TS", 509215, 8410257963, "Bhagi@gmail.com");
            dataTable.Rows.Add("sravani", "sabbesett", "GandhiNagar", "VijayaWada", "Ap", 509000, 8419874102, "Sravani@gmail.com");
            dataTable.Rows.Add("TejasWini", "Kulkarni", "Mumbai", "RamNagar", "TS", 509211, 8410257900, "Teju@gmail.com");
            dataTable.Rows.Add("Rishitha", "Reddy", "PRP", "JCL", "AP", 509201, 8410257321, "Rishitha@gmail.com");
            dataTable.Rows.Add("SriCharitha", "Reddy", "BPL", "KlKy", "UP", 509206, 8410257123, "Charitha@gmail.com");
            dataTable.Rows.Add("Navya", "Reddy", "MEP", "KlKy", "UP", 509206, 8410257111, "navya@gmail.com");
        }        
    }   
}
