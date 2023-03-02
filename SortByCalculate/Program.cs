const int SIZE_OF_ARRAY = 1000000;
const int NUB_OF_THREADS = 70;

object lock_obj = new object();

Random randomizer = new Random();
int[] array = new int[SIZE_OF_ARRAY].Select(r => randomizer.Next(1, 100)).ToArray();

// void ShowArray(int[] array)
// {
//     Console.WriteLine($"[{String.Join(", ", array)}]");
// }

//ShowArray(array);
SortArrayByCalculate(array);
//ShowArray(array);

void SortArrayByCalculate(int[] array)
{
    int maxNumb = array.Max();
    int minNumb = array.Min();

    int offset = -minNumb;

    int[] arrayCalculate = new int[maxNumb + offset + 1];

    int eachThreadCalc = SIZE_OF_ARRAY / NUB_OF_THREADS;
    var threadParallels = new List<Thread>();

    for (int i = 0; i < NUB_OF_THREADS; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;

        if (i == NUB_OF_THREADS - 1) endPos = SIZE_OF_ARRAY;

        threadParallels.Add(new Thread(() => CountingSortArray(array, arrayCalculate, offset, startPos, endPos)));
        threadParallels[i].Start();

    }

    foreach (var thread in threadParallels)
    {
        thread.Join();
    }

    int index = 0;
    for (int i = 0; i < arrayCalculate.Length; i++)
    {
        for (int j = 0; j < arrayCalculate[i]; j++)
        {
            array[index] = i - offset;
            index++;
        }
    }
}

void CountingSortArray(int[] array, int[] arrayCalculate, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (lock_obj)
        {
            arrayCalculate[array[i] + offset]++;
        }
    }
}