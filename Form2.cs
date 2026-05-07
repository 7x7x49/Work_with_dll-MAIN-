using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Reflection; // Пространство имен для извлечения сведений о сборках в управляемом коде

namespace LB1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); // Инициализация компонентов
        }

        // Объекты потоков ввода/вывода
        public StreamReader StRead; // Объект потока ввода
        public StreamWriter StWrit; // Объект потока вывода

        public string FileN = ""; // Имя файла данных
        public string FileE = ""; // Расширение файла данных
        public string LineS = ""; // Строка из файла данных
        public int I = 0; // Счётчик

        public double
            MaxX = new double(), // Максимальное значение аргумента Х
            MinX = new double(), // Минимальное значение аргумента X
            MaxY = new double(), // Максимальное значение аргумента Y
            MinY = new double(), // Минимальное значение аргумента Y
            ShagX = new double(), // Шаг изменения аргумента X
            ShagY = new double(); // Шаг изменения аргумента Y

        public int
            NN = new int(), // Размерность цикла
            J = new int(),  // Счётчик цикла
            TH = new int(); // Количество потоков

        public double[]
            PXT = new double[0], // Массив аргументов X
            PYT = new double[0]; // Массив аргументов Y

        public double[,]
            PZT = new double[0, 0]; // Массив значений функции Z

        public DateTime
            BT = new DateTime(), // Время начала процесса
            FT = new DateTime(); // Время окончания процесса

        public TimeSpan
            ST = new TimeSpan(); // Длительность процесса

        // Объявление массивов объектов для динамического создания потоков
        public ThreadWithState[] tstat = new ThreadWithState[0]; // Объявление массива объектов tstat класса ThreadWithState
        public Thread[] thred = new Thread[0]; // Объявление массива объектов thred класса Thread

        // Процедура ввода данных
        private void InputDataProcedure()
        {
            MinX = Convert.ToDouble(tbMinX.Text); // Ввод минимального значения Х
            MaxX = Convert.ToDouble(tbMaxX.Text); // Ввод максимального значения Х
            MinY = Convert.ToDouble(tbMinY.Text); // Ввод минимального значения Y
            MaxY = Convert.ToDouble(tbMaxY.Text); // Ввод максимального значения Y
            NN = Convert.ToInt32(tbNN.Text);      // Ввод размерности массивов
            TH = Convert.ToInt32(tbCountStream.Text); // Ввод количества потоков
        }

        // Процедура подготовки прогресс-бара (закомментирована, так как обращение из потока невозможно)
        private void PrepareProgressBarProcedure()
        {
            /*
            if (NN <= 100) // Если размер массивов меньше или равен 100
            {
                progressBar.Maximum = 100; // Формирование максимального значения полосы прогресса
                progressBar.Step = 1; // Формирование шага значения полосы прогресса
            }

            if (NN > 100) // Если размер массивов больше 100
            {
                progressBar.Maximum = NN; // Формирование максимального значения полосы прогресса
                progressBar.Step = Convert.ToInt32(NN / 100); // Формирование шага значения полосы прогресса
            }

            progressBar.Minimum = 0; // Формирование минимального значения полосы прогресса
            progressBar.Value = 0; // Установка текущего значения полосы прогресса в 0
            */
        }

        // Процедура отображения времени (закомментирована, так как обращение из потока невозможно)
        private void ShowTimeProcedure()
        {
            /*
            labelBegin.Text = BT.Hour.ToString() + ":" + BT.Minute.ToString() + ":"
                         + BT.Second.ToString() + ":" + BT.Millisecond.ToString();
            // Формирование строки времени начала процесса

            labelEnd.Text = FT.Hour.ToString() + ":" + FT.Minute.ToString() + ":"
                         + FT.Second.ToString() + ":" + FT.Millisecond.ToString();
            // Формирование строки времени окончания процесса

            ST = FT - BT; // Вычисление длительности процесса
            labelTime.Text = ST.Hours.ToString() + ":" + ST.Minutes.ToString() + ":"
                         + ST.Seconds.ToString() + ":" + ST.Milliseconds.ToString();
            // Формирование строки длительности процесса
            */
        }

        // Процедура вызова библиотеки LibraryCS.dll
        private void CallLibraryCSProcedure(int NN, int TH, double MinX, double MaxX, double MinY, double MaxY)
        {
            Assembly aDll = Assembly.Load("LibraryCS"); // Создание объекта aDll класса Assembly и загрузка сборки LibraryCS.dll
            Type tDll = aDll.GetType("LibraryCS.ClassDll"); // Доступ объекта tDll к классу ClassDll в библиотеке LibraryCS
            object oDll = Activator.CreateInstance(tDll); // Класс Activator создает тип объекта, а метод CreateInstance - объект класса ClassDll. null - параметры конструктора
            MethodInfo mDll = tDll.GetMethod("DllCallCS"); // Выполнение поиска метода DllCallCS класса ClassDll
            object[] args = new object[] { NN, TH, MinX, MaxX, MinY, MaxY }; // Объект args, содержащий аргументы для передачи в вызываемый метод DllCallCS
            mDll.Invoke(oDll, args); // Вызов метода DllCallCS и передача туда списка аргументов args
        }

        // Функция обратного вызова
        public static void tcallRes(int cNN, int cTH, double[] cXT, double[] cYT, double[,] cZT)
        {
            // Объявление локальных атрибутов для вывода данных в файл
            DateTime BTcb = new DateTime(); // Время начала процесса
            string FileNcb = "", // Имя файла данных
                   LineScb = ""; // Строка из файла данных
            StreamWriter StWritcb; // Объект потока вывода
            int Icb = new int(), // Счётчик цикла
                Jcb = new int(); // Счётчик цикла

            // Формирование имени файла данных с номером потока
            FileNcb = "D://A_cb_" + cTH.ToString() + ".txt"; // Формирование имени файла данных

            // Открытие потока StWritcb для вывода
            StWritcb = new StreamWriter(FileNcb, false, System.Text.Encoding.Default); // Открытие потока StWritcb для вывода

            // Создание объекта BTcb время начала процесса класса DateTime
            BTcb = DateTime.Now; // Создание объекта BTcb время начала процесса класса DateTime

            // Формирование строки времени
            LineScb = BTcb.Year.ToString() + "." + BTcb.Month.ToString() + "." +
                      BTcb.Day.ToString() + ", " + BTcb.Hour.ToString() + ":" +
                      BTcb.Minute.ToString() + ":" + BTcb.Second.ToString() + ":" +
                      BTcb.Millisecond.ToString();

            // Вывод строки в поток вывода
            StWritcb.WriteLine(LineScb); // Вывод строки в поток вывода

            // Вывод номера потока для наглядности
            StWritcb.WriteLine("Поток: " + cTH.ToString()); // Вывод номера потока

            // Цикл вывода данных в файл для массива X
            LineScb = "PXT: "; // Инициализация строки
            Icb = 0; // Обнуление счётчика по массиву аргументов X
            while (Icb < cNN) // Цикл до конца массива аргументов Х
            {
                // Занесение значения аргумента Х в строку
                LineScb = LineScb + cXT[Icb].ToString() + "; "; // Занесение значения аргумента Х в строку
                Icb++; // Наращивание счётчика
            }
            // Вывод строки в поток вывода
            StWritcb.WriteLine(LineScb + "\n"); // Вывод строки в поток вывода

            // Цикл вывода данных в файл для массива Y
            LineScb = "PYT: "; // Инициализация строки
            Icb = 0; // Обнуление счётчика по массиву аргументов Y
            while (Icb < cNN) // Цикл до конца массива аргументов Y
            {
                // Занесение значения аргумента Y в строку
                LineScb = LineScb + cYT[Icb].ToString() + "; "; // Занесение значения аргумента Y в строку
                Icb++; // Наращивание счётчика
            }
            // Вывод строки в поток вывода
            StWritcb.WriteLine(LineScb + "\n"); // Вывод строки в поток вывода

            // Цикл вывода в файл значений функции
            LineScb = "PZT: "; // Инициализация строки
            Icb = 0; // Обнуление счётчика строк
            while (Icb < cNN) // Цикл до конца массива значений функции
            {
                Jcb = 0; // Обнуление счётчика столбцов
                while (Jcb < cNN) // Цикл до конца массива значений функции
                {
                    LineScb = LineScb + cZT[Icb, Jcb].ToString() + "; "; // Занесение значения функции в строку
                    Jcb++; // Наращивание счётчика столбцов
                }
                // Вывод строки в поток вывода
                StWritcb.WriteLine(LineScb); // Вывод строки в поток вывода
                LineScb = " "; // Инициализация строки
                Icb++; // Наращивание счётчика строк
            }

            // Закрытие потока вывода
            StWritcb.Close(); // Закрытие потока вывода
        }

        // Обработчик кнопки "Начать"
        private void buttonBegin_Click(object sender, EventArgs e)
        {
            // <Предварительно закомментировав все остальные операторы>
            /*
            // Время начала процесса
            BT = DateTime.Now;

            // Процедура подготовки прогресс-бара (закомментирована)
            PrepareProgressBarProcedure();

            tstat = new ThreadWithState[TH]; // Создание массива объектов tstat класса ThreadWithState
            thred = new Thread[TH]; // Создание массива объектов thred класса Thread

            // Цикл создания потоков
            I = 0; // Обнуление счётчика потоков
            while (I < TH) // Цикл до конца массива потоков
            {
                // Создание объекта tstat[I] класса ThreadWithState и передача в конструктор параметров (NN, MinX, MaxX, MinY, MaxY, I+1, tcallRes)
                tstat[I] = new ThreadWithState(NN, MinX, MaxX, MinY, MaxY, I + 1, new ThreadCallBack(tcallRes));
                // Создание объекта thred[I] класса Thread и запуск рабочей функции потока ThreadDoWork
                thred[I] = new Thread(new ThreadStart(tstat[I].ThreadDoWork));
                I++; // Наращивание счётчика
            }

            // Цикл запуска потоков
            I = 0; // Обнуление счётчика потоков
            while (I < TH) // Цикл до конца массива потоков
            {
                thred[I].Start(); // Запуск потока thred[I]
                thred[I].Join();  // Приостановка главного потока программы и ожидание завершения потока thred[I]
                I++; // Наращивание счётчика
            }

            // Цикл завершения потоков
            try // Начало секции обработки исключительной ситуации
            {
                I = 0; // Обнуление счётчика потоков
                while (I < TH) // Цикл до конца массива потоков
                {
                    thred[I].Abort(); // Завершение работы потока thred[I]
                    I++; // Наращивание счётчика
                }
            }
            catch (ThreadAbortException) // Исключение, вызванное ошибкой при завершении потока
            {
                // Обработка любой исключительной ситуации
            }

            // После завершения всех потоков фиксируем время окончания
            FT = DateTime.Now;

            // Процедура отображения времени (закомментирована)
            ShowTimeProcedure();

            // Устанавливаем прогресс-бар на максимум (закомментировано)
            // progressBar.Value = progressBar.Maximum;
            // progressBar.Refresh();
            */

            // Процедура ввода данных
            InputDataProcedure();

            // Вызов новой процедуры
            CallLibraryCSProcedure(NN, TH, MinX, MaxX, MinY, MaxY);
        }

        // Обработчик кнопки "Выход"
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close(); // Закрытие формы
        }
    }
}