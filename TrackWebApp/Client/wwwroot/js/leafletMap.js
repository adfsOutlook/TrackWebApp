// Función para inicializar el mapa
function initializeMap() {
    if (window.mapInstance) return; // Evita crear duplicados

    var map = L.map('map').setView([40.7128, -74.0060], 13);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    window.mapInstance = map; // Guarda el mapa en una variable global
}

// Función para dibujar el camino en el mapa
function dibujarCamino(coordenadasJson) {
    if (!window.mapInstance) {
        console.error("El mapa no está inicializado.");
        return;
    }
    var coordenadas = JSON.parse(coordenadasJson);

    // Construir las coordenadas directamente dentro de la función
    //var coordenadas2 = [
    //    { Lat: "40.7128", Lng: "-74.0060" }, // Nueva York
    //    { Lat: "34.0522", Lng: "-118.2437" }, // Los Ángeles
    //    { Lat: "41.8781", Lng: "-87.6298" }  // Chicago
    //];


    // Convertir las coordenadas de string a números
    var latLngs = coordenadas.map(function (item) {
        if (item.Lat && item.Lng) {
            return [parseFloat(item.Lat), parseFloat(item.Lng)]; // Convertir a números
        }
    });

    // Asegurarse de que las coordenadas sean válidas
    if (latLngs && latLngs.length > 0) {
        // Dibujar el camino en el mapa
        var polyline = L.polyline(latLngs, { color: 'blue' }).addTo(window.mapInstance);

        // Ajustar el mapa para que se ajuste al camino dibujado
        window.mapInstance.fitBounds(polyline.getBounds());
    } else {
        console.error("No se recibieron coordenadas válidas.");
    }
}
