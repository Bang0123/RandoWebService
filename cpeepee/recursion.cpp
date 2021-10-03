#include "recursion.h"

namespace Recursion {
    int fibb(int n)
    {
        if (n <= 1)
            return n;
        return fibb(n - 1) + fibb(n - 2);
    }
}

