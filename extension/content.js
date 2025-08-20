let port;

const messageHandler = (e) => {
    if(e.data.type !== 'Request')
        return;
    else
        port.postMessage(e.data);
}

const connect = () => {
    console.log("Connecting");
    port = chrome.runtime.connect();

    port.onMessage.addListener(function (message) {
        window.postMessage(message.message);
    });

    window.addEventListener("message", messageHandler);
};

(function() {
    connect();
})();