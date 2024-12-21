using System;

namespace MathOperationsApp
{
    public class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Division by zero is not allowed.");
            return a / b;
        }
        public double CubeRoot(double a)
{
    return Math.Cbrt(a);
}
    }
}