/* Данная программа выполняет сквозную сортировку двумерного прямоугольного массива по возрастанию.
   Исходный массив задается явно с помощью инициализатора коллекции.
   Логики сортировки и вывода массива на печать определены в отдельных методах для смыслового разбиения кода на блоки.
   Программа реализована на основе API массивов без применения функционала LINQ to Objects.
   Сортировка выполняется "на месте" с помощью перезаписи элементов в исходном массиве, т.е. без создания 
   отдельной отсортированной версии. 
   В ходе выполнения создается временный промежуточный массив, как один непрерывный блок всех элементов исходного массива. */

using static System.Console;

namespace CSIntroHomework2
{
    static class Homework2
    {
        static void Main()  //- точка входа в программу с доступом только для CLR; 
                            //  массив для сохранения аргументов командной строки не применяется
        {
            // Явная инициализация массива одним выражением:
            var intGrid = new int[,]
            {
                {7, 3, 2},
                {4, 9, 6},
                {1, 8, 5},
            };

            WriteLine("\nInitial array:");
            Print2DArray<int>(intGrid);

            Sort2DArray<int>(intGrid);
            WriteLine("\nSorted array:");
            Print2DArray<int>(intGrid);
        }

        // Обобщенный метод с открытым доступом для сквозной сортировки. Может использоваться с любым значимым типом
        // (но в данном случае это ограничение необязательно, т.к. метод служит лишь для сортировки):
        public static T[,] Sort2DArray<T>(T[,] array)
            where T: struct 
        {
            var arr = new T[array.Length];  //- временный одномерный массив для хранения всех элементов исходнго
                                            //  двумерного массива
            int index = 0;                  //- индекс временного массива

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    arr[index] = array[i,j];
                    index += 1;
                }
            Array.Sort(arr);    //- сортировка элементов во временном массиве по умолчанию, т.е. по возрастанию,
                                //  не используя пользовательскую логику сортировки
            index = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i,j] = arr[index];
                        index += 1; 
                    }
            return array;
        }

        // Обобщенный метод для вывода на печать двумерного массива:
        public static void Print2DArray<T>(T[,] array)  //- ограничение для T необязательно
        {
            var row = new T[array.GetLength(1)];    //- строка в целевом массиве
            string printRow;                        //- строка для вывода
            
            WriteLine(" [ ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }
                printRow = String.Join(", ", row);
                WriteLine($"   {printRow}");
            }
            WriteLine(" ]");
        }
    } 
}

