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
    /// Логика взаимодействия для FindContact.xaml
    /// </summary>
    public partial class FindContact : Window
    {
        public FindContact()
        {
            InitializeComponent();
        }

        public void PrintContactInfo(Contact contact)
        {
            tbDisplay.Text += $"Имя: {contact.ShortName}\nФИО: {contact.FullName}\n" +
                $"Тип контакта: {contact.TypeOfContact}\nНомер телефона: {contact.Phone}\nEmail адрес: {contact.Email}\n" +
                $"Адрес: {contact.Address}День рождения: {contact.BirthDay}\nЗаметки: {contact.Notes}\n\n";
        }
        private void FindContact_Click(object sender, RoutedEventArgs e)
        {
            tbDisplay.Text = "";
            string name = tNameForDelete.Text;
            var results = Repository.repContacts.Where(x => x.ShortName.Contains(name));
            if (results.Count() > 0)
            {
                foreach (var item in results)
                {
                    PrintContactInfo(item);
                }
            }
            else
            {
                MessageBox.Show("Контакт не найден!");
                tbDisplay.Text = "";
            }        

           
        }
        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            string name = tNameForDelete.Text;
            Repository.repContacts.RemoveAll(x => x.ShortName.Contains(name));
            MessageBox.Show("Контакт удалён.");
            tbDisplay.Text = "";
        }
    }
}
