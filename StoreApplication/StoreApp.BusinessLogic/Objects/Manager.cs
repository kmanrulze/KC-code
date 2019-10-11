using System;
using System.Collections.Generic;
using System.Text;


namespace StoreApp.BusinessLogic.Objects
{
    public class Manager
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int managerID { get; set; }

        public void SetFirstName(string name)
        {
            this.firstName = name; 
        }
        public void SetLastName(string name)
        {
            this.lastName = name;
        }
    }
}
