function myMap() {
    var mapCanvas = document.getElementById("googleMap");
    var myCenter = new google.maps.LatLng(-33.3318801, -70.7107504);
    var mapOptions = { center: myCenter, zoom: 16 };
    var map = new google.maps.Map(mapCanvas, mapOptions);
    var marker = new google.maps.Marker({
        position: myCenter,
        animation: google.maps.Animation.BOUNCE
    });
    marker.setMap(map);
}