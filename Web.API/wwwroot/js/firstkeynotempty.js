function keyDown(e) {
    var e = window.event || e;
    var key = e.keyCode;
    if (key === 32 && e.target.selectionStart === 0) {
        e.preventDefault();
    }
}