using System;
using System.Drawing.Printing;

namespace Library
{
    /// <summary>
    /// Класс, представляющий одномерный массив типа <see cref="double"/> с возможностью работы с его элементами.
    /// </summary>
    public class SingleArray
    {
        private double[] _doubleArray;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SingleArray"/> с указанным массивом.
        /// </summary>
        /// <param name="doubleArray">Массив типа <see cref="double"/> для инициализации.</param>
        public SingleArray(double[] doubleArray)
        {
            this._doubleArray = doubleArray;
        }

        /// <summary>
        /// Устанавливает значение элемента массива по индексу.
        /// </summary>
        /// <param name="i">Индекс элемента массива.</param>
        /// <param name="number">Новое значение для элемента.</param>
        public void SetNumber(int i, double number)
        {
            _doubleArray[i] = number;
        }

        /// <summary>
        /// Получает значение элемента массива по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента массива.</param>
        /// <returns>Значение элемента массива.</returns>
        public double GetNumber(int index)
        {
            if (index >= 0 && index < _doubleArray.Length)
            {
                return _doubleArray[index];
            }
            else
            {
                Console.WriteLine("Value error. Please, try again.");
                return 0;
            }
        }

        /// <summary>
        /// Возвращает клонированный массив.
        /// </summary>
        /// <returns>Копия массива типа <see cref="double"/>.</returns>
        public double[] GetArray()
        {
            return (double[])_doubleArray.Clone();
        }

        /// <summary>
        /// Возвращает количество элементов в массиве.
        /// </summary>
        /// <returns>Длина массива.</returns>
        public int GetLength()
        {
            return _doubleArray.Length;
        }

        /// <summary>
        /// Подсчитывает количество отрицательных значений в массиве.
        /// </summary>
        /// <returns>Количество элементов с отрицательными значениями.</returns>
        public int Count()
        {
            int count = 0;
            for (int i = 0; i < _doubleArray.Length; i++)
            {
                if (_doubleArray[i] < 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Подсчитывает количество отрицательных значений в массиве начиная с указанного индекса.
        /// </summary>
        /// <param name="index">Индекс, с которого начинается подсчёт.</param>
        /// <returns>Количество отрицательных значений начиная с указанного индекса.</returns>
        public int Count(int index)
        {
            int count = 0;
            for (int i = index - 1; i < _doubleArray.Length; i++)
            {
                if (_doubleArray[i] < 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Подсчитывает количество значений, которые больше указанного числа, но меньше нуля.
        /// </summary>
        /// <param name="number">Число для сравнения.</param>
        /// <returns>Количество элементов, которые больше <paramref name="number"/> и меньше нуля.</returns>
        public int Count(double number)
        {
            int count = 0;
            for (int i = 0; i < _doubleArray.Length; i++)
            {
                if (_doubleArray[i] > number && _doubleArray[i] < 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Оператор умножения для двух массивов <see cref="SingleArray"/>.
        /// Множит элементы второго массива на соответствующие элементы первого массива.
        /// Возвращает тот массив, который имеет меньший размер.
        /// </summary>
        /// <param name="array_1">Первый массив для умножения.</param>
        /// <param name="array_2">Второй массив для умножения.</param>
        /// <returns>Массив, на котором произошло умножение элементов.</returns>
        public static SingleArray operator *(SingleArray array_1, SingleArray array_2)
        {
            if (array_1.GetLength() >= array_2.GetLength())
            {
                for (int i = 0; i < array_2.GetLength(); i++)
                {
                    array_1.SetNumber(i, (array_1.GetNumber(i) * array_2.GetNumber(i)));
                }
                return array_1;
            }
            else
            {
                for (int i = 0; i < array_1.GetLength(); i++)
                {
                    array_2.SetNumber(i, (array_1.GetNumber(i) * array_2.GetNumber(i)));
                }
                return array_2;
            }
        }

        /// <summary>
        /// Оператор умножения для массива <see cref="SingleArray"/> и числа.
        /// Умножает первые <paramref name="number"/> элементов массива на 1.
        /// </summary>
        /// <param name="array">Массив для умножения.</param>
        /// <param name="number">Число, определяющее количество элементов для умножения на 1.</param>
        /// <returns>Массив с изменёнными элементами.</returns>
        public static SingleArray operator *(SingleArray array, int number)
        {
            if (array.GetLength() >= number)
            {
                for (int i = 0; i < number; i++)
                {
                    array.SetNumber(i, 1);
                }
            }
            else
            {
                Console.WriteLine("Input error. Out of size, try again.");
            }
            return array;
        }
    }
}
