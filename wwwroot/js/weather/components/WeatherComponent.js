import {getCitiesByFilter} from "../api/getCitiesByFilter.js";
import {getWeatherInCity} from "../api/getWeatherInCity.js";

export class WeatherComponent {
    
    elements = {
        cityInput: null,
        citiesList: null,
        weatherDetails: null,
        alertAboutRain: null
    }
    constructor(options) {
        
        this.elements = options.elements;
        this.#initializeEvents();
        this.#initializeElements();
    }
    
    #initializeElements() {     
        const lastCity = getLastCity();
        if(lastCity == null) {
            return;
        }
        
        this.elements.cityInput.value = lastCity;

        const event = new Event('input');
        this.elements.cityInput.dispatchEvent(event);
    }

    #initializeEvents(){
        this.elements.alertAboutRain.querySelector("#close-warning-message-button").addEventListener("click", (event)=>{
            this.elements.alertAboutRain.classList.add("d-none");
        })
        this.elements.cityInput.addEventListener('input', async (event) => {
            const citySearchKey = event.target.value;
            this.elements.weatherDetails.innerHTML = '';
            
            if (citySearchKey.length < 3) {
                this.elements.citiesList.innerHTML = '';
                return;
            }
            
            getCitiesByFilter(citySearchKey, async (cities) => {
                delay(300)
                this.elements.citiesList.innerHTML = '';

                if (cities && cities.length > 0) {
                    this.elements.citiesList.innerHTML = cities.map(city => `
                        <button class="btn btn-primary w-100 mb-2" data-city="${city}">${city}</button>
                    `).join('');

                    this.elements.citiesList.querySelectorAll('button').forEach(button => {
                        button.addEventListener('click', async () => {
                            const city = button.getAttribute('data-city');
                            await getWeatherInCity(city, (response) => {
                                this.#displayWeatherDetails(response);
                            });
                        });
                    });
                } else {
                    this.elements.citiesList.innerHTML = '<p>Cities not found</p>';
                }
            });


        });
    }
    
    #displayWeatherDetails(weatherData) {
        this.elements.weatherDetails.innerHTML = '';

        if (weatherData) {
            const weatherInfo = `
                    <h4>Weather for city:     <${weatherData.name}></h4>
                    <p><strong>Max Temp:</strong> ${weatherData.tempMax} °C</p>
                    <p><strong>Min Temp:</strong> ${weatherData.tempMin} °C</p>
                    <p><strong>Description:</strong> ${weatherData.description}</p>
                    <p><strong>Wind speed:</strong> ${weatherData.windSpeed} m/s</p>
                `;
            this.elements.weatherDetails.innerHTML = weatherInfo;   

            if (weatherData.description.includes('rain') || weatherData.precipitation >= 1) {
                this.#showWeatherMessage(weatherData.name);
            }
        } else {
            this.elements.weatherDetails.innerHTML = '<p>Failed to get weather data</p>';
        }
    }

    #showWeatherMessage(city) {
        if(city == null)
            return;
        
        const cookiesForCity = getCookie(`checked_city_${city}`)
        if(cookiesForCity != null) {
            return;
        }
        
        this.elements.alertAboutRain.classList.remove("d-none");

        const today = new Date().toISOString().split('T')[0];
        saveCityToLocalStorage(city);
        setCookie(`checked_city_${city}`, city, 1);
    }
}