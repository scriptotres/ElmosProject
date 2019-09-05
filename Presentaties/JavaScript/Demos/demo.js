const button = document.querySelector("button");
const output = document.querySelector("output");

button.addEventListener("click", e => {
    output.textContent = Math.random().toString(26).slice(2);
});