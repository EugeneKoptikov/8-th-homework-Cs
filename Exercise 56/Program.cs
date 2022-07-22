// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.

// Input
Console.WriteLine("Input size of rows (m): ");
string m = Console.ReadLine();
int rows = Number(m);
Console.WriteLine("Input size of columns (n): ");
string n = Console.ReadLine();
int columns = Number(n);

// The method for checking input values.
int Number(string str)
{
    int number = 0;
    string textBufer = string.Empty;
    
    while (number <= 0)
    {
        bool v = false;

        while (v == false)
        {
            int index = 0;
  
            while (index < str.Length)
            {
                char symbol = str[index];

                if( symbol == '1' || symbol == '2' || symbol == '3' || symbol == '4' || 
                    symbol == '5' || symbol == '6' || symbol == '7' || symbol == '8' || 
                    symbol == '9' || symbol == '0')
                {
                    textBufer = textBufer + symbol;
                }

                index++;    
            }

            if (textBufer.Length < str.Length)
            {
                Console.WriteLine("Input only number greater than zero, again:");
                v = false;
                str = Console.ReadLine();
                
            }
            
            if (textBufer.Length == str.Length)
            {
                v = true;
                number = Convert.ToInt32(str);
                 
            }
        }

        if (number == 0)
        {
            Console.WriteLine("Input number greater than zero, again:");
            v = false;
            str = Console.ReadLine();
        }
    }
    return number;
}

// An array initialization and filling it.
int[,] array = new int[rows, columns];

void RandomFillArray(int[,] collection)
{
    for (int index = 0; index < collection.GetLength(0); index++)
    {
        for (int jndex = 0; jndex < collection.GetLength(1); jndex++)
        {
            collection[index, jndex] = new Random().Next(0, 100);
        }
    }
}

// Printing the array.
void PrintArray(int[,] collection)
{
    for (int index = 0; index < collection.GetLength(0); index++)
    {
        for (int jndex = 0; jndex < collection.GetLength(1); jndex++)
        {
            if (jndex == 0)
            {
                Console.Write("[");
            }

            Console.Write(collection[index, jndex]);

            if (jndex < collection.GetLength(1) - 1)
            {
                Console.Write(", ");
            }

            if (jndex == collection.GetLength(1) - 1)
            {
                Console.Write("]");
                Console.WriteLine("");
            }
        }
    }
}

// Finding an answer.
void MinSumElementsInRows(int[,] collection)
{
    int rememberRow = 0;
    double minSum = 0;
    double sumRow = 0;
    double sum0 = 0;
    for (int index = 0; index < 1; index++)
    {
        for (int jndex = 0; jndex < collection.GetLength(1); jndex++)
        {
            sum0 = sum0 + collection[index, jndex];
        }

        sum0 = sum0 / collection.GetLength(1);
    
        minSum = sum0;
        rememberRow = index;
    }   

    for (int index = 1; index < collection.GetLength(0); index++)
    {
        sumRow  = 0;

        for (int jndex = 0; jndex < collection.GetLength(1); jndex++)
        {
            sumRow = sumRow + collection[index, jndex];
        }

        sumRow = sumRow / collection.GetLength(1);

        if (minSum > sumRow)
        {
            minSum = sumRow;
            rememberRow = index;
        }    
       
    }

    if (rememberRow == 0)
    {
        Console.WriteLine("Answer: " + $"{rememberRow + 1}" + "-st row.");
    }
    else if (rememberRow == 1)
    {
        Console.WriteLine("Answer: " + $"{rememberRow + 1}" + "-nd row.");
    }
    else
    {
        Console.WriteLine("Answer: " + $"{rememberRow + 1}" + "-th row.");
    }
}

RandomFillArray(array);
PrintArray(array);
MinSumElementsInRows(array);