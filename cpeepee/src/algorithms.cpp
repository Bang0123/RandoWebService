#include "algorithms.h"

Algorithms::Algorithms()
{
}

int Algorithms::Fibonacci(int n)
{
    if (n <= 1)
        return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

// Fast Inverse Square Root — A Quake III Algorithm from youtube
float Algorithms::Q_rsqrt(float number) {
    long i;
    float x2, y;
    const float threehalfs = 1.5F;
    
    x2 = number * 0.5F;
    y = number;
    i = * (long *) &y;
    i = 0x5f3759df - (i >> 1);
    y = * (float *) &i;
    y = y * (threehalfs - (x2 * y * y));
    // y = y * (threehalfs - (x2 * y * y));

    return y;
}