<?php
if (!isset($_SESSION['user'])) {
    header('Location: index.php');
}
?>
<!DOCTYPE html>
<html lang="hu">
    <head>
        <title>Ingatlanok | IngatlanCentrum</title>
        <?php require_once 'html/head.html'; ?>
    </head>
    <body>
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <?php require_once 'html/navbar.php'; ?>
                    <h6>Üdvözöljük <?php echo $_SESSION['username']; ?>!</h6>
                    <?php require_once 'html/footer.php'; ?>
                </div>
            </div>
        </div>
    </body>
</html>
