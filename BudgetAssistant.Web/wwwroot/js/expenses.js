document.addEventListener('DOMContentLoaded', () => {
    var catDialog = document.getElementById("categoryDialog");
    var newTabButton = document.getElementById("newCat");

    newTabButton.addEventListener("click", () => {
        catDialog.style.display = "block";
    });

    catDialog.addEventListener("click", e => {
        if (!e.target.matches('#dialog') && !e.target.matches('#frm')) {
            catDialog.style.display = "none";
        }
    });
})