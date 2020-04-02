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
                    <?php
                    require_once 'html/navbar.php';

                    if (!isset($_SESSION['user'])) {
                        header('Location: index.php');
                    }
                    ?>
                    <h6>Üdvözöljük <?php echo $_SESSION['username']; ?>!</h6>
                    <div id="keresofelulet">
                        <table class="table table-striped">
                            <tr>
                                <td>Település</td>
                                <td>
                                    <select id="varosok" class=" form-control">

                                    </select>
                                </td>
                                <td colspan="2">Típus</td>
                            </tr>
                            <tr>
                                <td>Ár min. M. Ft</td>
                                <td>
                                    <input type="text" class=" form-control">
                                </td>
                                <td><input type="checkbox" /> Panel</td>
                                <td><input type="checkbox" /> Tégla</td>
                            </tr>
                            <tr>
                                <td>Ár max. M. Ft</td>
                                <td>
                                    <input type="text" class=" form-control">
                                </td>

                                <td><input type="checkbox" /> Bérleti jog</td>
                                <td><input type="checkbox" /> Családi ház</td>
                            </tr>
                            <tr>
                                <td>Alapterület</td>
                                <td>
                                    <select class=" form-control">
                                        <option>0 - 25 m2</option>
                                        <option>25 - 50 m2</option>
                                        <option>50 - 75 m2</option>
                                        <option>75 - 100 m2</option>
                                        <option>100 - m2</option>
                                    </select>
                                </td>
                                <td><input type="checkbox" /> Tanya</td>
                                <td><input type="checkbox" /> Garázs</td>
                            </tr>
                            <tr>
                                <td>Szobák száma</td>
                                <td>
                                    <select class=" form-control">
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                        <option>6</option>
                                        <option>7</option>
                                        <option>8</option>
                                        <option>9</option>
                                        <option>10</option>
                                    </select>
                                </td>
                                <td><input type="checkbox" /> Kert</td>
                                <td><button class="btn btn-primary" id="keresIngatlan">Mehet</button></td>
                            </tr>
                        </table> 
                    </div>
                    <div id="ingatlanok"></div>
                    <?php require_once 'html/footer.php'; ?>
                </div>
            </div>
        </div>
    </body>
</html>
