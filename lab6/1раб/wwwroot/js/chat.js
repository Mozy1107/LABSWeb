const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

const statusText = document.getElementById("status");
const statusBadge = document.getElementById("statusBadge");

connection.on("ReceiveMessage", function (user, message) {
    const container = document.getElementById("messagesList");
    const msg = document.createElement("div");
    msg.className = "message-item mb-2";
    const time = new Date().toLocaleTimeString('ru-RU');
    msg.innerHTML = `<div><strong>${user}</strong> <small class="text-muted">${time}</small></div><div>${message}</div>`;
    container.appendChild(msg);
    container.scrollTop = container.scrollHeight;
});

connection.on("UserConnected", function (connectionId) {
    const container = document.getElementById("messagesList");
    const note = document.createElement("div");
    note.className = "system-note mb-2 text-success";
    note.textContent = `✅ Пользователь подключился`;
    container.appendChild(note);
    container.scrollTop = container.scrollHeight;
});

connection.on("UserDisconnected", function (connectionId) {
    const container = document.getElementById("messagesList");
    const note = document.createElement("div");
    note.className = "system-note mb-2 text-warning";
    note.textContent = `⚠️ Пользователь отключился`;
    container.appendChild(note);
    container.scrollTop = container.scrollHeight;
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    const user = document.getElementById("userInput").value;
    const message = document.getElementById("messageInput").value;
    
    if (user && message) {
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        document.getElementById("messageInput").value = "";
    }
    event.preventDefault();
});

document.getElementById("messageInput").addEventListener("keypress", function(event) {
    if (event.key === "Enter") {
        document.getElementById("sendButton").click();
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    if (statusText) statusText.textContent = "Подключен";
    if (statusBadge) { statusBadge.textContent = "Подключен"; statusBadge.className = "badge bg-success"; }
    console.log("SignalR подключен");
}).catch(function (err) {
    if (statusText) statusText.textContent = "Ошибка";
    if (statusBadge) { statusBadge.textContent = "Ошибка"; statusBadge.className = "badge bg-danger"; }
    return console.error(err.toString());
});
