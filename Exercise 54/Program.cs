// Задача 54: Задайте двумерный массив. 
// Напишите программу, которая упорядочит по убыванию элементы 
// каждой строки двумерного массива.

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

void SortElementsInRows(int[,] collection)
{
    
    for (int index = 0; index < collection.GetLength(0); index++)
    {
        int buffer;
        for (int jndex = 0; jndex < collection.GetLength(1); jndex++)
        {
           
            // The array sorting algorithm. 
            for (int kndex = 0; kndex < collection.GetLength(1) - jndex - 1; kndex++)
            {
                if (collection[index, kndex] < collection[index, kndex + 1])
                {
                    
                    buffer = collection[index, kndex + 1];
                    collection[index, kndex + 1] = collection[index, kndex];
                    collection[index, kndex] = buffer;
                }
            }
        }
    }
}

RandomFillArray(array);
PrintArray(array);
SortElementsInRows(array);
Console.WriteLine("");
PrintArray(array);