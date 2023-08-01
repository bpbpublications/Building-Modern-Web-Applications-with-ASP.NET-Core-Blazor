var reference = {};

function internalDraw(number, audio) {
    var result = 'Thank you for your purchasing!';
    if (number === 'winner') {
        result = 'Congratulations! You win a FREE item!'
        audio.play();
    }

    return result;
}

export function getRef(ref) {
    reference = ref;
}

export function draw(number, audio) {
    var result = internalDraw(number, audio);
    reference.invokeMethodAsync('display', result);
}
