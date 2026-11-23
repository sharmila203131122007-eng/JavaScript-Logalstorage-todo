let tasks = [];

function saveTasks() {
    try {
        localStorage.setItem("tasks", JSON.stringify(tasks));
    } catch (error) {
        console.log("Save error:", error);
    }
}

function loadTasks() {
    try {
        tasks = JSON.parse(localStorage.getItem("tasks")) || [];
    } catch (error) {
        tasks = [];
        console.log("Read error:", error);
    }
    displayTasks();
}

function addTask() {
    let input = document.getElementById("taskInput");

    if (input.value.trim() === "") return;

    tasks.push(input.value);
    saveTasks();
    displayTasks();
    input.value = "";
}

function displayTasks() {
    let list = document.getElementById("taskList");
    list.innerHTML = "";

    tasks.forEach((task, index) => {
        let li = document.createElement("li");
        li.textContent = task + " ";

        let btn = document.createElement("button");
        btn.textContent = "Delete";

        btn.onclick = function() {
            tasks.splice(index, 1);
            saveTasks();
            displayTasks();
        };

        li.appendChild(btn);
        list.appendChild(li);
    });
}

loadTasks();
