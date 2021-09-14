#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <math.h>
#include "nMatrix.h"
#include "utils.h"


#pragma region INPUT


void get_dim(int *rows, int *cols) {
    printf("Insert matrix' s dimensions (rows cols): ");
    scanf("%d %d", rows, cols);
}


void insert_matrix(double *m, int rows, int cols) {
    // INSERT MATRIX' S ELEMENTS

    for (int i = 0; i < rows; i++) {

        for (int j = 0; j < cols; j++) {

            printf("Insert m[%d][%d]: ", i + 1,j + 1);
            scanf("%lf", (m + (i * cols) + j));

        }

    }
}


#pragma endregion


#pragma region CHECK


void check_malloc(double*m1) {
    if (!m1) {
        printf("Couldn't allocate memory! Exiting....\n");
        exit(EXIT_FAILURE);
    }
}


#pragma endregion


#pragma region SUM_PROD


double *sum_matrix(double *m, double *m1, int rows, int cols) {

    double *sum = (double *) malloc((rows * cols) * sizeof(double));

    check_malloc(sum);
    
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            *(sum + (i * cols) + j) = *(m + (i * cols) + j) + *(m1 + (i * cols) + j);
        }
    }

    return sum;
}


void prod_scalar(double *m, int rows, int cols, double scalar) {
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) 
                *(m + (i * cols) + j) *= scalar;
    }
}


double *rows_cols(double *m, double *m1, int rows, int cols, int rows1, int cols1) {
    double *prod = (double *) malloc((rows * cols1) * sizeof(double));
    check_malloc(prod);

    int i, k, j, sum;

    for (i = 0; i < rows; i++) {
        for (k = 0; k < cols1; k++) {
            sum = 0;
            for (j = 0; j < cols; j++) {
                sum += *(m + (i * cols) + j) * *(m1 + (j * cols1) + k);
            }
            *(prod + (i * cols1) + k) = sum;
        }
    }

    return prod;
}


#pragma endregion


#pragma region REVERSE


double * transpose(double *m, int rows, int cols) {

    double *transposed = (double *) malloc((rows * cols )* sizeof(double));
    check_malloc(transposed);

    for (int i = 0; i < cols; i++) {
        for (int j = 0; j < rows; j++) 
            *(transposed + (i * cols) + j) = *(m + (j * cols) + i);
    }

    return transposed;
}


double determinant(double *m, int rows, int cols) {
    if (rows == cols && rows == 1)
        return *(m + 0 + 0);

    if (rows == 2 && rows == cols) // IN CASE IT IS A 2X2 MATRIX
        return (*(m + (0 * cols) + 0) * *(m + (1 * cols) + 1)) - (*(m + (0 * cols) + 1) * *(m + (1 * cols ) + 0));

    if (check_ifDiag(m, rows, cols)) {

        if (sup_diag(m, rows, cols) || inf_diag(m, rows, cols)) {
            int det = 1;

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (i == j) {
                         det *= *(m + (i * cols) + j);
                         break;
                    }    
                }
            }

            return det;
        }   
    }

    if (zero_row(m, rows, cols) || zero_col(m, rows, rows))
        return 0;


    int i = 0,j;
    double det = 0;
    int k, p, copyRows = rows - 1;
    

    for (j = 0; j < cols; j++) {
        double *tmp = (double *) malloc((copyRows * copyRows) * sizeof(double));
        check_malloc(tmp);
        int t =0;

        for (k = 1; k < rows; k++) {
            int y = 0;
            for (p = 0; p  < cols; p++) {
                if (p == j)
                    continue;
                
                *(tmp + (t * copyRows) + y) = *(m + (k * cols) + p);
                y++;
            }
            t++;
        }

        det += pow(-1, (i + 1) + (j + 1)) * *(m + (i * cols + j)) * determinant(tmp, copyRows, copyRows); 
        free(tmp);
    }
    

    return det;

}


int check_ifDiag(double *m, int rows, int cols) {

    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            if (i == j && *(m + (i * cols) + j) == 0)
                return 0;
        }
    }

    return 1;
}


