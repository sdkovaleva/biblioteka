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
        User currentUser;//��������� ������������ � ���� ����������, ����� �������� ��� ���� �� �������
        public FLibrary()
        {
            InitializeComponent();
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
                currentUser = new Librarian(file);
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
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //���������� ������ ���������� ��������
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //������� ���� ���������� ��������
        }
    }
}