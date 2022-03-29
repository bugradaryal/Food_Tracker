function keyDown(e) {
    var e = window.event || e;
    var key = e.keyCode;
    //space pressed
    if (key == 32) { //space
        e.preventDefault();
    }
}