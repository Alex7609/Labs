namespace LB1
{
    internal class Task
    {

        public void Run()
        {
            int a = 6;
            int b = 7;
            int c = 8;
            isPositive(a, b, c);
            Console.WriteLine("===================");
            isTrikytnik(a, b, c);
            if (isTrikytnik(a, b, c))
            {
                pTrikytnik(a, b, c);
                formulaHeroina(a, b, c);
                checkTrikytnika(a, b, c);
            }
            else
            {
                Console.WriteLine("Trikytnik is not alive");
            }

        }
        public void isPositive(int a, int b, int c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                Console.WriteLine("All numbers are positive");
            }
        }

        public bool isTrikytnik(int a, int b, int c)
        {
            if (a + b > c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void pTrikytnik(int a, int b, int c)
        {
            Console.WriteLine(a + b + c);
        }

        public void formulaHeroina(int a, int b, int c)
        {
            float p = a + b + c / 2;
            float S = (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine(S);
        }

        public void checkTrikytnika(int a, int b, int c)
        {
            if (a == b && b == c && a == c)
            {
                Console.WriteLine("TTrikytnik Equilateral");
            }
            else if (a == b || b == c || a == c)
            {
                Console.WriteLine("Trikytnik Isosceles");
            }
            else if (Right(a, b, c))
            {
                Console.WriteLine("Trikytnik pryamokytniy");
            }
            else
            {
                Console.WriteLine("Trikytnik Scalene");
            }

        }
        private int Max(int a, int b, int c)
        {
            int max = 0;
            if (a > max)
                max = a;
            else if (b > max)
                max = b;
            else
                max = c;
            return max;
        }
        public bool Right(int a, int b, int c)
        {
 
            if (a == Max(a, b, c)) return a * a == b * b + c * c;
            if (b == Max(a, b, c)) return b * b == a * a + c * c;
            if (c == Max(a, b, c)) return c * c == a * a + b * b;
            return false;
        }

        

    }
}
