using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form2 fr2 = new Form2(); // Объявление и создание второй формы

        private void InputDataProcedure() // Процедура ввода данных
        {
            openFileDialog1.Filter = "Rtf files(*.rtf)|*.rtf|Txt files(*.txt)|*.txt"; // Установка фильтра для выбора файлов
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // Если нажата кнопка ОК на диалоговой панели
            {
                richTextBox1.Clear(); // Очистка richTextBox1 перед загрузкой нового файла
                fr2.FileN = openFileDialog1.FileName; // Извлечение имени файла данных в Form2
                fr2.FileE = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 3, 3); // Извлечение расширения файла данных
                if ((fr2.FileE == "rtf") | (fr2.FileE == "Rtf") | (fr2.FileE == "RTF")) // Если расширение rtf
                {
                    richTextBox1.LoadFile(fr2.FileN); // Загрузка данных в richTextBox1
                }
                if ((fr2.FileE == "txt") | (fr2.FileE == "Txt") | (fr2.FileE == "TXT")) // Если расширение txt
                {
                    fr2.StRead = new StreamReader(fr2.FileN, Encoding.Default);
                    while ((fr2.LineS = fr2.StRead.ReadLine()) != null) // Цикл до конца файла
                    {
                        richTextBox1.Text = richTextBox1.Text + fr2.LineS + "\n"; // Загрузка строки в richTextBox1
                    }
                    fr2.StRead.Close();
                }
            }
        }

        private void OutputDataProcedure() // Процедура вывода данных
        {
            if (fr2.FileN == "") // Если имени файла нет
            {
                saveFileDialog1.Filter = "Rtf files(*.rtf)|*.rtf|Txt files(*.txt) | *.txt"; // Установка фильтра для выбора файлов
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) // Если нажата кнопка ОК на диалоговой панели
                {
                    if (saveFileDialog1.FilterIndex == 1) // Если расширение rtf
                    {
                        fr2.FileN = saveFileDialog1.FileName; // Извлечение имени файла данных
                        richTextBox1.SaveFile(fr2.FileN); // Загрузка данных из richTextBox1 в файл
                    }
                    if (saveFileDialog1.FilterIndex == 2) // Если  расширение txt
                    {
                        fr2.FileN = saveFileDialog1.FileName; // Извлечение имени файла данных
                        fr2.StWrit = new StreamWriter(fr2.FileN, false, Encoding.Default); // Открытие потока StWrit для вывода
                        fr2.I = 0; // Обнуление счётчика строк
                        while (fr2.I < richTextBox1.Lines.Length) // Цикл до тех пор пока не кончились строки в richTextBox1
                        {
                            fr2.StWrit.WriteLine(richTextBox1.Lines[fr2.I]); // Вывод строк из richTextBox1.Lines[i] в поток вывода
                            fr2.I++; // Наращивание счётчика строк
                        }
                        fr2.StWrit.Close(); // Закрытие потока вывода
                    }
                }
            }
            else // Если имя файла существует
            {
                if ((fr2.FileE == "rtf") || (fr2.FileE == "Rtf") || (fr2.FileE == "RTF")) // Если расширение rtf
                {
                    richTextBox1.SaveFile(fr2.FileN); // Загрузка данных из richTextBox1 в файл
                }
                if ((fr2.FileE == "txt") || (fr2.FileE == "Txt") || (fr2.FileE == "TXT")) // Если расширение txt
                {
                    fr2.StWrit = new StreamWriter(fr2.FileN, false, Encoding.Default); // Открытие потока StWrit для вывода
                    fr2.I = 0; // Обнуление счётчика строк
                    while (fr2.I < richTextBox1.Lines.Length) // Цикл до тех пор пока не кончились строки в richTextBox1
                    {
                        fr2.StWrit.WriteLine(richTextBox1.Lines[fr2.I]); // Вывод строк из richTextBox1.Lines[i] в поток вывода
                        fr2.I++; // Наращивание счётчика строк
                    }
                    fr2.StWrit.Close(); // Закрытие потока вывода
                }
            }
        }

        private void ProcessDataProcedure() // Процедура обработки данных
        {

        }

        private void SaveAsProcedure() // Процедура сохранитьКак
        {
            saveFileDialog1.Filter = "Rtf files(*.rtf)|*.rtf|Txt files(*.txt)|*.txt"; // Установка фильтра для выбора файлов
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // Если нажата кнопка ОК на диалоговой панели
            {
                if (saveFileDialog1.FilterIndex == 1) // Если расширение rtf
                {
                    fr2.FileN = saveFileDialog1.FileName; // Извлечение имени файла данных
                    richTextBox1.SaveFile(fr2.FileN); // Загрузка данных из richTextBox1 в файл
                }
                if (saveFileDialog1.FilterIndex == 2) // Если расширение txt
                {
                    fr2.FileN = saveFileDialog1.FileName; // Извлечение имени файла данных
                    fr2.StWrit = new StreamWriter(fr2.FileN, false, Encoding.Default); // Открытие потока StWrit для вывода
                    fr2.I = 0; // Обнуление счётчика строк
                    while (fr2.I < richTextBox1.Lines.Length) // Цикл до тех пор пока не кончились строки в richTextBox1
                    {
                        fr2.StWrit.WriteLine(richTextBox1.Lines[fr2.I]); // Вывод строк из richTextBox1.Lines[i] в поток вывода
                        fr2.I++; // Наращивание счётчика строк
                    }
                    fr2.StWrit.Close(); // Закрытие потока вывода
                }
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fr2.FileN = ""; // Очистка файла
            richTextBox1.Clear(); // Очистка richTextBox1
            // ProcessDataProcedure();
            fr2.ShowDialog(); // Показ второй формы в модальном режиме
            // fr2.Show(); - Показ второй формы в немодальном режиме
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Закрытие программы
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Вызов процедуры ввода данных
            InputDataProcedure(); // Загрузка данных через процедуру
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ProcessDataProcedure();
            // Вызов процедуры вывода данных
            OutputDataProcedure(); // Сохранение через процедуру
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ProcessDataProcedure();
            // Вызов процедуры сохранитьКак
            SaveAsProcedure(); // сохранитьКак через процедуру
        }
    }
}