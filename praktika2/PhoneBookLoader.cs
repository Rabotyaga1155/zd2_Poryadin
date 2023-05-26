using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2
{
  public static class PhoneBookLoader
    {
        public static void Load (PhoneBook phoneBook, string fileName) 
        {
            if ( File.Exists(fileName) )
            {
                string [ ] lines = File.ReadAllLines(fileName);
                foreach ( string line in lines )
                {
                    string [ ] parts = line.Split(',');
                    if ( parts.Length == 2 )
                    {
                        string name = parts [ 0 ];
                        string phone = parts [ 1 ];
                        phoneBook.AddContact(new Contact(name, phone));
                    }
                }
            }
        }
        public static void Save (PhoneBook phoneBook, string fileName) 
        {
            using ( StreamWriter writer = new StreamWriter(fileName) )
            {
                foreach ( Contact contact in phoneBook.GetContacts( ) )
                {
                    writer.WriteLine($"{contact.Name},{contact.Phone}");
                }
            }
        }
    }
}
