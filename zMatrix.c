#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <math.h>
#include "zMatrix.h"
#include "utils.h"



#pragma region INPUT


void get_dimN(int *rows, int *cols) {
    printf("Insert matrix' s dimensions (rows cols): ");
    scanf("%d %d", rows, cols);
}


void insert_matrixN(int *m, int rows, int cols, int n) {
    // INSERT MATRIX' S ELEMENTS

    for (int i = 0; i < rows; i++) {

        for (int j = 0; j < cols; j++) {

            printf("Insert m[%d][%d]: ", i + 1,j + 1);
            scanf("%d", (m + (i * cols) + j));
            *(m + (i * cols) + j) = classeDiEquivalenza(*(m + (i * cols) + j), n);
        }

    }
}


#pragma endregion


#pragma region CHECK


void check_mallocN(int*m1) {
    if (!m1) {
        printf("Couldn't allocate memory! Exiting....\n");
        exit(EXIT_FAILURE);
    }
}



#pragma endregion


#pragma region SUM_PROD


int *sum_matrixN(int *m, int *m1, int rows, int cols, int n) {

    int *sum = (int *) malloc((rows * cols) * sizeof(int));

    check_mallocN(sum);
    
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            *(sum + (i * cols) + j) = *(m + (i * cols) + j) + *(m1 + (i * cols) + j);
            *(sum + (i * cols) + j) = classeDiEquivalenza(*(sum + (i * cols) +  j), n);
        }
    }

    return sum;
}


void prod_scalarN(int *m, int rows, int cols, int scalar, int n) {
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
                *(m + (i * cols) + j) *= scalar;
                *(m + (i * cols) + j)  = classeDiEquivalenza(*(m + (i * cols) +  j), n);
        }
                
    }
}


int *rows_colsN(int *m, int *m1, int rows, int cols, int rows1, int cols1, int n) {
    int *prod = (int *) malloc((rows * cols1) * sizeof(int));
    check_mallocN(prod);

    int i, k, j, sum;

    for (i = 0; i < rows; i++) {
        for (k = 0; k < cols1; k++) {
            sum = 0;
            for (j = 0; j < cols; j++) {
                sum += *(m + (i * cols) + j) * *(m1 + (j * cols1) + k);
            }
            sum = classeDiEquivalenza(sum, n);
            *(prod + (i * cols1) + k) = sum;
        }
    }

    return prod;
}


#pragma endregion


#pragma region REVERSE


int * transposeN(int *m, int rows, int cols) {

    int *transposed = (int *) malloc((rows * cols )* sizeof(int));
    check_mallocN(transposed);

    for (int i = 0; i < cols; i++) {
        for (int j = 0; j < rows; j++) 
            *(transposed + (i * cols) + j) = *(m + (j * cols) + i);
    }

    return transposed;
}


int determinantN(int *m, int rows, int cols, int n) {
    if (rows == cols && rows == 1)
        return *(m + 0 + 0);

    if (rows == 2 && rows == cols) // IN CASE IT IS A 2X2 MATRIX
        return (*(m + (0 * cols) + 0) * *(m + (1 * cols) + 1)) - (*(m + (0 * cols) + 1) * *(m + (1 * cols ) + 0));

    if (check_ifDiagN(m, rows, cols)) {

        if (sup_diagN(m, rows, cols) || inf_diagN(m, rows, cols)) {
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

    if (zero_rowN(m, rows, cols) || zero_colN(m, rows, rows))
        return 0;


    int i = 0,j;
    int det = 0;
    int k, p, copyRows = rows - 1;
    

    for (j = 0; j < cols; j++) {
        int *tmp = (int *) malloc((copyRows * copyRows) * sizeof(int));
        check_mallocN(tmp);
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

        det += pow(-1, (i + 1) + (j + 1)) * *(m + (i * cols + j)) * determinantN(tmp, copyRows, copyRows, n); 
        free(tmp);
    }
    
    det = classeDiEquivalenza(det, n);
    return det;

}


int check_ifDiagN(int *m, int rows, int cols) {

    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            if (i == j && *(m + (i * cols) + j) == 0)
                return 0;
        }
    }

    return 1;
}


int inf_diagN(int *m, int rows, int cols) {
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


int sup_diagN(int *m, int rows, int cols) {

    int halfj  = (int) cols / 2;

    for (int i = 0; i < rows - 1 ; i++) {
        for (int j = cols - 1; j > halfj; j--)  {
             if (*(m + (i * cols) + j) != 0)
                return 0;
        }
           
    }

    return 1;
}


int zero_rowN(int *m, int rows, int cols) {

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


int zero_colN(int *m, int rows, int cols) {
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


int *algebricsN(int *m, int rows, int cols, int n) {

    int *algebric = (int *) malloc((rows * cols) * sizeof(int ));
    check_mallocN(algebric);

    int i,j;
    int det = 0;
    int k, p, copyRows = rows - 1;
    
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {

            int *tmp = (int *) malloc((copyRows * copyRows) * sizeof(int));
            check_mallocN(tmp);

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
            det += pow(-1, (i + 1) + (j + 1)) * determinantN(tmp, copyRows, copyRows, n); 
            det = classeDiEquivalenza(det, n);
            *(algebric + (i * cols) + j) = det;
            det = 0;
            free(tmp);
        }
    }

    return algebric;
}


#pragma endregion


#pragma region OUTPUT

void print_matrixN(int *m, int rows, int cols, int *ans) {
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) 
                printf("%d\t", *(m + (i * cols) + j));
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


void print_resultN(int *m, int rows, int cols) {
      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) 
                printf("%d\t", *(m + (i * cols) + j));
        printf("\n");
    }
}


#pragma endregion