let tasks = [];

export const addTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks.push(task);
        callback(`Task added: ${task}`);
    }, 1000);
};

export const listTasksCallback = callback => {
    setTimeout(() => {
        callback(tasks);
    }, 1000);
};

export const deleteTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks = tasks.filter(t => t !== task);
        callback(`Task deleted: ${task}`);
    }, 1000);
};



export const addTaskPromise = task =>
    new Promise(resolve => {
        setTimeout(() => {
            tasks.push(task);
            resolve(`Task added: ${task}`);
        }, 1000);
    });

export const listTasksPromise = () =>
    new Promise(resolve => {
        setTimeout(() => {
            resolve(tasks);
        }, 1000);
    });

export const deleteTaskPromise = task =>
    new Promise(resolve => {
        setTimeout(() => {
            tasks = tasks.filter(t => t !== task);
            resolve(`Task deleted: ${task}`);
        }, 1000);
    });



export const addTaskAsync = async task => {
    return await addTaskPromise(task);
};

export const listTasksAsync = async () => {
    return await listTasksPromise();
};

export const deleteTaskAsync = async task => {
    return await deleteTaskPromise(task);
};
