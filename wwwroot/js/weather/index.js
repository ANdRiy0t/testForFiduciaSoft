import {WeatherComponent} from "./components/WeatherComponent.js";


export function renderPage(options) {
    const weatherComponent = new WeatherComponent({
        elements:{
            cityInput: document.getElementById('city-search-input'),
            citiesList: document.getElementById('city-list'),
            weatherDetails: document.getElementById('weather-details'),
            alertAboutRain: document.getElementById('alert-today-rain'),
        }
    });
}