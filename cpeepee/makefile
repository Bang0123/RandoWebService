CC = g++
CFLAGS = -Wall -g

build: main.o recursion.o
	$(CC) $(CFLAGS) -o main.out main.o recursion.o

main.o: main.cpp recursion.h
	$(CC) $(CFLAGS) -c main.cpp

recursion.o: recursion.h # recursion.cpp
