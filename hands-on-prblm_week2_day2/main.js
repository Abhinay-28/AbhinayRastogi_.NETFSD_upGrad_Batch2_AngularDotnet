import {
    addTaskCallback,
    listTasksCallback,
    deleteTaskCallback,
    addTaskPromise,
    listTasksPromise,
    deleteTaskPromise,
    addTaskAsync,
    listTasksAsync,
    deleteTaskAsync
} from "./task-manager.js";



addTaskCallback("Study JS", msg => {
    console.log(msg);

    listTasksCallback(tasks => {
        console.log(`Tasks (Callback): ${tasks.join(", ")}`);
    });
});



addTaskPromise("Practice Coding")
    .then(msg => {
        console.log(msg);
        return listTasksPromise();
    })
    .then(tasks =>
        console.log(`Tasks (Promise): ${tasks.join(", ")}`)
    );



const runAsync = async () => {
    console.log(await addTaskAsync("Build Project"));
    console.log(await deleteTaskAsync("Study JS"));

    const tasks = await listTasksAsync();
    console.log(`Tasks (Async/Await): ${tasks.join(", ")}`);
};

runAsync();