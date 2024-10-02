function successAlerts() {

    event.preventDefault();
    var form = event.target.form;
    Swal.fire({
        title: "Item Has Been Created!",
        confirmButtonText: "Amazing",
        confirmButtonColor: "#3085d6",
        showClass: {
            popup: `
              animate__animated
              animate__fadeInUp
              animate__faster
            `
        },
        hideClass: {
            popup: `
              animate__animated
              animate__fadeOutDown
              animate__faster
            `
        }
    }).then((result) => {
        if (result.value) {
            form.submit();
        }
    })
}

function deleteAlert() {
    event.preventDefault();
    var form = event.target.form;
    Swal.fire({
        icon: "warning",
        title: "Are You Sure You Want To Delete?",
        showDenyButton: true,
        confirmButtonText: "Hell yeah!",
        showClass: {
            popup: `
                              animate__animated
                              animate__fadeInUp
                              animate__faster
                            `
        },
        hideClass: {
            popup: `
                              animate__animated
                              animate__fadeOutDown
                              animate__faster
                            `
        }
    }).then((result) => {
        if (result.value) {
            form.submit();

        }
    })
}

function updateAlert() {
    event.preventDefault();
    var form = event.target.form;
    Swal.fire({
        title: " Item Has Been Updated!",
        confirmButtonText: "Oh yeah!",
        confirmButtonColor: "#3085d6",
        showClass: {
            popup: `
                      animate__animated
                      animate__fadeInUp
                      animate__faster
                    `
        },
        hideClass: {
            popup: `
                      animate__animated
                      animate__fadeOutDown
                      animate__faster
                    `
        }
    }).then((result) => {
        if (result.value) {
            form.submit();
        }
    })
}