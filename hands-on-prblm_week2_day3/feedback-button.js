const button = document.getElementById("feedbackBtn");
const message = document.getElementById("message");

button.addEventListener("click", function () {
    message.textContent = "Thank you! Your feedback has been submitted successfully.";
});