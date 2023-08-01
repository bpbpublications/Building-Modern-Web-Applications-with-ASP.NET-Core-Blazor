#include <emscripten.h>

extern "C"
{
    EMSCRIPTEN_KEEPALIVE
    int myMultiplyFunc(int a, int b)
    {
        int c = a * b;
        return c;
    }
}
