using System;
using System.Collections.Generic;

namespace Home_0210
{
    class Program
    {
        static List<List<int>> edgesWays = new List<List<int>>();
        static void Main(string[] args)
        {
            int[][] edgesOfv;
            List<int[]> edges = new List<int[]>();
            int[] weights;
            string[] str;
            int[] numbers;
            Random rnd = new Random();
            
            Console.WriteLine("Быстрая сортировка\nВведите целые числа через пробел:");
        Start1:
            try
            {
                str = Console.ReadLine().Split();
                numbers = new int[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(str[i]);
                }
                SortStep(numbers, 0, numbers.Length - 1);
                Console.WriteLine(String.Join(" ", numbers));
            }
            catch (FormatException)
            {
                Console.WriteLine("Ещё раз");
                goto Start1;
            }
            
            Console.WriteLine($"\nОбход графа в глубину от вершины 0 к вершине 9.\n");            
            edgesOfv = new int[10][];
            edgesOfv[0] = new int[] { 1, 2, 3 };
            edgesOfv[1] = new int[] { 0, 4, 6 };
            edgesOfv[2] = new int[] { 0, 4, 5, 7 };
            edgesOfv[3] = new int[] { 0, 5, 8 };
            edgesOfv[4] = new int[] { 1, 2, 6, 7 };
            edgesOfv[5] = new int[] { 2, 3, 8 };
            edgesOfv[6] = new int[] { 1, 4, 9 };
            edgesOfv[7] = new int[] { 2, 4, 8, 9 };
            edgesOfv[8] = new int[] { 3, 5, 7, 9 };
            edgesOfv[9] = new int[] { 6, 7, 8 };
            edges.Add(new int[] { 0, 1 });
            edges.Add(new int[] { 0, 2 });
            edges.Add(new int[] { 0, 3 });
            edges.Add(new int[] { 1, 4 });
            edges.Add(new int[] { 1, 6 });
            edges.Add(new int[] { 2, 4 });
            edges.Add(new int[] { 2, 5 });
            edges.Add(new int[] { 2, 7 });
            edges.Add(new int[] { 3, 5 });
            edges.Add(new int[] { 3, 8 });
            edges.Add(new int[] { 4, 6 });
            edges.Add(new int[] { 4, 7 });
            edges.Add(new int[] { 5, 8 });
            edges.Add(new int[] { 6, 9 });
            edges.Add(new int[] { 7, 8 });
            edges.Add(new int[] { 7, 9 });
            edges.Add(new int[] { 8, 9 });
            Console.WriteLine("Длины всех ребёр равны:");
            weights = new int[17];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = rnd.Next(1, 21);
                Console.WriteLine($"{String.Join(" -> ", edges[i])}: {weights[i]}");
            }
            Console.WriteLine("\nПеребор всех возможных путей и их суммарная длина:");
            GraphStep(edgesOfv, 0, 0);
            for(int i = 0; i < edgesWays.Count; i++)
            {
                if(edgesWays[i][edgesWays[i].Count - 1] != 9)
                {
                    edgesWays.Remove(edgesWays[i]);
                    i--;
                }
            }
            int sum_min = 1000;
            foreach (List<int> way in edgesWays)
            {               
                int sum = 0;
                for (int i = 0; i < way.Count - 1; i++)
                {
                    int i_min = Math.Min(way[i], way[i + 1]), i_max = Math.Max(way[i], way[i + 1]), index = -1;
                    for (int j = 0; j < edges.Count; j++)
                    {
                        if(edges[j][0] == i_min && edges[j][1] == i_max)
                        {
                            index = j;
                            break;
                        }
                    }
                    if (index != -1)
                    {
                        sum += weights[index];
                    }
                }
                Console.WriteLine($"{String.Join(" -> ", way)}: {sum}");
                if (sum < sum_min) sum_min = sum;
            }
            Console.WriteLine($"Минимальный путь равен {sum_min}");
            edgesWays.Clear();

            Console.ReadLine();
        }
        static void SortStep(int[] array, int start, int end)
        {
            int pivot = (start + end) / 2, start0 = start, end0 = end;
            while (start < end)
            {
                while (array[start] <= array[pivot] && start < pivot) start++;
                while (array[pivot] <= array[end] && pivot < end) end--;
                if (start == end) break;
                else
                {
                    Swap(ref array[start], ref array[end]);
                    if (start == pivot) pivot = end;
                    else if (end == pivot) pivot = start;
                }
            }
            if (pivot - start0 > 1) SortStep(array, start0, pivot - 1);
            if (end0 - pivot > 1) SortStep(array, pivot + 1, end0);
        }
        static void Swap(ref int element1, ref int element2)
        {
            int element = element1;
            element1 = element2;
            element2 = element;
        }
        static void GraphStep(int[][] array, int edge, int k)
        {
            if (k == 0)
            {
                edgesWays.Add(new List<int>());
                edgesWays[0].Add(0);
            }
            for (int i = 0; i < array[edge].Length; i++)
            {                                
                if (!edgesWays[k].Contains(array[edge][i]))
                {
                    edgesWays.Add(new List<int>());
                    edgesWays[edgesWays.Count - 1].AddRange(edgesWays[k]);
                    edgesWays[edgesWays.Count - 1].Add(array[edge][i]);
                    if (array[edge][i] == 9) return;
                    GraphStep(array, array[edge][i], edgesWays.Count - 1);
                }
            }

        }
    }
}
