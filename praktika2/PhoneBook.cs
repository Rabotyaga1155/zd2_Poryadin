using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika2
{
    public class PhoneBook
    {
        private List<Contact> contacts;

        public PhoneBook ()
        {
            contacts = new List<Contact>( );
        }

        public void RemoveContact (Contact contact)
        {
            contacts.Remove(contact);
            
        }

        public void RemoveContactByName (string name)
        {
            Contact contact = contacts.Find(c => c.Name == name);
            if ( contact != null )
            {
                contacts.Remove(contact);
            }
            
        }

        public void AddContact (Contact contact)
        {
            contacts.Add(contact);
        }
public Contact GetContactByName(string name)
    {
        return contacts.Find(c => c.Name == name);
    }
        
        public List<Contact> GetContacts ()
        {
            return contacts;
        }

        public List<Contact> SearchContacts (string searchName)
        {
            List<Contact> searchResults = new List<Contact>( );
            foreach ( Contact contact in contacts )
            {
                if ( contact.Name.Contains(searchName) )
                {
                    searchResults.Add(contact);
                }
            }
            return searchResults;
        }


    }
}
