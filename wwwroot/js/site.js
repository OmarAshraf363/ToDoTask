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


function del(id) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            }).then(() => {
                window.location.href = `/task/Delete/${id}`
            });
        }
    });
}

//Add comment
function add(tskId, usId) {
    var editModal = new bootstrap.Modal(document.getElementById("exampleModal"));
    editModal.show();
    document.getElementById("userId").value = usId;
    document.getElementById("taskId").value = tskId;

}
