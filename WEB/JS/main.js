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
        let min_alapterulet = $('#min_alapterulet').val();
        let max_alapterulet = $('#max_alapterulet').val();
        let allapot = $('#allapotok').val();
        let szobaszam = $('#szobaszam').val();
        let min_ar = $('#min_ar').val();
        let max_ar = $('#max_ar').val();

        if (min_alapterulet === "0") {
            min_alapterulet = "1";
        }

        if (min_ar === "0") {
            min_ar = "1";
        }

        $.ajax({
            method: "post",
            url: "php_ajax/ingatlanok_szures.php",
            data: {
                "telepules": telepules,
                "kategoria": kategoria,
                "min_alapterulet": min_alapterulet,
                "max_alapterulet": max_alapterulet,
                "allapot": allapot,
                "szobaszam": szobaszam,
                "min_ar": min_ar,
                "max_ar": max_ar
            },
            success: function (answer) {
                $('#osszes_hirdetes').remove();
                $('#ingatlanok').html(answer);
            },
            error: function (xhr) {
                alert(xhr.status);
            }
        });

    });

});
