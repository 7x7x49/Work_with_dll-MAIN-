using System.IO;
using System.Windows.Forms;

namespace LB1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        // Объект потока ввода
        public StreamReader StRead;
        // Объект потока вывода
        public StreamWriter StWrit;

        public string FileN = "";      // Имя файла данных
        public string FileE = "";      // Расширение файла данных
        public string LineS = "";      // Строка из файла данных
        public int I = 0;              // Счетчик
    }
}