using System;

namespace ConsoleApp3
{
    class Program
    {
        //1 is true, 0 is superposition, -1 is false
        static Qubit q1 = new Qubit(1);
        static Qubit q2 = new Qubit(-1);
        static Qubit q3 = new Qubit(0);

        static void Main(string[] args)
        {
            Console.WriteLine($"q1 state: {q1}, q2 state: {q2}, q3 state: {q3}");
            if(q1 == q2)
                Console.WriteLine("q1 and q2 are equal");
            if(q1 != q2)
                Console.WriteLine("q1 and q2 are not equal");

            if(q1 == q3 && q2 == q3)
                Console.WriteLine("all qubits are equatable to q3");

            try
            {
                Console.WriteLine("BOOL OVERLOADS:");

                if (q1)
                    Console.WriteLine($"q1 = true");
                if (!q2)
                    Console.WriteLine($"q2 = false");
                if (q3)
                    Console.WriteLine($"q3 = not superposition");
            }
            catch(Exception _ex)
            {
                Console.WriteLine(_ex);
            }

            Console.ReadKey();
        }
    }

    struct Qubit
    {
        private int val;

        public override bool Equals(object obj)
        {
            if (!(obj is Qubit))
                return false;

            var qubit = (Qubit)obj;
            return val == qubit.val;
        }

        public override int GetHashCode()
        {
            return 1835847388 + val.GetHashCode();
        }

        public static bool operator == (Qubit _a, Qubit _b)
        {
            if(_a.val == 0 || _b.val == 0 || _a.val == _b.val)
                return true;
            return false;
        }
        public static implicit operator bool(Qubit _a)
        {
            if(_a.val == 1)
                return true;
            if(_a.val == -1)
                return false;

            throw new Exception("Qubit is in superposition.");
        }
        public static bool operator != (Qubit _a, Qubit _b)
        {
            if (_a.val == 0 || _b.val == 0 || _a.val != _b.val)
                return true;
            return false;
        }

        public override string ToString()
        {
            return val.ToString();
        }

        public Qubit(int _position)
        {
            val = ClampMinus1To1(_position);
        }

        private static int ClampMinus1To1(int _val)
        {
            if (_val < -1) { return -1; }
            if (_val > 1) { return 1; }
            return _val;
        }
    }
}
