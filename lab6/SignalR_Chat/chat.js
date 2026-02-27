connection.on("ReceiveMessage", function (user, message) {
    const li = document.createElement("li");
    li.style.marginBottom = "10px";
    li.style.padding = "10px 15px";
    li.style.borderRadius = "10px";
    li.style.background = "white";
    li.style.boxShadow = "0 2px 4px rgba(0,0,0,0.05)";
    
    // Выделяем имя жирным и добавляем время
    const time = new Date().toLocaleTimeString([], {hour: '2-digit', minute:'2-digit'});
    li.innerHTML = `<strong style="color: #2563eb;">${user}</strong> <span style="font-size: 0.7rem; color: #94a3b8; margin-left: 10px;">${time}</span><br>${message}`;
    
    document.getElementById("messagesList").appendChild(li);
    // Прокрутка вниз
    const container = document.getElementById("messagesListContainer");
    container.scrollTop = container.scrollHeight;
});