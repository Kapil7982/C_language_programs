#include <stdio.h>                     //It is for input/output library. which provides the function for input and output.
int main(int argc, char const *argv[]) // It is the main method for executing the program.
{
    int num, num1;

    printf("Enter the first number: ");
    scanf("%d", &num); // It is reading the input and %d is format specifier for reading the integer value.

    printf("Enter the second number: ");
    scanf("%d", &num1);

    int sum = num + num1;
    printf("Addition of: %d + %d = %d\n", num, num1, sum);

    int diff = num - num1;
    printf("Substraction of: %d - %d = %d\n", num, num1, diff);

    int prod = num * num1;
    printf("Multiply of: %d * %d = %d\n", num, num1, prod);

    if (num1 != 0)
    {
        float divi = (float)num / num1;
        printf("Division of: %d / %d = %.2f\n", num, num1, divi);
    }
    else
    {
        printf("Division by zero is undefined.\n");
    }

    return 0;
}

// The command for running the above program is "gcc ArithmeticOperators.c -o ArithmeticOperators" and then "./ArithmeticOperators".