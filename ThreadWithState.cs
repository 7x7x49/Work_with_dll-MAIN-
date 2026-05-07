using System;
using System.IO;
using System.Threading;

namespace LB1
{
    // Делегат для обратного вызова с номером потока
    public delegate void ThreadCallBack(int cNN, int cTH, double[] cXT, double[] cYT, double[,] cZT);

    public class ThreadWithState
    {
        private double
            sMaxX = new double(), // Максимальное значение аргумента Х
            sMinX = new double(), // Минимальное значение аргумента X
            sMaxY = new double(), // Максимальное значение функции Y
            sMinY = new double(), // Минимальное значение функции Y
            sShagX = new double(), // Шаг изменения аргументов X
            sShagY = new double(); // Шаг изменения аргументов Y

        private double[]
            sXT = new double[0], // Массив аргументов X
            sYT = new double[0]; // Массив аргументов Y

        private double[,]
            sZT = new double[0, 0]; // Массив значений функции

        private int
            sNN = new int(), // Размерность массивов
            I = new int(), // Счётчик цикла
            J = new int(), // Счётчик цикла
            sTH = new int(); // Номер потока

        public DateTime
            BT1 = new DateTime(), // Время начала процесса
            FT1 = new DateTime(); // Время окончания процесса

        public TimeSpan ST1 = new TimeSpan(); // Длительность процесса

        private ThreadCallBack tcall; // Объект делегата

        // Конструктор класса
        public ThreadWithState(int zNN, double zMinX, double zMaxX, double zMinY, double zMaxY, int zTH, ThreadCallBack tcallD)
        {
            sNN = zNN; // Размер массивов аргументов и значений функции
            sMinX = zMinX; // Минимальное значение аргумента X
            sMaxX = zMaxX; // Максимальное значение аргумента Х
            sMinY = zMinY; // Минимальное значение аргумента Y
            sMaxY = zMaxY; // Максимальное значение аргумента Y
            sTH = zTH; // Номер потока
            tcall = tcallD; // Сохраняем ссылку на делегат
        }

        // Рабочая функция потока
        public void ThreadDoWork()
        {
            BT1 = DateTime.Now; // Создание объекта BT - Время начала процесса класса DateTime

            // Выделение памяти для указателей
            sXT = new double[sNN]; // Выделение памяти для массива аргументов X
            sYT = new double[sNN]; // Выделение памяти для массива аргументов Y
            sZT = new double[sNN, sNN]; // Выделение памяти для массива значений функции

            // Модифицируем диапазон X: прибавляем номер потока к максимальному значению
            double currentMaxX = sMaxX + sTH; // Текущее максимальное значение Х с учётом номера потока
            double currentMinX = sMinX; // Минимальное значение Х оставляем без изменений

            sShagX = (currentMaxX - currentMinX) / (sNN - 1); // Формирование шага изменения аргумента Х с учётом номера потока
            sShagY = (sMaxY - sMinY) / (sNN - 1); // Формирование шага изменения аргумента Y

            sXT[0] = currentMinX; // Первое значение в массиве аргументов X
            sYT[0] = sMinY; // Первое значение в массиве аргументов Y

            // Цикл для формирования массива аргументов функции
            I = 1; // Начальное значение счётчика цикла
            while (I <= sNN - 1) // Цикл по массиву аргументов
            {
                sXT[I] = sXT[I - 1] + sShagX;   // Формирование элементов массива аргументов X
                sYT[I] = sYT[I - 1] + sShagY;   // Формирование элементов массива аргументов Y
                I++; // Наращивание значения счётчика цикла
            }

            // Вычисление значений функции
            I = 0; // Обнуление счётчика по массиву аргументов X
            while (I <= sNN - 1) // Цикл по массиву аргументов X
            {
                J = 0; // Обнуление счётчика столбцов
                while (J <= sNN - 1) // Цикл по массиву аргументов Y
                {
                    // Вычисление заданной функции: z = e^x * sqrt(1 - e^(2x)) + arcsin(y)
                    sZT[I, J] = Math.Exp(sXT[I]) * Math.Sqrt(1 - Math.Exp(2 * sXT[I])) + Math.Asin(sYT[J]);
                    J++; // Наращивание значения счётчика цикла
                }
                I++; // Наращивание значения счётчика цикла
            }

            tcall(sNN, sTH, sXT, sYT, sZT); // Вызов объекта делегата и передача туда массивов sXT, sYT, sZT, размерности sNN и номера потока sTH
        }
    }
}