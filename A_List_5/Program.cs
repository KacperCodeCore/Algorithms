global using A_List_5;
using System.Diagnostics;

public class Program
{
    public static int t = 0;
    public static Stopwatch stopwatch = new Stopwatch();
    protected static void Main()
    {
        Console.WriteLine("------------Nowy-----------");
        Console.WriteLine("ktory algorytm chcesz uzyc?");
        Console.WriteLine("(4)MergeSort");
        Console.WriteLine("(5)HoareSort");
        Console.WriteLine("(6)Algorytm");
        int presentSort = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("podaj jak dlugi ma byc ciag:");
        int range = Convert.ToInt32(Console.ReadLine());
        if (range < 0)
        {
            range = 0;
        }

        Console.WriteLine("podaj ile liczb ma być wprowadzonych przez ciebie:");
        int myArrayNumbers = Convert.ToInt32(Console.ReadLine());
        if (myArrayNumbers > range)
        {
            myArrayNumbers = range;
        }

        int[] array1 = new int[range];
        for (int i = 0; i < myArrayNumbers; i++)
        {
            Console.Write("podaj swoja liczbe: ");
            array1[i] = Convert.ToInt32(Console.ReadLine());
        }

        var random = new Random();

        for (int i = myArrayNumbers; i < range; i++)
        {
            array1[i] = random.Next(0, 10*range);
        }  

        Console.WriteLine("----------");
        int finalLength = range;
        if (finalLength > 50)
        {
            finalLength = 50;
        }
        for (int i = 0; i < finalLength; i++)
        {
            Console.WriteLine(i + ".  " + array1[i]);
        }
        Console.WriteLine("----------");


        switch (presentSort)
        {
            case 4:
                stopwatch.Reset();
                stopwatch.Start();
                array1 = L4_MergeSort.DoMergeSort(array1); 
                stopwatch.Stop();
                WriteTab(finalLength, array1);
                Console.WriteLine("C = " + (t / (range * Math.Log2(range))));
                Console.WriteLine("n = " + range);
                Console.WriteLine("t = " + t);
                Console.WriteLine("czas obliczen: " + stopwatch.ElapsedMilliseconds + "[ms]");
                break; //##############################################################################################
            case 5:
                Console.WriteLine("podaj k. co do wielkości elemenkt ciągu:");
                int k = range - (Convert.ToInt32(Console.ReadLine()));
                stopwatch.Reset();
                stopwatch.Start();
                k = L5_HoareSort.DoHoare(array1, k);
                stopwatch.Stop();
                Console.WriteLine("wygrany element k. to: " + k);

                Console.WriteLine("t/n = " + (Convert.ToDouble(t) / Convert.ToDouble(range)));
                Console.WriteLine("czas obliczen: "+ stopwatch.ElapsedMilliseconds+ "[ms]");
                break;
        }

        Console.WriteLine();
        Console.WriteLine("kontynuować?");
        Console.WriteLine("(1) tak");
        Console.WriteLine("(0) nie");
        int next = Convert.ToInt32(Console.ReadLine());
        if (next == 1)
        {
            Console.WriteLine();
            Console.WriteLine();
            Main();
        }

    }
    private static void WriteTab(int finalLength, int[] array1)
    {
        Console.WriteLine("");
        for (int i = 0; i < finalLength; i++)
        {
            Console.WriteLine(i + ".  " + array1[i]);
        }
        Console.WriteLine("----------");
    }

    public static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }
}

