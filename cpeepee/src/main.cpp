#include <iostream>
#include <string>
#include <stdio.h>
#include "recursion.h"

using namespace std;

int main() {
    cout << "Hello World\n";
    cout << Recursion::Fibonacci(2) << endl;
    cout << Recursion::Fibonacci(9) << endl;
    return 0;
}
