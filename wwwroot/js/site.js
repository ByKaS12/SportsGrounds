// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

ymaps.ready(init);
async function my_callback() {
    let url ='https://search-maps.yandex.ru/v1/?text=category_id:(77500452834)&ll=38.078237,54.88628&spn=0.052069,0.050552&rspn=1&results=500&lang=ru_RU&apikey=b4a7ecbb-6ea1-40ba-b43d-03efb446b4a9'
    let response = await fetch(url)
    console.log(response)
    let data = await response.json()
    console.log(data)
}


function init() {
    var myMap = new ymaps.Map("map", {
        center: [55.75322, 37.622513],
        zoom: 10,
        controls: ['zoomControl'],
        behaviors: ['drag']
    });

    var location = ymaps.geolocation.get();
   
    var searchControl = new ymaps.control.SearchControl({
        options: {
            provider: 'yandex#search',
            boundedBy: [54.878, 38.0499][54.903, 38.097],
            strictBounds: true,
            size: 'small',
            useMapBounds: true
           
        }
    });
    myMap.controls.add(searchControl);
   
    searchControl.search('category_id:(77500452834)').then(function () {
        var geoObjectsArray = searchControl.getResultsArray();
        if (geoObjectsArray.length) {
            // Выводит свойство name первого геообъекта из результатов запроса.
            
            console.log(searchControl.getResultsCount());
            console.log(searchControl.options.boundedBy());
        }
    });
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

    var myGeocoder = ymaps.geocode("Ступино", {
        
        // Ограничение поиска видимой областью карты.
      //  boundedBy: myMap.getBounds(),
        // Жесткое ограничение поиска указанной областью.
      // strictBounds: true
    });
    myGeocoder.then(function (res) {
        myMap.geoObjects.add(res.geoObjects);

    });
    var myButton = new ymaps.control.Button("Hide results");
    myButton.events.add('click', function () {
        searchControl.hideResult();
    }, this);
    myMap.controls.add(myButton, { selectOnClick: false });
}