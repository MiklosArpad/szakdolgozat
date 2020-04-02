<!DOCTYPE html>
<html lang="hu">
    <head>        
        <?php require_once 'html/head.html'; ?>
        <title>Bejelentkezés | IngatlanCentrum</title>
    </head>
    <body>
        <div class="container-fluid">
            <?php require_once 'html/navbar.php'; ?>
            <form id="login_form" class="row">
                <input class="form-control" id="username" type="text" placeholder="Felhasználónév">
                <input class="form-control" id="password" type="password" placeholder="Jelszó">
                <input class="btn btn-primary" id="login" type="submit" value="Belépés">
            </form>
        </div>
    </body>
</html>
