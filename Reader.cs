using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Reader : User //унаследован от интерфейса User
    {
        public int readersTicketNumber;//номер читательского билета;
        public string login;//login
        public string password;//password
        public string lastName;//фамилия, 
        public string firstName;//имя, 
        public string middleName;//отчество;
        public DateTime birthday;//дата рождения;
        public string tel;//номер телефона.
        List<string> booksInHands;//список книг, которые в данный момент у читателя;
        List<string> booksRead;//список книг, которые читатель вернул.
        //конструкторы
        public Reader(string login, string password, string lastName, string firstName, string middleName, DateTime birthday, string tel)
        {
            Random rnd = new Random();
            int value = rnd.Next(22222, 99999); //генерируем случайное id
            this.readersTicketNumber = value;
            this.login = login;
            this.password = password;
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.birthday = birthday;
            this.tel = tel;
            this.booksInHands = new List<string>();
            this.booksRead = new List<string>();
        }
        public void SaveInFile() //сохраняем читателя в файл
        {
            string file = "\\Readers\\" + this.login + ".txt";
            using (FileStream fileStream = new FileStream(file, FileMode.Create))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.AutoFlush = true;

                streamWriter.WriteLine(this.password);//первая строка это пароль
                streamWriter.WriteLine(this.readersTicketNumber);//вторая сторка это номер читательского               
                streamWriter.WriteLine(this.login);//третья строка это логин
                streamWriter.WriteLine(this.lastName);//четвертая  строка это фамилия
                streamWriter.WriteLine(this.firstName);//пятая строка это фамилия
                streamWriter.WriteLine(this.middleName);//шестая строка это отчетство
                streamWriter.WriteLine(Convert.ToString(this.birthday));//седьмая строка это др
                streamWriter.WriteLine(this.tel); //восьмая строка это телефон                
                int kolvo = this.booksInHands.Count();
                streamWriter.WriteLine(Convert.ToString(kolvo));  //девятая строка это кол-во книг на руках 
                for (int i = 0; i < kolvo; i++) // строки с книгами на руках
                {
                    streamWriter.WriteLine(Convert.ToString(this.booksInHands[i]));
                }
                kolvo = this.booksRead.Count();
                streamWriter.WriteLine(Convert.ToString(kolvo));  //потом строка это кол-во книг прочитанных
                for (int i = 0; i < kolvo; i++)// строки с книгами прочитанными
                {
                    streamWriter.WriteLine(Convert.ToString(this.booksRead[i]));
                }
                streamWriter.Close();
            }
        }
        public string GetFIO()
        {
            string FIO = this.lastName + " " + this.firstName + " " + this.middleName;
            return FIO;
        }
    }
}
