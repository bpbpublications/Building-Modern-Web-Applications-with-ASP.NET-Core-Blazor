const connection = new signalR.HubConnectionBuilder()
    .withUrl('/Notification')
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log('SignalR Connected.');
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

// Listen for `DOMContentLoaded` event
document.addEventListener('DOMContentLoaded', (e) => {
    document.getElementById('btn').addEventListener('click', send);
});

async function send(e) {
    const message = document.getElementById('txt').value;
    console.log(message);

    try {
        await connection.invoke('Notify', message);
    } catch (err) {
        console.error(err);
    }
}

connection.on('onReceived', (message) => {
    const li = document.createElement('li');
    li.textContent = message;
    document.getElementById('notifications').appendChild(li);
});

connection.onclose(async() => {
    await start();
});

// Start the connection.
start();