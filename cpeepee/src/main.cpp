#include <iostream>
#include <string>
#include <stdio.h>
#include "recursion.h"

using namespace std;

int main() {
    cout << "Hello World\n";
    Recursion recursion;
    cout << recursion.Fibonacci(2) << endl;
    cout << recursion.Fibonacci(9) << endl;
    return 0;
}
