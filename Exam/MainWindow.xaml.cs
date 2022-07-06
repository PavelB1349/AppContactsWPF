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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.IO;

/*
 * Вариант II
 Создать приложение «Контакты». 
Основная задача проекта – возможность удобно хранить информацию о контактах.
Интерфейс приложения должен предоставлять такие возможности:
⦁	Для каждого контакта необходимо хранить следующую информацию:
	⦁ Имя (короткое);
	⦁ ФИО;
	⦁ Тип контакта (работа/семья/...);
	⦁ Телефон;
	⦁ E-mail;
	⦁ Адрес;
	⦁ День рождения;
	⦁ Заметки.
⦁	Поиск контакта по имени.
⦁	Добавление/удаление контакта.
⦁	Хранить всю информацию в файле (формата txt).
 */
namespace Exam
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            PrintAllContactsInfo();
        }
        string path = @"G:\WPF\Exam\contacts.txt";

        /// <summary>
        /// Метод записывает всю информацию о объекте контакт в txt файла
        /// </summary>
        public static void SaveToTxt(string path)
        {

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var contact in Repository.repContacts)
                {
                    sw.WriteLine($"Имя: {contact.ShortName}\nФИО: {contact.FullName}\n" +
                $"Тип контакта: {contact.TypeOfContact}\nНомер телефона: {contact.Phone}\nEmail адрес: {contact.Email}\n" +
                $"Адрес: {contact.Address}\nДень рождения: {contact.BirthDay}\nЗаметки: {contact.Notes}\n\n");
                }
            }
        }

        /// <summary>
        /// Метод выводит весь текст из txt файла на главный дисплей
        /// </summary>
        public void PrintFromTxt()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                tbDisplay.Text = sr.ReadToEnd();
            }
        }

        public void PrintContactInfo(Contact contact)
        {
            tbDisplay.Text += $"Имя: {contact.ShortName}\nФИО: {contact.FullName}\n" +
                $"Тип контакта: {contact.TypeOfContact}\nНомер телефона: {contact.Phone}\nEmail адрес: {contact.Email}\n" +
                $"Адрес: {contact.Address}\nДень рождения: {contact.BirthDay}\nЗаметки: {contact.Notes}\n\n";
        }
        public void PrintAllContactsInfo()
        {
            tbDisplay.Text = "";
            foreach (var contact in Repository.repContacts)
            {
                tbDisplay.Text += $"Имя: {contact.ShortName}\nФИО: {contact.FullName}\n" +
                $"Тип контакта: {contact.TypeOfContact}\nНомер телефона: {contact.Phone}\nEmail адрес: {contact.Email}\n" +
                $"Адрес: {contact.Address}\nДень рождения: {contact.BirthDay}\nЗаметки: {contact.Notes}\n\n";
            }
            SaveToTxt(path);
        }

        private void BFindContact_Click(object sender, RoutedEventArgs e)
        {
            FindContact findContact = new FindContact();
            findContact.ShowDialog();
            SaveToTxt(path);
            PrintFromTxt();
        }

        private void BAddContact_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact();
            addContact.ShowDialog();
            SaveToTxt(path);
            PrintFromTxt();
        }

        
        private void BAllContacts_Click(object sender, RoutedEventArgs e)
        {
            PrintFromTxt();
        }
        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
