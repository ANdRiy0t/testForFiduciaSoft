export async function getCitiesByFilter(citySearchKey, callback) {
    try {
        const response = await fetch(`/api/weather/city/find?citySearchKey=${citySearchKey}`);
        if (!response.ok) {
            console.error(`Failed to fetch cities: ${response.status}`);
            callback(null);
            return;
        }
        callback(await response.json());
    } catch (error) {
        console.error('Error fetching cities:', error);
        callback(null);
        throw error;
    }
}