int inf_diag(double *m, int rows, int cols) {
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols - 1; j++) {
            if (i == j)
                break;

            if (i != j && *(m + (i * cols) + j) != 0)
                return 0;
        }
    }

    return 1;
}


int sup_diag(double *m, int rows, int cols) {

    int halfj  = (int) cols / 2;

    for (int i = 0; i < rows - 1 ; i++) {
        for (int j = cols - 1; j > halfj; j--)  {
             if (*(m + (i * cols) + j) != 0)
                return 0;
        }
           
    }

    return 1;
}


int zero_row(double *m, int rows, int cols) {

    int zeros;

    for (int i = 0; i < rows; i++) {
        zeros = 1;
        for (int j = 0; j < cols; j++) {
            if (*(m + (i * cols) + j) != 0)
                zeros = 0;
        }

        if (zeros)
            break;
    }

    return zeros;
}


int zero_col(double *m, int rows, int cols) {
    int zeros;

    for (int i = 0; i < cols; i++) {
        zeros = 1;
        for (int j = 0; j < rows; j++) {
            if (*(m + (j * cols) + i) != 0)
                zeros = 0;
        }

        if (zeros)
            break;
    }

    return zeros;
}


double *algebrics(double *m, int rows, int cols) {

    double *algebric = (double *) malloc((rows * cols) * sizeof(double ));
    check_malloc(algebric);

    int i,j;
    double det = 0;
    int k, p, copyRows = rows - 1;
    
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {

            double *tmp = (double *) malloc((copyRows * copyRows) * sizeof(double));
            check_malloc(tmp);

            int t = 0;

            for (k = 0; k < rows; k++) {

                    if (k == i)
                        continue;

                    int y = 0;

                for (p = 0; p < cols; p++) {

                     if (p == j)
                        continue;

                    *(tmp + (t * copyRows) + y) = *(m + (k * cols) + p);
                    y++;
                }
                t++;
            }
            det += pow(-1, (i + 1) + (j + 1)) * determinant(tmp, copyRows, copyRows); 
            *(algebric + (i * cols) + j) = det;
            det = 0;
            free(tmp);
        }
    }

    return algebric;
}


#pragma endregion


#pragma region OUTPUT


void print_matrix(double *m, int rows, int cols, int *ans) {

    double mod, intPart;

    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            mod = modf(*(m + (i * cols + j)), &intPart);
            if (!mod)
                printf("%.lf\t", intPart);
            else
                printf("%.2lf\t", *(m + (i * cols) + j));
        }
        printf("\n");
    }

    if (ans) {
        char answ[3];

        printf("Is the matrix correct? YES or NO: ");
        scanf("%s", answ);

        if (tolower(answ[0]) == 'n')
            *ans = 0;
    }
}


void print_result(double *m, int rows, int cols) {

    double mod, intPart;

      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            mod = modf(*(m + (i * cols + j)), &intPart);
            if (!mod)
                printf("%.lf\t", intPart);
            else
                printf("%.2lf\t", *(m + (i * cols) + j));
        }
        printf("\n");
    }
}


#pragma endregion 


#pragma region SCALA


void first_operation(double *rh, double *rk, int cols){

	for(int i = 0; i < cols; i++)
		swap(&rh[i], &rk[i]);
}


void second_operation(double *rh, int scalar, int cols){

    if(scalar > 0)
        return;

	for(int i = 0; i < cols; i++)
		rh[i] *= scalar;
}


void third_operation(double *matrix, int rows, int cols){

    int i, j, k;
    for(i = 0; i < rows; i++){
        if (allZeros(&matrix[i * cols], cols)) {
            for (j = i + 1; j < rows; j++) 
                swapRows(&matrix[(j - 1) * cols], &matrix[j * cols], cols);
        }
       
    }
}


int allZeros(double *matrix, int cols) {
    int i, isZero = 1;

    for (i = 0; i < cols; i++) {
        if (matrix[i] != 0) {
            isZero = 0;
            break;
        }
    }

    return isZero;
}

   
#pragma endregion


