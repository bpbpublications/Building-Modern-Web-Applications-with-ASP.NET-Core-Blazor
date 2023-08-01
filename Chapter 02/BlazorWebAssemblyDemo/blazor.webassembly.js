await async function(e, t) {
    if ("function" == typeof WebAssembly.instantiateStreaming)
        try {
            return (await WebAssembly.instantiateStreaming(e.response, t)).instance
        } catch (e) {
            console.info("Streaming compilation failed. Falling back to ArrayBuffer instantiation. ", e)
        }
    const n = await e.response.then((e => e.arrayBuffer()));
    return (await WebAssembly.instantiate(n, t)).instance
}(t, e)