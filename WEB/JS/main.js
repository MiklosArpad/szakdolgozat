$(document).ready(function () {

    $.ajax({
        method: "get",
        url: "php_ajax/telepulesek.php",
        success: function (answer) {
            $('#telepulesek').html(answer);
        },
        error: function (xhr) {
            alert(xhr.status);
        }
    });

    $.ajax({
        method: "get",
        url: "php_ajax/kategoriak.php",
        success: function (answer) {
            $('#kategoriak').html(answer);
        },
        error: function (xhr) {
            alert(xhr.status);
        }
    });

    $.ajax({
        method: "get",
        url: "php_ajax/allapotok.php",
        success: function (answer) {
            $('#allapotok').html(answer);
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

    $("#login").on('click', function (e) {

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


    $('#keresIngatlan').on('click', function () {

        let telepules = $('#telepulesek').val();
        let kategoria = $('#kategoriak').val();
        let alapterulet = $('#alapterulet').val();
        let allapot = $('#allapotok').val();
        let szobaszam = $('#szobaszam').val();
        let ar = $('#ar').val();

        console.log(telepules);
        $.ajax({
            method: "get",
            url: "php_ajax/ingatlanok_szures.php",
            data: {
                "telepules": telepules,
                "kategoria": kategoria,
                "alapterulet": alapterulet,
                "allapot": allapot,
                "szobaszam": szobaszam,
                "ar": ar
            },
            success: function (answer) {
                $('#ingatlanok').html(answer);
            },
            error: function (xhr) {
                alert(xhr.status);
            }
        });

    });

});
