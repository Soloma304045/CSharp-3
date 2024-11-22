using Library;
using System.Linq;

class Program
{
    static void Main()
    {
        SingleArray A = new SingleArray([1, 1, 1]);
        SingleArray B = new SingleArray([1, 1, 1]);
        SingleArray C = new SingleArray([1, 1, 1]);
        SingleArray dataArr = new SingleArray([1, 1, 1]);
        bool endIsNear = false;
        bool bule = false;
        string input;
        int i;
        int size;
        List<double> list = new List<double>();
        double[] data = new double[500];
        for (i = 0; i < data.Length; i += 10)
        {
            data[i] = 1.0;
        }
        while(!endIsNear)
        {
            Console.WriteLine("1. Задать массив");
            Console.WriteLine("2. Данные массивов");
            Console.WriteLine("3. Число отрицательных элементов A*C");
            Console.WriteLine("4. Число отрицательных элементов в A и C после заданного индекса");
            Console.WriteLine("5. Создание массива с условием");
            Console.WriteLine("6. Выход");
            input = Console.ReadLine();
            if(input != null)
            {
                switch(input)
                {
                    case "1":
                    {
                        Console.WriteLine("Выберите массив для задания значений");
                        Console.WriteLine("A, B, C");
                        input = Console.ReadLine();
                        Console.WriteLine("Укажите размер массива");
                        size = int.Parse(Console.ReadLine());
                        switch(input.ToUpper())
                        {
                            case "A":
                            {
                                for(i=0;i<size;i++)
                                {
                                    Console.WriteLine($"Введите {i+1} элемент массива: ");
                                    list.Add(double.Parse(Console.ReadLine()));
                                }
                                A = new SingleArray(list.ToArray());
                                list.Clear();
                                break;
                            }
                            case "B":
                            {
                                for(i=0;i<size;i++)
                                {
                                    Console.WriteLine($"Введите {i+1} элемент массива: ");
                                    list.Add(double.Parse(Console.ReadLine()));
                                }
                                B = new SingleArray(list.ToArray());
                                list.Clear();
                                break;
                            }
                            case "C":
                            {
                                for(i=0;i<size;i++)
                                {
                                    Console.WriteLine($"Введите {i+1} элемент массива: ");
                                    list.Add(double.Parse(Console.ReadLine()));
                                }
                                C = new SingleArray(list.ToArray());
                                list.Clear();
                                break;
                            }
                        }
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine($"A - {string.Join("; ", A.GetArray())}");
                        Console.WriteLine($"B - {string.Join("; ", B.GetArray())}");
                        Console.WriteLine($"C - {string.Join("; ", C.GetArray())}");
                        break;
                    }
                    case "3":
                    {
                        dataArr = A * C;
                        Console.WriteLine($"Число отрицательных элементов - {dataArr.Count()}");
                        break;
                    }
                    case "4":
                    {
                        Console.WriteLine("Введите индекс: ");
                        size = int.Parse(Console.ReadLine());
                        dataArr = A * C;
                        Console.WriteLine($"Число отрицательных элементов - {dataArr.Count(size)}");
                        break;
                    }
                    case "5":
                    {
                        dataArr = A * B;
                        if(dataArr.Count() > 0)
                        {
                            for(i=0;i<dataArr.GetLength();i++)
                            {
                                if(dataArr.GetNumber(i) < -5.3)
                                {
                                    bule = true;
                                }
                            }
                        }
                        if(bule)
                        {
                            C = new SingleArray(data);
                        }
                        bule = false;
                        break;
                    }
                    case "6":
                    {
                        endIsNear = true;
                        break;
                    }
                    case "7":
                    {
                        A *= A * 3;
                        Console.WriteLine(string.Join("; ", A.GetArray()));
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Input error. Please, try again.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error. Null input, try again.\n");
            }
        }
    }
}
