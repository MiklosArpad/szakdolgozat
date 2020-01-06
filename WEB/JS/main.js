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
    $("#belepes").click(function (e) {
        e.preventDefault(); // ne töltődjön újra az oldal -> alapértelmett működés letiltás

        let ugynokID = $("#ugynok_id").val();
        let jelszo = $("#ugynok_jelszo").val();
        $.ajax({
            method: "post",
            url: "php_ajax/login.php",
            data: {
                "ugynok_id": ugynokID,
                "jelszo": jelszo
            },
            success: function (data) {

                if (data == "Sikeres") {
                    location.href = "index.php"; // kliens oldali oldal átirányítás
                } else {

                    alert("Nem jó a felhasználónév vagy jelszó!")

                }
            }
        })

    });
});
