using System;

namespace ExceptionSqrt
{
    class Program
    {
        public static double Sqrt(int num)
        {
            if (num < 0) throw new ArgumentOutOfRangeException("负数开方未定义");
            return Math.Sqrt(num);
        }

        static void Main(string[] args)
        {
            try
            {
                int num;
                double result;
                num = Int32.Parse(Console.ReadLine());
                result = Sqrt(num);
                Console.WriteLine("{0}的平方根为{1}", num, result);
            }
            catch (FormatException)
            {
                Console.WriteLine("无效数");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("无效数");
            }
            finally
            {
                Console.WriteLine("再见");
            }
        }
    }
}
