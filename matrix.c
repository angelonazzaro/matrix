#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <math.h>
#include "nMatrix.h"
#include "zMatrix.h"
#include "utils.h"

//Prototypes
void nMain();
void zMain();
int choice();


int main(void) {
    
    char zN[3];

    printf("Do you want to do operations in Zn? Yes or No -->  ");
    scanf("%s", zN);
    printf("\n");

    if (zN[0] == 'y')
        zMain();
    else
        nMain();

    return 0;
}



void nMain() {
    int ans = 1;
    switch(choice()) {
        int rows, cols, rows1, cols1;
        double *m1, *m2, scalar;

        case 1:
            printf("\nGoing to calculate sum between two matrix.\n");

            get_dim(&rows, &cols); // MATRIX' S DIMENSIONS MUST BE EQUAL FOR SUMMING, NO NEED TO GET DOUBLE INPUT 

            m1 = (double *) malloc((rows * cols) * sizeof(double));
            m2 = (double *) malloc((rows * cols) * sizeof(double));

            check_malloc(m1);
            check_malloc(m2);
            
            printf("Insert A matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }

            printf("\nInsert B matrix\n");
            insert_matrix(m2,rows, cols);
            print_matrix(m2, rows, cols, &ans);

            while (!ans) {
                printf("Insert B matrix\n");
                insert_matrix(m2, rows, cols);
                print_matrix(m2, rows, cols, &ans);
            }

            printf("A + B = \n");
            print_result(sum_matrix(m1, m2, rows, cols), rows, cols);
            break; // ENDS CASE 1

        case 2:
            printf("\nGoing to calculate product for a scalar.\n");

            get_dim(&rows, &cols);
            m1 = (double *) malloc((rows * cols) * sizeof(double));

            check_malloc(m1);

            printf("Insert Matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

     
            while (!ans) {
                printf("Insert Matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }

            printf("Insert scalar: ");
            scanf("%lf", &scalar);

            printf("Matrix * %lf = \n", scalar);
            prod_scalar(m1,rows,cols, scalar);
            print_result(m1, rows, cols);
            break; // ENDS CASE 2

        case 3:
            printf("\nGoing to calculate product rows  * cols.\n");

            get_dim(&rows, &cols);
            m1 = (double *) malloc((rows * cols) * sizeof(double));
            check_malloc(m1);

            get_dim(&rows1, &cols1);

            if (cols != rows1) {
                printf("'A Matrix' s cols must be equal to B Matrix' s rows.\n");
                exit(-1);
            }

            m2 = (double *) malloc((rows1 * cols1) * sizeof(double));
            check_malloc(m2);
            
            printf("Insert A matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }


            printf("Insert B matrix\n");
            insert_matrix(m2, rows1, cols1);
            print_matrix(m2, rows1, cols1, &ans);

            while (!ans) {
                printf("Insert B matrix\n");
                insert_matrix(m2, rows1, cols1);
                print_matrix(m2, rows1, cols1, &ans);
            }

            print_result(rows_cols(m1,m2,rows,cols,rows1,cols1), rows, cols1);

            break; // ENDS CASE 3


        case 4:
            printf("\nGoing to calculate the transpose.\n");

            get_dim(&rows, &cols);
            m1 = (double *) malloc((rows * cols) * sizeof(double));

            check_malloc(m1);

            printf("Insert Matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

     
            while (!ans) {
                printf("Insert Matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }

            double *transposed = (double *) malloc((rows * cols) * sizeof(double));
            check_malloc(transposed);
            transposed = transpose(m1, rows, cols);

            print_result(transposed, rows, cols);

            break; // ENDS CASE 4

        case 5:
            printf("\nGoing to calculate determinant.\n");

            get_dim(&rows, &cols);

            if (rows != cols) {
                printf("Matrix must be square in order to calculate determinant.\n");
                exit(-3);
            }

            m1 = (double*) malloc((rows * cols) * sizeof(double));

            check_malloc(m1);

            printf("Insert A Matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

     
            while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }

            double det = determinant(m1, rows, cols);
            double mod, intPart;

            mod = modf(det, &intPart);

            if (!mod)
                printf("Determinant: %.lf.\n", intPart);
            else
                printf("Determinant: %.2lf.\n", det);
            break;  // ENDS CASE 5

        case 6:
            printf("\nGoing to matrix's reverse.\n");

            get_dim(&rows, &cols);
            
            if (rows != cols) {
                printf("Matrix must be square in order to calculate reverse.\n");
                exit(-3);
            }

            m1 = (double*) malloc((rows * cols) * sizeof(double));
            check_malloc(m1);
            
            printf("Insert A Matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

             while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }

            double det1 = determinant(m1, rows, cols);

            if (det1 == 0) {
                printf("Matrixes with null determinant cant be reversed.\n");
                break;
            }

            det1 = pow(det1, -1);

            double *algebric = (double *) malloc(rows * cols * sizeof(double));
            check_malloc(algebric);
            

            algebric = algebrics(m1, rows, cols);
            algebric = transpose(algebric, rows, cols);

            prod_scalar(algebric, rows, cols, det1);
            print_result(algebric, rows, cols);

            free(algebric);
            break; // ENDS CASE 6

        case 7:
            printf("\nGoing to matrix's reverse.\n");

            get_dim(&rows, &cols);
            
            if (rows != cols) {
                printf("Matrix must be square in order to calculate reverse.\n");
                exit(-3);
            }

            m1 = (double*) malloc((rows * cols) * sizeof(double));
            check_malloc(m1);
            
            printf("Insert A Matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

             while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }

            double *algebric1 = (double *) malloc(rows * cols * sizeof(double));
            check_malloc(algebric1);

            algebric1 = algebrics(m1, rows, cols);
            print_result(algebric1, rows, cols);

            break; // ENDS CASE 7

        case 8:
            printf("\nGoing to calculate ladder matrix.\n");

            get_dimN(&rows, &cols);

            m1 = (double*) malloc((rows * cols) * sizeof(double));
            check_malloc(m1);
            
            printf("Insert A Matrix\n");
            insert_matrix(m1, rows, cols);
            print_matrix(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrix(m1, rows, cols);
                print_matrix(m1, rows, cols, &ans);
            }

            third_operation(m1, rows, cols);
            print_result(m1, rows, cols);
            break; // ENDS CASE 8

            free(m1);
            if (choice() != 1 || choice() != 3)
                free(m2);
    }
}


void zMain() {

    int n;
    printf("Insert N, everything will be converted to the domain --> ");
    scanf("%d", &n);
    printf("\n");

    int ans = 1;
    switch(choice()) {
        int rows, cols, rows1, cols1;
        int *m1, *m2, scalar;

        case 1:
            printf("\nGoing to calculate sum between two matrix.\n");

            get_dimN(&rows, &cols); // MATRIX' S DIMENSIONS MUST BE EQUAL FOR SUMMING, NO NEED TO GET DOUBLE INPUT 

            m1 = (int *) malloc((rows * cols) * sizeof(int));
            m2 = (int *) malloc((rows * cols) * sizeof(int));

            check_mallocN(m1);
            check_mallocN(m2);
            
            printf("Insert A matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }

            printf("\nInsert B matrix\n");
            insert_matrixN(m2,rows, cols, n);
            print_matrixN(m2, rows, cols, &ans);

            while (!ans) {
                printf("Insert B matrix\n");
                insert_matrixN(m2, rows, cols, n);
                print_matrixN(m2, rows, cols, &ans);
            }

            printf("A + B = \n");
            print_resultN(sum_matrixN(m1, m2, rows, cols, n), rows, cols);
            break; // ENDS CASE 1

        case 2:
            printf("\nGoing to calculate product for a scalar.\n");

            get_dimN(&rows, &cols);
            m1 = (int *) malloc((rows * cols) * sizeof(int));

            check_mallocN(m1);

            printf("Insert Matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

     
            while (!ans) {
                printf("Insert Matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }

            printf("Insert scalar [0 --- %d]: ", n - 1);
            scanf("%d", &scalar);

            if (scalar < 0 || scalar > n - 1)
                scalar %= n;

            printf("Matrix * %d = \n", scalar);
            prod_scalarN(m1,rows,cols, scalar, n);
            print_resultN(m1, rows, cols);
            break; // ENDS CASE 2

        case 3:
            printf("\nGoing to calculate product rows  * cols.\n");

            get_dimN(&rows, &cols);
            m1 = (int *) malloc((rows * cols) * sizeof(int));
            check_mallocN(m1);

            get_dimN(&rows1, &cols1);

            if (cols != rows1) {
                printf("'A Matrix' s cols must be equal to B Matrix' s rows.\n");
                exit(-1);
            }

            m2 = (int *) malloc((rows1 * cols1) * sizeof(int));
            check_mallocN(m2);
            
            printf("Insert A matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }


            printf("Insert B matrix\n");
            insert_matrixN(m2, rows1, cols1, n);
            print_matrixN(m2, rows1, cols1, &ans);

            while (!ans) {
                printf("Insert B matrix\n");
                insert_matrixN(m2, rows1, cols1, n);
                print_matrixN(m2, rows1, cols1, &ans);
            }

            print_resultN(rows_colsN(m1,m2,rows,cols,rows1,cols1, n), rows, cols1);

            break; // ENDS CASE 3


        case 4:
            printf("\nGoing to calculate the transpose.\n");

            get_dimN(&rows, &cols);
            m1 = (int *) malloc((rows * cols) * sizeof(int));

            check_mallocN(m1);

            printf("Insert Matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

     
            while (!ans) {
                printf("Insert Matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }

            int *transposed = (int *) malloc((rows * cols) * sizeof(int));
            check_mallocN(transposed);
            transposed = transposeN(m1, rows, cols);

            print_resultN(transposed, rows, cols);

            break; // ENDS CASE 4

        case 5:
            printf("\nGoing to calculate determinant.\n");

            get_dimN(&rows, &cols);

            if (rows != cols) {
                printf("Matrix must be square in order to calculate determinant.\n");
                exit(-3);
            }

            m1 = (int*) malloc((rows * cols) * sizeof(int));

            check_mallocN(m1);

            printf("Insert A Matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

     
            while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }

            int det = determinantN(m1, rows, cols, n);

            printf("Determinant: %d.\n", det);
            break;  // ENDS CASE 5

        case 6:
            printf("\nGoing to matrix's reverse.\n");

            get_dimN(&rows, &cols);
            
            if (rows != cols) {
                printf("Matrix must be square in order to calculate reverse.\n");
                exit(-3);
            }

            m1 = (int*) malloc((rows * cols) * sizeof(int));
            check_mallocN(m1);
            
            printf("Insert A Matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }

            int det1 = determinantN(m1, rows, cols, n);
            det1 = classeDiEquivalenza(det1, n);
            int gcd = mcd(det1, n);

            if (det1 == 0 || gcd != 1) {
                printf("det = %d\n", det1);
                printf("Matrixes with null determinant or with unreversable determinant cant be reversed.\n");
                break;
            }

            int n2 = n;
            det1 /= gcd;
            n2 /= gcd;

            det1 = solve(det1, 1, n2);

            int *algebric = (int *) malloc(rows * cols * sizeof(int));
            check_mallocN(algebric);
            

            algebric = algebricsN(m1, rows, cols, n);
            algebric = transposeN(algebric, rows, cols);

            prod_scalarN(algebric, rows, cols, det1, n);
            print_resultN(algebric, rows, cols);

            free(algebric);
            break; // ENDS CASE 6

        case 7:
            printf("\nGoing to matrix's reverse.\n");

            get_dimN(&rows, &cols);
            
            if (rows != cols) {
                printf("Matrix must be square in order to calculate reverse.\n");
                exit(-3);
            }

            m1 = (int*) malloc((rows * cols) * sizeof(int));
            check_mallocN(m1);
            
            printf("Insert A Matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }

            int *algebric1 = (int *) malloc(rows * cols * sizeof(int));
            check_mallocN(algebric1);

            algebric1 = algebricsN(m1, rows, cols, n);
            print_resultN(algebric1, rows, cols);

            break; // ENDS CASE 7

        case 8:
            printf("\nGoing to calculate ladder matrix.\n");

            get_dimN(&rows, &cols);

            m1 = (int*) malloc((rows * cols) * sizeof(int));
            check_mallocN(m1);
            
            printf("Insert A Matrix\n");
            insert_matrixN(m1, rows, cols, n);
            print_matrixN(m1, rows, cols, &ans);

            while (!ans) {
                printf("Insert A Matrix\n");
                insert_matrixN(m1, rows, cols, n);
                print_matrixN(m1, rows, cols, &ans);
            }

            break; // ENDS CASE 8

            free(m1);
            if (choice() != 1 || choice() != 3)
                free(m2);
    }
}


int choice() {
    // GUI MENU & INPUT VALIDATION

    int choice;

    printf("What operations do you want to do?\n");
    printf("Press 1 for sum\nPress 2 for product for a scalar\nPress 3 for product rows * cols\nPress 4 for transpose\nPress 5 for determinant\nPress 6 for reverse\nPress 7 for algebrics\nPress 8 for ladder -- >  ");
    scanf("%d", &choice);

    while (choice < 1 || choice > 8) {
        printf("Choice doesn't exist. Re-insert.\n");
        printf("Press 1 for sum\nPress 2 for product for a scalar\nPress 3 for product rows * cols\nPress 4 for transpose\nPress 5 for determinant\nPress 6 for reverse\nPress 7 for algebrics\nPress 8 for ladder -- >  ");
        scanf("%d", &choice);
    }

    return choice;
}