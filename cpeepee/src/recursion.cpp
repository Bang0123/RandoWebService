#include "recursion.h"

Recursion::Recursion(){

}

int Recursion::Fibonacci(int n)
{
    if (n <= 1)
        return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
