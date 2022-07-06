using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        //List<Contact> contacts = Repository.repContacts;
        public AddContact()
        {
            InitializeComponent();
            
        }
        
        //string path = @"C:/Users/БалакшинП/Documents/XML/file.xml";

        private void BAddcontact_Click(object sender, RoutedEventArgs e)
        {            
            string birthDay = tBirthDay.Text;
            Repository.repContacts.Add(new Contact
            {
                ShortName = tShortName.Text,
                FullName = tFullName.Text,
                TypeOfContact = tTypeOfContact.Text,
                Phone = tPhone.Text,
                Email = tEmail.Text,
                BirthDay = DateTime.Parse(tBirthDay.Text),
                Address = tAddress.Text,
                Notes = tNotes.Text
            });
            MessageBox.Show("Контакт добавлен.");
            
            Close();
        }
    }
}
