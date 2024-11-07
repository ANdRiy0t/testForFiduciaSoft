
export async function getWeatherInCity(city, callback) {

    try {
        const response = await fetch(`/api/weather?citySearchKey=${city}`);
        if (!response.ok) {
            console.error('Failed to fetch weather');
            callback(null);
            return;
        }
        callback(await response.json());
    } catch (error) {
        console.error('Error fetching weather:', error);
        callback(null);
        throw error;
    }

}