window.onload = function () {
    let savedNote = localStorage.getItem("dailyNote");
    if (savedNote !== null) {
        document.getElementById("note").value = savedNote;
    }
};

function saveNote() {
    let noteText = document.getElementById("note").value;
    localStorage.setItem("dailyNote", noteText);
    alert("note successfully saved in localstorage")
}

function clearNote() {
    localStorage.removeItem("dailyNote");
    document.getElementById("note").value = "";
}