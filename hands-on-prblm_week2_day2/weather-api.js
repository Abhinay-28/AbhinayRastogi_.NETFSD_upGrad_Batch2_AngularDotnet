const apiURL =
"https://api.open-meteo.com/v1/forecast?latitude=28.61&longitude=77.23&current_weather=true";

const displayWeather = data => {
    const weather = data.current_weather;

    const report = `
Weather Report
Temperature: ${weather.temperature}°C
Wind Speed: ${weather.windspeed} km/h
Time: ${weather.time}
`;

    document.getElementById("output").textContent = report;
};

function getWeatherPromise() {
    fetch(apiURL)
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response failed");
            }
            return response.json();
        })
        .then(data => displayWeather(data))
        .catch(error => {
            document.getElementById("output").textContent =
                `Error: ${error.message}`;
        });
}

async function getWeatherAsync() {
    try {
        const response = await fetch(apiURL);

        if (!response.ok) {
            throw new Error("Failed to fetch weather");
        }

        const data = await response.json();
        displayWeather(data);

    } catch (error) {
        document.getElementById("output").textContent =
            `Error: ${error.message}`;
    }
}
