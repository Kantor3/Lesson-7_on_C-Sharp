/*
Урок 7 Как не нужно писать код. Часть 1 (Семинар)
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

int[,] CreatRandom2DArray(int oneSize = 1, int twoSize = 2, bool fill = true)
{
    Console.Write("Введите число строк: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите число столбцов: ");
    int columns = Convert.ToInt32(Console.ReadLine());

    int minValue = 0; int maxValue = 0;
    if (fill)
    {
        Console.Write("Введите минимальное значение элемента: ");
        minValue = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите максимальное значение элемента: ");
        maxValue = Convert.ToInt32(Console.ReadLine());
    }
 
    int[,] newArray = new int[rows, columns];

    if (fill)
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                newArray[i, j] = new Random().Next(minValue, maxValue + 1);

    Console.WriteLine("");
    return newArray;
}

void Show2dArray(int[,] array, string text = "")
{
    if (text != string.Empty) Console.WriteLine(text);

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}


/*-----------------------------------------------------------------
Задача. Задайте двумерный массив размером m×n, 
заполненный случайными целыми числами.
Напишите программу ...
-------------------------------------------------------------------
*/
// int[,] mayArray = CreatRandom2DArray();
// Show2dArray(mayArray);
// *** Конец Задачи ... ***


/*-----------------------------------------------------------------
Задача 45. Задайте двумерный массив размера m на n, 
каждый элемент в массиве находится по формуле: Aij = i+j. 
Выведите полученный массив на экран.
-------------------------------------------------------------------
*/
int[,] ChangeArray2(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = (i+1) + (j+1);

    return array;
}

// Основное тело программы.
Console.WriteLine(@"Задача-45. Заполняем массив элементами значениями = сумме индексов элемента");
Console.WriteLine("---");
// Console.WriteLine("'0' - для завершения:");

while (true)
{
    int[,] mayArray2 = CreatRandom2DArray(fill: false);
    Show2dArray(ChangeArray2(mayArray2), "Результирующий маасив:");

    Console.Write("Продолжить (1- ДА, 0 - НЕТ): ");
    
    if (CheckExit(Convert.ToInt16(Console.ReadLine()))) break;
    Console.WriteLine("");
}
// *** Конец Задачи 45 ***


/*--------------------------------------------------------------------
Задача 46. Задайте двумерный массив. Найдите элементы, 
у которых оба индекса чётные, и замените эти элементы на их квадраты.
----------------------------------------------------------------------
*/

int[,] ChangeArray3(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i +=2)
        for (int j = 0; j < array.GetLength(1); j +=2)
            array[i, j] *= array[i, j];

    return array;
}

// Основное тело программы.
Console.WriteLine(@"Задача-46. Заменяем элементы с четными индесами их квадратами");
Console.WriteLine("---");
// Console.WriteLine("'0' - для завершения:");

while (true)
{
    int[,] mayArray3 = CreatRandom2DArray(fill: true);
    Show2dArray(mayArray3, "Исходный маасив:");
    Show2dArray(ChangeArray3(mayArray3), "Результирующий маасив:");

    Console.Write("Продолжить (1- ДА, 0 - НЕТ): ");
    
    if (CheckExit(Convert.ToInt16(Console.ReadLine()))) break;
    Console.WriteLine("");
}
// *** Конец Задачи 46 ***


/*--------------------------------------------------------------------
Задача 47. Задайте двумерный массив. Найдите сумму элементов, 
находящихся на главной диагонали (с индексами (0,0); (1;1) и т.д.
----------------------------------------------------------------------
*/

int SummElemMD(int[,] array)
{
    int summElem = 0;
    for (int i = 0; i < Math.Min(array.GetLength(0), array.GetLength(1)); i++)
        summElem += array[i, i];

    return summElem;
}

// Основное тело программы.
Console.WriteLine(@"Задача-47. Находим сумму элементов главной диагонали:");
Console.WriteLine("---");
// Console.WriteLine("'0' - для завершения:");

while (true)
{
    int[,] mayArray4 = CreatRandom2DArray(fill: true);
    Show2dArray(mayArray4, "Исходный маасив:");
    Console.WriteLine($"Сумма элементов главной диагонали = {SummElemMD(mayArray4)}");
 
    Console.Write("Продолжить (1- ДА, 0 - НЕТ): ");
    
    if (CheckExit(Convert.ToInt16(Console.ReadLine()))) break;
    Console.WriteLine("");
}
// *** Конец Задачи 47 ***
