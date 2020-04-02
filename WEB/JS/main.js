$(document).ready(function () {

    $.ajax({
        method: "get",
        url: "php_ajax/varosok.php",
        success: function (answer) {
            $('#varosok').html(answer);
        },
        error: function (xhr) {
            alert(xhr.status);
        }
    });

    $.ajax({
        method: "get",
        url: "php_ajax/ingatlanok_lekerdezes.php",
        success: function (answer) {
            $('#ingatlanok').html(answer);
        },
        error: function (xhr) {
            alert(xhr.status);
        }
    });

    $("#login").click(function (e) {

        e.preventDefault();

        let username = $("#username").val();
        let password = $("#password").val();

        $.ajax({
            method: "post",
            url: "php_ajax/login.php",
            data: {
                "username": username,
                "password": password
            },
            success: function (data) {
                if (data === "Sikeres") {
                    location.href = "ingatlanok.php";
                } else {
                    alert("Nem jó a felhasználónév vagy jelszó!")
                }
            }
        })

    });

});
