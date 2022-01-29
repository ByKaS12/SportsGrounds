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

    var location = ymaps.geolocation.get();

    var searchControl = new ymaps.control.SearchControl({
        options: {
            provider: 'yandex#search'
        }
    });
    myMap.controls.add(searchControl);
    searchControl.search('category_id:(77500452834)')
    console.log(searchControl.getResultsCount());
    
    // Асинхронная обработка ответа.
    location.then(
        function (result) {
            // Добавление местоположения на карту.
            myMap.geoObjects.add(result.geoObjects)
        },
        function (err) {
            console.log('Ошибка: ' + err)
        }
    );
    var placemark = new ymaps.Placemark([54.88, 38.07], {
        hintContent: 'Это хинт',
        balloonContent: 'This is balloon'

    });

    myMap.geoObjects.add(placemark);

    var myGeocoder = ymaps.geocode("Ступино", {
        
        // Ограничение поиска видимой областью карты.
      //  boundedBy: myMap.getBounds(),
        // Жесткое ограничение поиска указанной областью.
      // strictBounds: true
    });
    myGeocoder.then(function (res) {
        myMap.geoObjects.add(res.geoObjects);

    });

   
}