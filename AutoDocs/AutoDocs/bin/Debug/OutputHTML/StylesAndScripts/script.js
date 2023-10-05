function toggleVariable(element) {
    const details = element.parentElement.nextElementSibling;
    if (details.style.display === "block") {
        details.style.display = "none";
        element.innerText = "+";
    } else {
        details.style.display = "block";
        element.innerText = "-";
    }
}

document.addEventListener("DOMContentLoaded", function(event) { 
    hljs.initHighlightingOnLoad();
});