// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let curtain = document.getElementById("curten");
let nav = document.getElementById("nav");

curtain.addEventListener("click", () => {
    nav.classList.toggle("hidden")
})