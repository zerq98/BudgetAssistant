var prevScrollpos = window.pageYOffset;
window.onscroll = function () {
    var currentScrollPos = window.pageYOffset;
    if (currentScrollPos == 0) {
        document.getElementById("bignav").style.height = "90px";
    } else {
        document.getElementById("bignav").style.height = "70px";
    }
    prevScrollpos = currentScrollPos;
}