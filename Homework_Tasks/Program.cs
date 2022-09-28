/*
Урок 7. Как не нужно писать код. Часть 1 (Домашняя работа)
*/
// Организация завершения работы с модулем
bool CheckExit(dynamic num)
{
    if (num == 0)
    {
        Console.WriteLine("\nРабота с программой завершена, До встречи!\n");
        return true;
    }
    return false;
}

// Создание 1D-массива заполненных случайно сгенерированными целыми числами
int[] CreatRandom1DArray(int size, int minRnd, int maxRnd)
{
    int[] randNumber = new int[size];
    Random int_rnd = new Random();
    int i;
    for (i = 0; i < size; i++)
        randNumber[i] = int_rnd.Next(minRnd, maxRnd + 1);
    return randNumber;
}

// Создание 2D-массива заполненных случайно сгенерированными числами (целыми или вещественными, на выбор)
dynamic[,] CreatRandom2DArray(bool real = false, int oneSize = 1, int twoSize = 2, bool fill = true)
{
    Console.Write("Введите число строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите число столбцов: ");
    int columns = Convert.ToInt32(Console.ReadLine());
    
    dynamic[,] newArray = new dynamic[rows, columns];

    int minValue = 0; int maxValue = 0;
    if (fill)
    {
        Console.Write("Введите минимальное значение элемента: ");
        minValue = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите максимальное значение элемента: ");
        maxValue = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                newArray[i, j] = !real ? new Random().Next(minValue, maxValue + 1) :
                                        minValue + (maxValue - minValue + 1) * 
                                        new Random().NextDouble();
    }
    Console.WriteLine("");
    return newArray;
}

// Вывод содержимого 2D-массива
void Show2dArray(dynamic[,] array, string text = "")
{
    if (text != string.Empty) Console.WriteLine(text);

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]} ");
        Console.WriteLine();
    }
    Console.WriteLine();
}


/*-----------------------------------------------------------------
Задача 47. Задайте двумерный массив размером m×n, 
заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
-------------------------------------------------------------------
*/
// Основное тело программы.
Console.WriteLine(@"Задача-47. Задаем двумерный массив заполненный случайными вещественными числами");
Console.WriteLine("---");
// Console.WriteLine("'0' - для завершения:");

while (true)
{
    dynamic[,] mayArray = CreatRandom2DArray(real: true);
    Show2dArray(mayArray);

    Console.Write("Продолжить (1- ДА, 0 - НЕТ): ");

    if (CheckExit(Convert.ToInt16(Console.ReadLine()))) break;
}
// *** Конец Задачи 47 ***


/*-----------------------------------------------------------------
Задача 50. Напишите программу, которая на вход принимает позиции элемента 
в двумерном массиве, и возвращает значение этого элемента или же указание, 
что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
17 -> такого числа в массиве нет
-------------------------------------------------------------------
*/
string GetElemArray(dynamic[,] array, int row, int column)
{
    return ((row > 0 & row <= array.GetLength(0)) &
            (column >0 & column <= array.GetLength(1))) ?
            $"Элемент массива ({row}, {column}) = {array[row-1, column-1]}" :
            $"такого элемента в массиве на позиции ({row}, {column}) НЕТ";
    // return strElemArray;
}

// Основное тело программы.
Console.WriteLine(@"Задача-50. Выдача элемента массива по запросу позиции нахождения его");
Console.WriteLine("---");

dynamic[,] mayArray2 = CreatRandom2DArray();
Show2dArray(mayArray2);

while (true)
{
    Console.Write($"Укажите номер строки запрашиваемой позиции (от {1} до {mayArray2.GetLength(0)}): ");
    int row = Convert.ToInt32(Console.ReadLine());
    Console.Write($"Укажите номер колонгки запрашиваемой позиции(от {1} до {mayArray2.GetLength(1)}): ");
    int column = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(GetElemArray(mayArray2, row, column));
    Console.WriteLine("");

    Console.Write("Продолжить (1- ДА, 0 - НЕТ): ");
    if (CheckExit(Convert.ToInt16(Console.ReadLine()))) break;
    Console.WriteLine("");
}
// *** Конец Задачи 50 ***


/*-----------------------------------------------------------------
Задача 52. Задайте двумерный массив из целых чисел. 
Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
-------------------------------------------------------------------
*/
void GetAverageColumns(dynamic[,] array)
{
    string strAverageColumns = string.Empty;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        double amountBy = 0;
        for (int j = 0; j < array.GetLength(0); j++)
            amountBy += array[j, i];
        strAverageColumns += $"{Math.Round(amountBy/array.GetLength(0),2).ToString("0.###")} ";
    }
    Console.WriteLine(strAverageColumns);
    return;
}


// Основное тело программы.
Console.WriteLine(@"Задача-52. Расчет среднего арифметического элементов в каждом столбце массива");
Console.WriteLine("---");

while (true)
{
    dynamic[,] mayArray = CreatRandom2DArray();
    Show2dArray(mayArray);

    GetAverageColumns(mayArray);
    Console.WriteLine("");

    Console.Write("Продолжить (1- ДА, 0 - НЕТ): ");
    if (CheckExit(Convert.ToInt16(Console.ReadLine()))) break;
    Console.WriteLine("");
}
// *** Конец Задачи 52 ***
