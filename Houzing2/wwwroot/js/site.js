// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let pageShow = document.querySelector("#page-register-item");
const body = document.querySelector("#body");
const overlay = document.querySelector("#overlay");
const closeBtn = document.querySelector(".close-btn");
pageShow.style.display = "none";
function showModal() {
    pageShow.style.display = "block";
    body.classList.add("overlay");
}
document.addEventListener("keydown", (e) => {
    if (e.keyCode = "Escape") {
        pageShow.style.display = "none";
        body.classList.remove("overlay");
    }
});

overlay.addEventListener("click", () => {
    console.log("Click")
    pageShow.style.display = "none";
    body.classList.remove("overlay");
});

closeBtn.addEventListener("click", () => {
    pageShow.style.display = "none";
    body.classList.remove("overlay");
})

