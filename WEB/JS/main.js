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
        
        e.preventDefault();

        let felhasznalonev = $("#felhasznalonev").val();
        let $password = $("#$password").val();
        
        $.ajax({
            method: "post",
            url: "php_ajax/login.php",
            data: {
                "felhasznalonev": felhasznalonev,
                "$password": $password
            },
            success: function (data) {
                if (data === "Sikeres") {
                    location.href = "index.php";
                } else {
                    alert("Nem jó a felhasználónév vagy jelszó!")
                }
            }
        })

    });
});
