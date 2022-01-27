// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

ymaps.ready(init);
function init() {
    var myMap = new ymaps.Map("map", {
        center: [54.88, 38.07],
        zoom: 12,
        controls: ['zoomControl'],
        behaviors: ['drag']
    });

    var placemark = new ymaps.Placemark([54.88, 38.07], {
        hintContent: 'Это хинт',
        balloonContent: 'This is balloon'

    });

    myMap.geoObjects.add(placemark);

}