using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal class Book
    {
        public int bookCode;//код издания;
        public string bookName;//название;
        public string bookAuthor;//автор;
        public string bookDescription;//текстовое описание.
        public bool inHands;//статус
        public string bookCurrentReader;//у кого на руках
        List<string> waitingReaders;//очередь ожидающих

        public Book(int bookCode, string bookName, string bookAuthor, string bookDescription)
        {
            this.bookCode = bookCode;
            this.bookName = bookName;
            this.bookAuthor = bookAuthor;
            this.bookDescription = bookDescription;
            this.waitingReaders = new List<string>();
            this.bookCurrentReader = "";
            this.inHands = false;
        }

        public void SaveInFile()
        {
            string file = "\\Books\\" + this.bookName + "  " + this.bookAuthor + ".txt";
            using (FileStream fileStream = new FileStream(file, FileMode.Create))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.AutoFlush = true;

                streamWriter.WriteLine(this.bookName);//первая строка это название
                streamWriter.WriteLine(this.bookAuthor);//вторая сторка это автор              
                streamWriter.WriteLine(this.bookCode);//третья строка это код книги
                streamWriter.WriteLine(this.bookDescription);//четвертая  строка это описание
                streamWriter.WriteLine(Convert.ToString(this.inHands));//пятая строка это на руках или нет
                streamWriter.WriteLine(this.bookCurrentReader);//шестая строка это у кого на руках
                int kolvoReaders = this.waitingReaders.Count();
                streamWriter.WriteLine(Convert.ToString(kolvoReaders));//шестая строка это количество ожидающих
                for (int i = 0; i < kolvoReaders; i++)
                {
                    streamWriter.WriteLine(Convert.ToString(this.waitingReaders[i])); //остальные строки это ожидающие
                }
                streamWriter.Close();
            }
        }
    }
}
