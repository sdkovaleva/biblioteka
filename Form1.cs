/*
В качестве ответа добавьте ссылку на git-репозиторий.
Приложение может иметь частичную реализацию, при это в каждом классе должны быть описаны:
- поля (с комментарием к каждому полю);
- конструкторы;
- методы (можно без реализации, но с подробным комментарием, что данный метод делает).

 Приложение обладает следующим функционалом:
-просмотр, добавление и редактирование информации о читателях;
-просмотр, добавление и редактирование информации о книгах;
-оформление выдачи книги.
Приложение имеет два интерфейса:
1. для читателя
(читателя может просмотреть список книг, искать книгу по автору или по названию, если книги нет в наличии, то отправить заявку);
2.для сотрудника библиотеки
(сотрудник библиотеки может добавить, удалить или отредактировать информацию о книге, оформить выдачу и прием книг от
читателей, если вернули книгу, на которую есть заявка, то отображается уведомление).

Система хранит данный в файлах.
При регистрации читателя необходимо указать следующую информацию:
фамилия, имя, отчество;
дата рождения;
номер телефона.
После регистрации для каждого читателя также доступна информация:
номер читательского билета;
список книг, которые в данный момент у читателя;
список книг, которые читатель вернул.

При добавлении книги необходимо указать следующую информацию:
название;
автор;
код издания;
текстовое описание.
Также для каждой книги можно просмотреть статус(на руках или в библиотеке), очередь желающих взять книгу
*/
namespace Biblioteka
{
    public partial class FLibrary : Form
    {
        User currentUser;//объявляем пользователя в виде интерфейса, потом назначим как один из классов
        public FLibrary()
        {
            InitializeComponent();
        }

        private void BLogin_Click(object sender, EventArgs e)
        {
            //кнопка логина. Проверяет наличие файла пользователя и сравнивает пароль
            String username = TBLogin.Text;
            String pass = TBPassword.Text;
            String papka;
            if (RBLoginLibrarian.Checked) papka = "\\Librarians\\";
            else papka = "\\Readers\\";
            String file = papka + "\\" + username + ".txt";
            if (File.Exists(file)) //если файл этого пользователя есть 
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open)) //читаем файл
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    String parolfile = streamReader.ReadLine(); //читаем первую строку
                    if (pass.Equals(parolfile))// если введенный пароль эквивалентен прочитанному из файла
                    {
                        if (RBLoginLibrarian.Checked) Authorization(true, file); // входим как сотрудник
                        else Authorization(false, file); // входим как читатель
                    }

                }
            }
            else { }//всплывающее окно, что такой пользователь не найден 
        }

        private void Authorization(bool Librarian, String file)
        {
            if (Librarian)
            {
                //здесь нужно удалять вкладки читателя, но непонятно как
                //загружаем данные сотрудника
                currentUser = new Librarian(file);
            }
            else
            {
                //здесь нужно удалять вкладки сотрудника
            }

        }

        private void BRegister_Click(object sender, EventArgs e)
        {
            //кнопка регистрации. Создает файл пользователя и заполняет его
            String papka;
            if (RBRegLibrarian.Checked)
            {
                currentUser = new Librarian(TBRegLogin.Text,
                    TBRegPassword.Text,
                    TBRegLastName.Text,
                    TBRegName.Text,
                    TBRegMidName.Text,
                    DTPRegBirthday.Value,
                    TBRegTelNum.Text);
                currentUser.SaveInFile();

            }
            else papka = "\\Readers\\";


        }

        private void BPickBookReader_Click(object sender, EventArgs e)
        {
            //Кнопка взятия книги. Присваевает выбранной книге что ее взял читатель, а читателю добавляет книгу в список
        }

        private void BOrderBookReader_Click(object sender, EventArgs e)
        {
            //Выводит сообщение о том что заполните поля, добавляет книгу с отметкой что ее нужно заказать
            //если книга на руках, предлагает встать в очередь на нее 
        }

        private void BRentBook_Click(object sender, EventArgs e)
        {
            //Кнопка выдачи книги. почти тоже самое что взятие книги, только еще читателя надо указать
        }

        private void BReturnBook_Click(object sender, EventArgs e)
        {
            //Кнопка возврата книги. Если была на руках - обнулить книге и читателю отметки о ее взятии
            //Дописать ее в список прочитанных книг читателя
        }

        private void BAddBook_Click(object sender, EventArgs e)
        {
            //Добавляет файл книги
        }

        private void BEditBook_Click(object sender, EventArgs e)
        {
            //Перезаписывает файл книгис новыми данными
        }

        private void BDelBook_Click(object sender, EventArgs e)
        {
            //Удаляет файл книги
        }

        private void BAddREader_Click(object sender, EventArgs e)
        {
            //Добавляет читателя с указанными данными
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Записывает заново указанного читателя
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Удаляет файл указанного читателя
        }
    }
}