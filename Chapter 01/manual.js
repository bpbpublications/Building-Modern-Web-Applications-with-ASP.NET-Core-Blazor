var array1 = [0, 97, 115, 109, 1, 0, 0, 0, 1, 23, 5, 96, 0, 1, 127, 96, 0, 0, 96, 2, 127, 127, 1, 127, 96, 1, 127, 0, 96, 1, 127, 1, 127, 3, 7, 6, 1, 2, 0, 3, 4, 0, 4, 5, 1, 112, 1, 2, 2, 5, 6, 1, 1, 128, 2, 128, 2, 6, 9, 1, 127, 1, 65, 144, 136, 192, 2, 11, 7, 128, 1, 8, 6, 109, 101, 109, 111, 114, 121, 2, 0, 14, 109, 121, 77, 117, 108, 116, 105, 112, 108, 121, 70, 117, 110, 99, 0, 1, 25, 95, 95, 105, 110, 100, 105, 114, 101, 99, 116, 95, 102, 117, 110, 99, 116, 105, 111, 110, 95, 116, 97, 98, 108, 101, 1, 0, 11, 95, 105, 110, 105, 116, 105, 97, 108, 105, 122, 101, 0, 0, 16, 95, 95, 101, 114, 114, 110, 111, 95, 108, 111, 99, 97, 116, 105, 111, 110, 0, 5, 9, 115, 116, 97, 99, 107, 83, 97, 118, 101, 0, 2, 12, 115, 116, 97, 99, 107, 82, 101, 115, 116, 111, 114, 101, 0, 3, 10, 115, 116, 97, 99, 107, 65, 108, 108, 111, 99, 0, 4, 9, 7, 1, 0, 65, 1, 11, 1, 0, 10, 48, 6, 3, 0, 1, 11, 7, 0, 32, 0, 32, 1, 108, 11, 4, 0, 35, 0, 11, 6, 0, 32, 0, 36, 0, 11, 16, 0, 35, 0, 32, 0, 107, 65, 112, 113, 34, 0, 36, 0, 32, 0, 11, 5, 0, 65, 128, 8, 11];

var array2 = Uint8Array.from(array1);

WebAssembly.instantiate(array2).then(({ instance }) => {
    console.log(`3 * 4 = ${instance.exports.myMultiplyFunc(3, 4)}`);
});