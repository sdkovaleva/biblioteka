/*
� �������� ������ �������� ������ �� git-�����������.
���������� ����� ����� ��������� ����������, ��� ��� � ������ ������ ������ ���� �������:
- ���� (� ������������ � ������� ����);
- ������������;
- ������ (����� ��� ����������, �� � ��������� ������������, ��� ������ ����� ������).

 ���������� �������� ��������� ������������:
-��������, ���������� � �������������� ���������� � ���������;
-��������, ���������� � �������������� ���������� � ������;
-���������� ������ �����.
���������� ����� ��� ����������:
1. ��� ��������
(�������� ����� ����������� ������ ����, ������ ����� �� ������ ��� �� ��������, ���� ����� ��� � �������, �� ��������� ������);
2.��� ���������� ����������
(��������� ���������� ����� ��������, ������� ��� ��������������� ���������� � �����, �������� ������ � ����� ���� ��
���������, ���� ������� �����, �� ������� ���� ������, �� ������������ �����������).

������� ������ ������ � ������.
��� ����������� �������� ���������� ������� ��������� ����������:
�������, ���, ��������;
���� ��������;
����� ��������.
����� ����������� ��� ������� �������� ����� �������� ����������:
����� ������������� ������;
������ ����, ������� � ������ ������ � ��������;
������ ����, ������� �������� ������.

��� ���������� ����� ���������� ������� ��������� ����������:
��������;
�����;
��� �������;
��������� ��������.
����� ��� ������ ����� ����� ����������� ������(�� ����� ��� � ����������), ������� �������� ����� �����
*/
namespace Biblioteka
{
    public partial class FLibrary : Form
    {
        Librarian currentLibrarian;//��������� �������� ���������� 
        Reader currentReader;//��������� �������� ������������ 
        Book currentBook;//������� �����
        public FLibrary()
        {
            InitializeComponent();
            UpdateReaders();
        }

        private void BLogin_Click(object sender, EventArgs e)
        {
            //������ ������. ��������� ������� ����� ������������ � ���������� ������
            String username = TBLogin.Text;
            String pass = TBPassword.Text;
            String papka;
            if (RBLoginLibrarian.Checked) papka = "\\Librarians\\";
            else papka = "\\Readers\\";
            String file = papka + "\\" + username + ".txt";
            if (File.Exists(file)) //���� ���� ����� ������������ ���� 
            {
                using (FileStream fileStream = new FileStream(file, FileMode.Open)) //������ ����
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    String parolfile = streamReader.ReadLine(); //������ ������ ������
                    streamReader.Close();
                    if (pass.Equals(parolfile))// ���� ��������� ������ ������������ ������������ �� �����
                    {
                        if (RBLoginLibrarian.Checked) Authorization(true, file); // ������ ��� ���������
                        else Authorization(false, file); // ������ ��� ��������
                    }

                }
            }
            else { }//����������� ����, ��� ����� ������������ �� ������ 

        }

        private void Authorization(bool Librarian, String file)
        {
            if (Librarian)
            {
                //����� ����� ������� ������� ��������, �� ��������� ���
                //��������� ������ ����������
                currentLibrarian = new Librarian(file);
                this.Text = "����������: ��������� " + currentLibrarian.GetFIO();
            }
            else
            {
                //����� ����� ������� ������� ����������
            }

        }

        private void BRegister_Click(object sender, EventArgs e)
        {
            //������ �����������. ������� ���� ������������ � ��������� ���
            String papka;
            if (RBRegLibrarian.Checked)
            {
                currentLibrarian = new Librarian(TBRegLogin.Text,
                    TBRegPassword.Text,
                    TBRegLastName.Text,
                    TBRegName.Text,
                    TBRegMidName.Text,
                    DTPRegBirthday.Value,
                    TBRegTelNum.Text);
                currentLibrarian.SaveInFile();

            }
            else papka = "\\Readers\\";


        }

        private void BPickBookReader_Click(object sender, EventArgs e)
        {
            //������ ������ �����. ����������� ��������� ����� ��� �� ���� ��������, � �������� ��������� ����� � ������
        }

        private void BOrderBookReader_Click(object sender, EventArgs e)
        {
            //������� ��������� � ��� ��� ��������� ����, ��������� ����� � �������� ��� �� ����� ��������
            //���� ����� �� �����, ���������� ������ � ������� �� ��� 
        }

        private void BRentBook_Click(object sender, EventArgs e)
        {
            //������ ������ �����. ����� ���� ����� ��� ������ �����, ������ ��� �������� ���� �������
        }

        private void BReturnBook_Click(object sender, EventArgs e)
        {
            //������ �������� �����. ���� ���� �� ����� - �������� ����� � �������� ������� � �� ������
            //�������� �� � ������ ����������� ���� ��������
        }

        private void BAddBook_Click(object sender, EventArgs e)
        {
            //��������� ���� �����
            currentBook = new Book(Convert.ToInt32(TBCodeBookLibrarian.Text),
                    TBNameBookLibrarian.Text,
                    TBAuthorBookLibrarian.Text,
                    RTBCommentBookLibrarian.Text
                    ); //����������� ������� ���� �� ���������� �������
            currentBook.SaveInFile(); // ��������� � ����
            //��������� ������ ����
        }

        private void BEditBook_Click(object sender, EventArgs e)
        {
            //�������������� ���� ������ ������ �������
        }

        private void BDelBook_Click(object sender, EventArgs e)
        {
            //������� ���� �����
        }

        private void BAddREader_Click(object sender, EventArgs e)
        {
            //��������� �������� � ���������� �������
            currentReader = new Reader(TBLRLogin.Text,
                TBLRPassword.Text,
                TBLRLastName.Text,
                TBLRName.Text,
                TBLRMidName.Text,
                DTPLRBirthday.Value,
                TBLRTelNum.Text);
            currentReader.SaveInFile();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //���������� ������ ���������� ��������
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //������� ���� ���������� ��������
        }

        public void UpdateReaders()
        {
            //������� ��������� ������ ���������
            string papka = "\\Readers\\";
            //https://docs.microsoft.com/ru-ru/dotnet/api/system.io.directory.getfiles?view=net-6.0 ��� ������ ������
            string[] fileEntries = Directory.GetFiles(papka);
            foreach (string fileName in fileEntries)
            {
                LBReaderList.Items.Add(fileName);
            }
        }
        /*
        private void LBReaderList_Click(object sender, EventArgs e)
        {
            
            String file = LBReaderList.SelectedItem.ToString(); // ����� ����� ���������� ������
            //��������� ����
            //�������� ������ �� ����� � ���� 
            
        }
        */
    }
}