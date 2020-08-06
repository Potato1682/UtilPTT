using System;
using System.Linq;

namespace UtilPTT
{
    public static class LearnMath
    {
        public static double Sigmoid(double x) => 1 / (1 + Math.Exp(-x));

        public static double SigmoidDef(double x) => Sigmoid(x) * (1 - Sigmoid(x));

        public static double Swish(double x) => x * Sigmoid(x);

        public static double SwishDef(double x) => Swish(x) + (Sigmoid(x) * (1 - Swish(x)));

        public static double Step(double x) => x >= 0 ? 1 : 0;

        public static double ReLU(double x) => x * Math.Max(x, 0);

        public static double ReLUDef(double x) => 1 * x > 0 ? 1 : 0;

        public static double LReLU(double x, double alpha = 1) => x >= 0 ? x : alpha * x;

        public static double LReLUDef(double x, double alpha = 1) => x >= 0 ? alpha : 0.01;

        public static double ELU(double x, double alpha = 1) => x > 0 ? x : alpha * (Math.Exp(x) - 1);

        public static double ELUDef(double x, double alpha = 1) => x > 0 ? 1 : ELU(x, alpha) + alpha;

        public static double SELU(double x, double scale, double alpha) => scale * x > 0 ? x : alpha * (Math.Exp(x) - 1);

        public static double SELUDef(double x, double scale, double alpha) => scale * x > 0 ? 1 : alpha * Math.Exp(x);

        public static double Tanh(double x) => Math.Tanh(x);

        public static double TanhDef(double x) => 1 - Math.Pow(Tanh(x), 2);

        public static double SoftPlus(double x) => Math.Log(1 + Math.Exp(x));

        public static double SoftPlusDef(double x) => 1 / (1 + Math.Exp(-x));

        public static double Omega(double x) => 4 * (x + 1) + 4 * Math.Exp(2 * x) + Math.Exp(3 * x) + Math.Exp(x) * (4 * x + 6);

        public static double Delta(double x) => 2 * Math.Exp(x) + Math.Exp(2 * x) + 2;

        public static double Mish(double x) => x * Tanh(SoftPlus(x));

        public static double MishDef(double x) => Math.Exp(x) * Omega(x) / Math.Pow(Delta(x), 2);

        public static double Identity(double x) => x;

        public static double IdentityDef() => 1;

        public static double[] SoftMax(double[] x) => (double[])x.Select(Math.Exp).Select(i => i / x.Select(Math.Exp).Sum());

        public static double[] SoftMaxDef(double[,] x) => new Jacobi().Run(ref x, 1).ToArray();
    }
}
