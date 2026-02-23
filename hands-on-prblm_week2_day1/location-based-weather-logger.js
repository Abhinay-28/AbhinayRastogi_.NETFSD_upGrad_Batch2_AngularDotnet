window.onload = function () {
    loadHistory();
};

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success, error);
    } else {
        document.getElementById("currentLocation").innerText =
            "Geolocation not supported";
    }
}

function success(position) {
    let latitude = position.coords.latitude;
    let longitude = position.coords.longitude;

    document.getElementById("currentLocation").innerText =
        "Latitude: " + latitude + " | Longitude: " + longitude;

    saveLocation(latitude, longitude);
    loadHistory();
}

function error(err) {
    let message = "";

    switch (err.code) {
        case err.PERMISSION_DENIED:
            message = "Permission denied";
            break;
        case err.POSITION_UNAVAILABLE:
            message = "Location unavailable";
            break;
        case err.TIMEOUT:
            message = "Request timeout";
            break;
        default:
            message = "Unknown error";
    }

    document.getElementById("currentLocation").innerText = message;
}

function saveLocation(lat, long) {
    let history = localStorage.getItem("locations");
    history = history ? JSON.parse(history) : [];

    history.unshift({ latitude: lat, longitude: long });

    if (history.length > 5) {
        history.pop();
    }

    localStorage.setItem("locations", JSON.stringify(history));
}

function loadHistory() {
    let history = localStorage.getItem("locations");
    history = history ? JSON.parse(history) : [];

    let list = document.getElementById("history");
    list.innerHTML = "";

    history.forEach(function (item) {
        let li = document.createElement("li");
        li.innerText =
            "Lat: " + item.latitude + " | Long: " + item.longitude;
        list.appendChild(li);
    });
}
