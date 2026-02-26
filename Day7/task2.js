async function fetchWeather() {
  try {
    const public_url =
      'https://api.open-meteo.com/v1/forecast?latitude=18.52&longitude=73.85&current=temperature_2m,wind_speed_10m&timezone=Asia/Kolkata';

    const response = await fetch(public_url);
    const value = await response.json();
    const weather = value.current;  

    console.log(`
                Weather Report (Async/Await)
                Temperature: ${weather.temperature_2m}°C
                Wind Speed : ${weather.wind_speed_10m} km/h
                Time       : ${weather.time}
    `);

     const weatherData = {
      Temperature: weather.temperature_2m + " °C",
      WindSpeed: weather.wind_speed_10m + " km/h",
      Time: weather.time,
      Location: "Pune"
    };


    console.table(weatherData);


  } catch (error) {
    console.log("Error:", error.message);
  }
}

fetchWeather();