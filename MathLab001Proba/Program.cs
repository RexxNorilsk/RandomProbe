using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLab001Proba
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(DateTime.Now.Second);
            // Шаг 1
            double b = 0.5f;
            int M = 6;
            int N = 100;
            double t = 1;
            double R = 0.01f;
            int k = 0;
            Vector[] xNow = new Vector[N];
            xNow[0] = new Vector(8, 9);
            for (int j = 1; j < N; j++)
            {
                Console.WriteLine("\n========Iteration: "+j+ "========");
                int min = 0;
                Vector[] arr = new Vector[M];
                // Шаг 2 + 3
                Console.WriteLine("\nxNow: "+ xNow[k].GetStr() + "; FUNC: " + Func(xNow[k]));
                for (int i = 0; i < M; i++)
                {
                    Vector vec = new Vector(rnd);
                    arr[i] = new Vector(xNow[k] + t * vec.GetUnit());
                    // Шаг 4
                    if (Func(arr[i]) < Func(arr[min])) min = i;
                    Console.WriteLine(vec.GetStr() + " => " + arr[i].GetStr() + "; FUNC: " + Func(arr[i]));
                }
                Console.WriteLine("Min: "+arr[min].GetStr());
                if (Func(arr[min]) < Func(xNow[k]))
                {
                    // Шаг 4а
                    xNow[k+1] = arr[min];
                    k = k + 1;
                    
                    //Условие выхода
                    if (k < N)
                    {
                        j = 1;
                        continue;
                    }
                    if (k == N) break;
                }
                // Шаг 5
                if (t <= R) break;
                if (t > R) {
                    t *= b;
                    j = 1;
                    continue;
                }

            }
            Console.WriteLine("\n========Result========");
            Console.WriteLine("Minimal point [ x: "+xNow[k].x + " y: " + xNow[k].y+" ]");
            Console.WriteLine("Minimal function: "+Func(xNow[k]));
            Console.ReadLine();
        }
        static double Func(Vector vec)
        {
            return 4 * Math.Pow(vec.x - 5f, 2f) + Math.Pow(vec.y - 6f, 2f);
        }
    }
}
