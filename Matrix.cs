using System;

public static class Matrix
{

    public static double[] SumMatrix(double[] m, double[] m1, int rows, int cols)
    {

        double[] sum = new double[rows * cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                sum[i * cols + j] = m[i * cols + j] + m1[i * cols + j];

        return sum;
    }


    public static void ProdScalar(double[] m, int rows, int cols, double scalar)
    {
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                m[i * cols + j] *= scalar;
    }


    public static double[] RowsCols(double[] m, double[] m1, int rows, int cols, int cols1)
    {
        double[] prod = new double[rows * cols1];

        int i, k, j;
        double sum;

        for (i = 0; i < rows; i++)
        {
            for (k = 0; k < cols1; k++)
            {
                sum = 0;
                for (j = 0; j < cols; j++)
                    sum += (m[i * cols + j] * m1[j * cols1 + k]);

                prod[i * cols1 + k] = sum;
            }
        }

        return prod;
    }



    public static double[] Transpose(double[] m, int rows, int cols)
    {
        double[] transposed = new double[rows * cols];

        for (int i = 0; i < cols; i++)
            for (int j = 0; j < rows; j++)
                transposed[i * rows + j] = m[j * cols + i];

        return transposed;
    }


    public static double Determinant(double[] m, int rows, int cols)
    {
        double det;
        int i, j;

        if (rows == cols && rows == 1)
            return m[0];

        if (rows == 2 && rows == cols) // Se è una matrice 2x2
            return (m[0] * m[cols + 1]) - (m[1] * m[cols]);
        //return (*(m + (0 * cols) + 0) * *(m + (1 * cols) + 1)) - (*(m + (0 * cols) + 1) * *(m + (1 * cols) + 0));

        if (CheckIfDiag(m, rows, cols))
        {

            if (SupDiag(m, rows, cols) || InfDiag(m, rows, cols))
            {
                det = 1;

                for (i = 0; i < rows; i++)
                {
                    for (j = 0; j < cols; j++)
                    {
                        if (i == j)
                        {
                            det *= m[i * cols + j];
                            //*(m + (i * cols) + j);
                            break;
                        }
                    }
                }

                return det;
            }
        }

        if (ZeroRow(m, rows, cols) || ZeroCol(m, rows, rows))
            return 0;

        i = 0;
        det = 0;
        int k, p, copyRows = rows - 1;

        for (j = 0; j < cols; j++)
        {
            double[] tmp = new double[copyRows * copyRows];
            int t = 0;

            for (k = 1; k < rows; k++)
            {
                int y = 0;
                for (p = 0; p < cols; p++)
                {
                    if (p == j)
                        continue;
                    tmp[t * copyRows + y] = m[k * cols + p];
                    //*(tmp + (t * copyRows) + y) = *(m + (k * cols) + p);
                    y++;
                }
                t++;
            }

            det += Math.Pow(-1, (i + 1) + (j + 1)) * m[i * cols + j] * Determinant(tmp, copyRows, copyRows);
            Array.Clear(tmp, 0, tmp.Length);
        }
        return det;
    }


    private static bool CheckIfDiag(double[] m, int rows, int cols)
    {

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                if (i == j && m[i * cols + j] == 0)
                    return false;
        }

        return true;
    }


    private static bool InfDiag(double[] m, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols - 1; j++)
            {
                if (i == j)
                    break;

                if (i != j && m[i * cols + j] != 0)
                    return false;
            }
        }

        return true;
    }


    private static bool SupDiag(double[] m, int rows, int cols)
    {

        int halfj = cols / 2;

        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = cols - 1; j > halfj; j--)

                if (m[i * cols + j] != 0)
                    return false;
        }
        return true;
    }


    private static bool ZeroRow(double[] m, int rows, int cols)
    {

        bool zeros = false;

        for (int i = 0; i < rows; i++)
        {
            zeros = true;
            for (int j = 0; j < cols; j++)
                if (m[i * cols + j] != 0)
                    zeros = false;

            if (zeros)
                break;
        }

        return zeros;
    }


    private static bool ZeroCol(double[] m, int rows, int cols)
    {
        bool zeros = false;

        for (int i = 0; i < cols; i++)
        {
            zeros = true;
            for (int j = 0; j < rows; j++)
                if (m[j * cols + i] != 0)
                    zeros = false;

            if (zeros)
                break;
        }

        return zeros;
    }


    public static double[] Algebrics(double[] m, int rows, int cols)
    {
        double[] algebric = new double[rows * cols];

        int i, j;
        double det = 0;
        int k, p, copyRows = rows - 1;

        for (i = 0; i < rows; i++)
        {
            for (j = 0; j < cols; j++)
            {
                double[] tmp = new double[copyRows * copyRows];

                int t = 0;

                for (k = 0; k < rows; k++)
                {
                    if (k == i)
                        continue;
                    int y = 0;

                    for (p = 0; p < cols; p++)
                    {

                        if (p == j)
                            continue;

                        tmp[t * copyRows + y] = m[k * cols + p];
                        y++;
                    }
                    t++;
                }
                det += Math.Pow(-1, (i + 1) + (j + 1)) * Determinant(tmp, copyRows, copyRows);
                algebric[i * cols + j] = det;
                det = 0;
                Array.Clear(tmp, 0, tmp.Length);
            }
        }

        return algebric;
    }

    public static void RiduzioneGaussiana(double[] matrix, int rows, int cols)
    {
        double result;

        for (int j = 0; j < cols; j++)
            for (int i = rows - 1; i >= 0; i--)
                for (int k = i - 1; k >= 0; k--)
                    if (matrix[i * cols + j] != 0 && matrix[k * cols + j] != 0 && ((j >= 1) ? matrix[k * cols + j - 1] == 0 : true))
                    {

                        result = -matrix[i * cols + j] / matrix[k * cols + j];
                        for (int h = j; h < cols; h++)
                            matrix[i * cols + h] = matrix[i * cols + h] + (matrix[k * cols + h] * result);

                        if (IsLadder(matrix, rows, cols))
                            return;
                    }
    }


    private static bool IsLadder(double[] matrix, int rows, int cols)
    {

        Pick(matrix, rows, cols);

        for (int j = 0; j < cols; j++)
            for (int i = 0; i < rows; i++)
                for (int k = i + 1; k < rows - 1; k++)
                    if (matrix[i * cols + j] != 0 && matrix[k * cols + j] != 0)
                        return false;
        return true;
    }


    private static void Pick(double[] matrix, int rows, int cols)
    {

        for (int i = 0; i < rows; i++)
            for (int j = i + 1; j < rows; j++)
                Compare(matrix, i, j, cols);
                //Compare(matrix[i], matrix[j], cols);

    }

    private static void Compare(double[] row, int i, int j, int cols)
    {

        for (; i < cols; i++)
            if (row[i] == 0 && row[i] != 0 && ((i >= 1) ? Zeros(row, i - 1) && Zeros(row, i - 1) : true))
                for (; j < cols; j++)
                    Utils.Swap<double>(ref row[j], ref row[j]);
    }


    private static bool Zeros(double[] row, int pos)
    {

        for (; pos >= 0; pos--)
            if (row[pos] != 0)
                return false;

        return true;
    }

    public static int Rank(double[] matrix, int righe, int colonne)
    {
        bool sw = false;
        int pivots = 0;

        for (int i = 0; i < righe; i++)
        {
            sw = true;
            for (int j = 0; j < colonne; j++)
            {
                if (matrix[i * colonne +  j] != 0 && sw)
                {
                    pivots++;
                    sw = false;
                }

            }
        }
        return pivots;
    }
}
