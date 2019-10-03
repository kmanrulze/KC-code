using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // "" strings you need to escape some chars with \
            // @"" strings you don't
            var xmlFilePath = @"C:\revature\persons.xml";

            var data = GetInitialData();

            SerializeXmlToFile(xmlFilePath, data);
        }

        public static void SerializeXmlToFile(string xmlFilePath, List<Person> data)
        {
            // XmlSerializer was made pre-generics and has not been updated
            var serializer = new XmlSerializer(typeof(List<Person>));

            var fileStream = new FileStream(xmlFilePath, FileMode.Create);
        }

        public static List<Person> GetInitialData()
        {
            return new List<Person>
            {
                new Person
                {
                    Id=1,
                    Name = "Billy",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Dallas",
                        State = "TX"
                    }
                },
                new Person
                {
                    Id=1,
                    Name = "Billy"
                    //Address will be null by default
                }
            };
        }
    }
}
