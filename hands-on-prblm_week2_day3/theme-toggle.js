const body = document.body;
const button = document.getElementById("toggleBtn");

const savedTheme = localStorage.getItem("theme");

if(savedTheme){
    body.className = savedTheme;
}

button.addEventListener("click", () => {

    if(body.classList.contains("light")){
        body.classList.remove("light");
        body.classList.add("dark");
        localStorage.setItem("theme","dark");
    }
    else{
        body.classList.remove("dark");
        body.classList.add("light");
        localStorage.setItem("theme","light");
    }

});