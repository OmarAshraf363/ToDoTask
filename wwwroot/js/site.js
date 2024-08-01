let all = document.querySelectorAll(".sidenav-item a");

all.forEach(e => {
    e.onclick = function () {

        all.forEach(link => link.classList.remove("active"));


        e.classList.add("active");


        localStorage.setItem('activeLink', e.href);
    }
});
document.addEventListener('DOMContentLoaded', (event) => {
    let activeLink = localStorage.getItem('activeLink');
    if (activeLink) {
        all.forEach(e => {
            if (e.href === activeLink) {
                e.classList.add("active");
            } else {
                e.classList.remove("active");
            }
        });
    }
});
