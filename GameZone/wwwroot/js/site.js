
document.querySelector(".settings-box .fa-gear").onclick = function () {
    this.classList.toggle("fa-spin");
    document.querySelector(".settings-box ").classList.toggle("open");
};
// set main color on root
const colorsli = document.querySelectorAll(".colors-list li");
colorsli.forEach(li => {
    li.addEventListener("click", (e) => {
         document.documentElement.style.setProperty('--main-color', e.target.dataset.color)
    })
})


