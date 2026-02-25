// MODULE STATE
let tasks = [];

// DOM ELEMENTS
const input = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");


// ---------- RENDER FUNCTION ----------
const renderTasks = () => {

    taskList.innerHTML = tasks.map((task, index) => `
        <li data-index="${index}" class="${task.completed ? "completed" : ""}">
            <span>${task.text}</span>
            <div>
                <button class="complete">✔</button>
                <button class="delete">❌</button>
            </div>
        </li>
    `).join("");
};


// ---------- ADD TASK ----------
const addTask = () => {

    const text = input.value.trim();

    if(!text) return;

    tasks.push({
        text,
        completed:false
    });

    input.value="";
    renderTasks();
};


// ---------- EVENT DELEGATION ----------
const handleTaskActions = (e) => {

    const li = e.target.closest("li");
    if(!li) return;

    const index = li.dataset.index;

    if(e.target.classList.contains("delete")){
        tasks.splice(index,1);
    }

    if(e.target.classList.contains("complete")){
        tasks[index].completed =
            !tasks[index].completed;
    }

    renderTasks();
};


// ---------- EVENTS ----------
addBtn.addEventListener("click", addTask);

taskList.addEventListener("click", handleTaskActions);