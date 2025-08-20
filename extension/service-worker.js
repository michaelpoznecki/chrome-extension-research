(function () {
  console.log("service worker running");
  chrome.runtime.onConnect.addListener(function (portExtension) {
    portExtension.onMessage.addListener(function(messageExtension) {
        var portNative = chrome.runtime.connectNative('com.my_company.my_app');
        if(portNative){
          console.log("Connected to client");
          console.log("command:", messageExtension.command);
        }
        portNative.onMessage.addListener(function (messageNative) {
          portExtension.postMessage({
            message: messageNative.message
          });
        });
        portNative.postMessage({
          command: messageExtension.command,
          parameters: messageExtension.parameters
        });
    });
  });
})();

