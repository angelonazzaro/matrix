#include "utils.h"
#include <math.h>

void swapRows(double *a, double *b, int cols)
{
    int i;

    for (i = 0; i < cols; i++)
    {
        int tmp = a[i];
        a[i] = b[i];
        b[i] = tmp;
    }
}

void swap(double *a, double *b)
{

    int tmp = *a;
    *a = *b;
    *b = tmp;
}

int mcd(int a, int b)
{
    if (b == 0)
        return a;
    else
        return mcd(b, a % b);
}

int virgola(double val)
{

    int troncato = (int)val;
    return (val == troncato);
}

int verifica(int a, int b, int mod)
{

    double val = (double)b / mcd(a, mod);
    return virgola(val);
}

int solve(int a, int b, int mod)
{

    int ris = 0;
    for (int i = 1; i < mod; i++)
        if (virgola((double)(a * i - b) / mod))
            return i;

    return -1;
}

int classeDiEquivalenza(int det, int mod)
{

    int num1 = customAbs(det);
    int num2 = customAbs(mod);
    int resto = 0;

    for (int i = 1; i <= num1; i++)
    {

        if (num2 * i > num1)
        {

            resto = num1 - num2 * (i - 1);
            break;
        }
    }

    if (det < 0)
        resto = mod - resto;
    return resto;
}

int customAbs(int n)
{

    return (n > 0) ? n : -n;
}