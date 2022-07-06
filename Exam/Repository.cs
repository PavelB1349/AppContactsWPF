using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Repository
    {
        public static List<Contact> repContacts = new List<Contact>()
        {
            new Contact(){ShortName = "John", FullName = "John Doe", BirthDay = new DateTime(1900,10,10),
                Email = "unknoun@gmail.ru", Address = "Some State", Phone = "9999", TypeOfContact = "безличный", Notes = "Who am i?" },
            new Contact(){ShortName = "Иван", FullName = "Иванов Иван Иванович", BirthDay = new DateTime(2000,05,15),
                Phone = "7777", Email = "ivanov@mail.com", Address = "г.Иваново ул. Ивановича дом 6", TypeOfContact = "личный", Notes = "ЖКХ"}
        };
        

    }
}