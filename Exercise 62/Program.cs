// Задача 62. Заполните спирально массив 4 на 4.

// 4x4 is 4x4
int[,] array = new int[4, 4];

void SpiralArray (int[,] collection)
{
    int value = 1;

    // Filling the outermost cells of the array.
    for (int jndex = 0; jndex < collection.GetLength(0); jndex++)
    {
        collection[0, jndex] = value;
        value++;
    }

    for (int index = 1; index < collection.GetLength(1); index++)
    {
        collection[index, collection.GetLength(0) - 1] = value;
        value++;
    }

    for (int jndex = collection.GetLength(0) - 2; jndex > -1; jndex--)
    {
        collection[collection.GetLength(1) - 1, jndex] = value;
        value++;
    }

    for (int index = collection.GetLength(1) - 2; index > 0; index--)
    {
        collection[index, 0] = value;
        value++;
    }

    // Filling the inner cells of the array.
    int kndex = 1;
    int lndex = 1;
 
    while (value < collection.GetLength(0) * collection.GetLength(1))
    {
        // Go to the right.
        while(collection[kndex, lndex + 1] == 0)
        {
            collection[kndex, lndex] = value;
            value++;
            lndex++;
        }

        // Go down.
        while (collection[kndex + 1, lndex] == 0)
        {
            collection[kndex, lndex] = value;
            value++;
            kndex++;
        }

        // Go to the left. (Без этого цикла у меня решение не сходиться, а программа зависает).
        while (collection[kndex, lndex - 1] == 0)
        {
            collection[kndex, lndex] = value;
            value++;
            lndex--;
        }
    }
    
    // Filling the lost cell of the array (16-th).
    for (int index = 0; index < collection.GetLength(0); index++)
    {
        for (int jndex = 0; jndex <collection.GetLength(1); jndex++)
        {
            if (collection[index, jndex] != 0)
            {
                continue;
            }
            else
            {
                collection[index, jndex] = value;
            }
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

SpiralArray(array);
PrintArray(array);