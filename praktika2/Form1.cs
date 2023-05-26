using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace praktika2
{
    public partial class Form1 :Form
    {
        private PhoneBook phoneBook;

        public Form1 ()
        {
            InitializeComponent( );
            phoneBook = new PhoneBook( );
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            LoadPhoneBook("text.txt");
        }

        private void LoadPhoneBook (string fileName)
        {
            try
            {
                PhoneBookLoader.Load(phoneBook, "text.txt");
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Ошибка загрузки книги: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePhoneBook (string fileName)
        {
            try
            {
                PhoneBookLoader.Save(phoneBook, "text.txt");

                using ( StreamWriter writer = new StreamWriter(fileName) )
                {
                    foreach ( Contact contact in phoneBook.GetContacts( ) )
                    {
                        writer.WriteLine($"{contact.Name},{contact.Phone}");
                    }
                }
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Ошибка сохранения книги: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAllContacts ()
        {
            listBox1.Items.Clear( );
            foreach ( Contact contact in phoneBook.GetContacts( ) )
            {
                listBox1.Items.Add(contact);
            }
        }

        private void button1_Click (object sender, EventArgs e)
        {
            DisplayAllContacts( );
        }

        private void button2_Click (object sender, EventArgs e)
        {
            string searchName = textBox1.Text.Trim( );
            if ( !string.IsNullOrEmpty(searchName) )
            {
                List<Contact> searchResults = phoneBook.SearchContacts(searchName);
                listBox1.Items.Clear( );
                foreach ( Contact contact in searchResults )
                {
                    listBox1.Items.Add(contact);
                }
            }
        }

        private void button3_Click (object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim( );
            string phone = textBox3.Text.Trim( );
            if ( !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone) )
            {
                Contact contact = new Contact(name, phone);
                phoneBook.AddContact(contact);
                listBox1.Items.Add(contact);
                textBox2.Clear( );
                textBox3.Clear( );
            }
        }

        private void button4_Click (object sender, EventArgs e)
        {
            SavePhoneBook("text.txt");
        }

        private void button5_Click (object sender, EventArgs e)
        {
            Application.Exit( );
        }

        private void button6_Click (object sender, EventArgs e)
        {

            if ( listBox1.SelectedIndex != -1 )
            {
                string selectedContact = listBox1.SelectedItem.ToString( );
                phoneBook.RemoveContactByName(selectedContact);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            SavePhoneBook("text.txt");
        }
    }
}
