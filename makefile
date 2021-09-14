link : matrix.o nMatrix.o zMatrix.o utils.o
	clang matrix.o nMatrix.o zMatrix.o utils.o -lm -o Matrix.exe

matrix:
	clang -c matrix.c -lm

nMatrix: 
	clang -c nMatrix.c -lm

zMatrix:
	clang -c zMatrix.c -lm

utils:
	clang -c utils.c -lm

clean: 
	rm -f matrix.o nMatrix.o zMatrix.o utils.o Matrix.exe