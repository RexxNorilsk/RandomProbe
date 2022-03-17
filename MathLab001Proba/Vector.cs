using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLab001Proba
{
    

    class Vector
    {
        public double x;
        public double y;

        public Vector(double _x, double _y) {
            x = _x;
            y = _y;
        }
        public Vector(Vector vec)
        {
            x = vec.x;
            y = vec.y;
        }
        public Vector(Random rnd) {
            x = (double)((rnd.NextDouble() > 0.5) ? -rnd.NextDouble() : rnd.NextDouble());
            y = (double)((rnd.NextDouble() > 0.5) ? -rnd.NextDouble() : rnd.NextDouble());
        }
        public double GetAbs() {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        public Vector GetUnit()
        {
            double abs = (double)GetAbs();
            return new Vector(x / abs, y / abs);
        }
        public string GetStr()
        {
            return "X: "+x+": "+"Y: "+y;
        }

        public static Vector operator +(Vector vec1, Vector vec2)
        {
            return new Vector (
                vec1.x + vec2.x,
                vec1.y + vec2.y
            );
        }
        public static Vector operator *(double num, Vector vec2)
        {
            return new Vector(
                vec2.x * num,
                vec2.y * num
            );
        }
    }
}
