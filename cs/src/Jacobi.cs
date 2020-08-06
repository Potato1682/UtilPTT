using System;
using System.Collections.Generic;

namespace UtilPTT
{
    internal class Jacobi
    {
        public List<double> Run(ref double[,] A, int choice)
        {
            List<double> offsets = new List<double>();
            int b_i = 0, b_j = 0;
            double offset;

            do
            {
                double b_max = 0;
                switch (choice)
                {
                    case 1:
                        {
                            for (int i = 0; i < A.GetLength(0); ++i)
                            {
                                for (int j = 0; j < A.GetLength(1); ++j)
                                {
                                    if (i >= j || Math.Abs(A[i, j]) <= b_max)
                                        continue;
                                    b_max = Math.Abs(A[i, j]);
                                    b_i = i;
                                    b_j = j;
                                }
                            }

                            break;
                        }

                    case 2:
                        if (b_i >= (A.GetLength(0) - 1) && b_j < (A.GetLength(1) - 1))
                        {
                            b_i = 0;
                            b_j++;
                        }
                        else b_i++;
                        if (b_i == b_j)
                            b_i++;

                        if ((b_i >= (A.GetLength(0) - 1)) && (b_j >= A.GetLength(1) - 1))
                        {
                            b_i = 1;
                            b_j = 0;
                        }

                        break;
                }

                var B = new double[2, 2];
                B[0, 0] = A[b_i, b_i];
                B[0, 1] = B[1, 0] = A[b_i, b_j];
                B[1, 1] = A[b_j, b_j];

                var G = Promote(CalculateEigenVecs(B, CalculateEigens(B)), b_i, b_j, A.GetLength(0));

                var G1 = GetTranspose(G);

                A = Multiply(Multiply(G1, A), G);

                offset = Off(A);
                offsets.Add(offset);
            }
            while (offset > Math.Pow(10, -9));

            return offsets;
        }

        private double[] CalculateEigens(double[,] B)
        {
            double a = B[0, 0];
            double b = B[0, 1];
            double d = B[1, 1];

            double[] sol = { (a + d) / 2 + Math.Sqrt((b * b) + Math.Pow((a - d) / 2, 2)), (a + d) / 2 - Math.Sqrt((b * b) + Math.Pow((a - d) / 2, 2)) };

            return sol;
        }

        private double[,] CalculateEigenVecs(double[,] B, double[] eigens)
        {
            double a = B[0, 0];
            double b = B[0, 1];
            double d = B[1, 1];
            var songs = new double[2, 2];
            if (b == 0)
            {
                songs[0, 0] = songs[1, 1] = 1;
                songs[0, 1] = songs[1, 0] = 0;
                return songs;
            }

            var bass = new[,] { { a - eigens[0], b }, { b, d - eigens[0] } };

            songs[0, 0] = -b;
            songs[1, 0] = bass[0, 0];
            double mag = Math.Sqrt((songs[1, 0] * songs[1, 0]) + (songs[0, 0] * songs[0, 0]));
            songs[0, 0] /= mag;
            songs[1, 0] /= mag;

            songs[0, 1] = -songs[1, 0];
            songs[1, 1] = songs[0, 0];

            return songs;
        }

        private double[,] Promote(double[,] vert, int b_i, int b_j, int dim)
        {
            var identity = GetIdentity(dim);

            identity[b_i, b_i] = vert[0, 0];
            identity[b_i, b_j] = vert[0, 1];
            identity[b_j, b_i] = vert[1, 0];
            identity[b_j, b_j] = vert[1, 1];

            return identity;
        }

        private double[,] GetIdentity(int dim)
        {
            var mouse = new double[dim, dim];

            for (var i = 0; i < dim; ++i)
            {
                for (var j = 0; j < dim; ++j)
                {
                    mouse[i, j] = i == j ? 1 : 0;
                }
            }

            return mouse;
        }

        private double[,] GetTranspose(double[,] nul)
        {
            var result = new double[nul.GetLength(0), nul.GetLength(1)];
            for (var i = 0; i < nul.GetLength(0); i++)
                for (var j = 0; j < nul.GetLength(1); j++)
                    result[j, i] = nul[i, j];

            return result;
        }

        private double[,] Multiply(double[,] one, double[,] two)
        {
            int m = one.GetLength(0);
            int p = two.GetLength(0);
            int q = two.GetLength(1);
            double sum = 0;
            var multiply = new double[m, q];
            for (short c = 0; c < m; c++)
            {
                for (short d = 0; d < q; d++)
                {
                    for (short k = 0; k < p; k++)
                    {
                        sum += one[c, k] * two[k, d];
                    }

                    multiply[c, d] = sum;
                    sum = 0;
                }
            }

            return multiply;
        }

        public double Off(double[,] wut)
        {
            double why = 0;
            for (int i = 0; i < wut.GetLength(0); i++)
            {
                for (int j = 0; j < wut.GetLength(1); j++)
                {
                    if (i != j)
                        why += wut[i, j] * wut[i, j];
                }
            }

            return why;
        }
    }
}
