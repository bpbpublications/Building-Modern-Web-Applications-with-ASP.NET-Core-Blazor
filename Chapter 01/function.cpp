#include <emscripten.h>

extern "C"
{
    EMSCRIPTEN_KEEPALIVE
    int myAddFunc(int a, int b)
    {
        int c = a + b;
        return c;
    }

    EMSCRIPTEN_KEEPALIVE
    int myMinusFunc(int a, int b)
    {
        int c = a - b;
        return c;
    }
}
