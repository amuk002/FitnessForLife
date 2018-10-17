/**
* This is a simple JavaScript demonstration of how to call MapBox API to load the maps.
* I have set the default configuration to enable the geocoder and the navigation control.
* https://www.mapbox.com/mapbox-gl-js/example/popup-on-click/
*
* @author Aditi Mukhopadhyay <amuk0002@student.monash.edu>
*/
const TOKEN = 'pk.eyJ1IjoiYWRpcm9ja3M5NSIsImEiOiJjamdsbnk0eDYxcXRsMndwcXd6cXN3cnpkIn0.LlXsl3N7xpZgew8vVx6rnw';

var locations = [];
// The first step is obtain all the latitude and longitude from the HTML
// The below is a simple jQuery selector
$(".location").each(function () {
    var address = $(".address", this).text().trim();
    var description = $(".description", this).text().trim();
    // Create a point data structure to hold the values.
    var point = {
        "address": address,
        "description": description
    };
    // Push them all into an array.
    locations.push(point);
});

mapboxgl.accessToken = TOKEN;
var mapboxClient = mapboxSdk({ accessToken: mapboxgl.accessToken });
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v9',
    center: [145.04583700, -37.87682300],
    zoom: 10
});



for (i = 0; i < locations.length; i++) {
    mapboxClient.geocoding.forwardGeocode({
        query: locations[i].address,
        autocomplete: false,
        limit: 1
    })
    .send()
    .then(function (response) {
        if (response && response.body && response.body.features && response.body.features.length) {
            var feature = response.body.features[0];

        new mapboxgl.Marker()
                    .setLngLat(feature.center)
                    .addTo(map);
        }
    });
}