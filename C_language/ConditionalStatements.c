#include <stdio.h>

int main(int argc, char const *argv[])
{
    int n;

    printf("Enter the number: ");
    scanf("%d", &n);

    if (n % 3 == 0 && n % 5 == 0)
    {
        printf("This number %d is divisible by both 3 and 5.\n", n);
    }
    else if (n % 3 == 0 || n % 5 == 0)
    {
        printf("This number %d is divisible by 3 or 5.\n", n);
    }
    else
    {
        printf("This number %d is neither divisible by 3 nor 5.\n", n);
    }

    return 0;
}
