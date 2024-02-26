# U13 Weather API

## Description

This RESTful API allows developers to get real-time weather data for any location in the world. The API uses the OpenWeatherMap API to retrieve weather data and processes it for easier consumption.

## Features

* **Real-time weather data:** Temperature, humidity, wind speed, atmospheric pressure, etc.
* **Weather forecast:** Weather forecast for the next 7 days.
* **Search by city or zip code:** Get weather data for any location in the world.
* **JSON format:** Weather data is returned in JSON format for easy consumption.
* **Easy to use:** The API is easy to use and does not require any authentication.

## Endpoints

* `/weather/current?q={city}`: Gets the current weather for the specified city.
* `/weather/forecast?q={city}`: Gets the weather forecast for the specified city.

## Parameters

* `q`: The name of the city or the zip code.

## Example response

```json
{
  "cod": 200,
  "main": {
    "temp": 28.92,
    "humidity": 70,
    "pressure": 1013.25
  },
  "wind": {
    "speed": 4.1,
    "deg": 270
  },
  "weather": [
    {
      "main": "Clear sky"
    }
  ]
}
```

## Error codes

* `400`: Bad request.
* `404`: City not found.
* `500`: Internal server error.

## Limitations

* The API is limited to 1000 requests per day.

## Contributions

Contributions to this API are welcome. If you find any bugs or have any suggestions, please feel free to open an issue on GitHub.

## Links

* GitHub repository: [https://github.com/nanosassa/u13-weather-api](https://github.com/nanosassa/u13-weather-api)
* OpenWeatherMap API: [https://openweathermap.org/api](https://openweathermap.org/api)

## License

This API is licensed under the MIT License.

## Contact

If you have any questions or comments, please feel free to contact me by email at nanosassa@gmail.com
