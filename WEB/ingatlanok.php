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
                    <fieldset id="keresofelulet">
                        <legend>Keresés</legend>
                        <table class="table table-striped">
                            <tr>
                                <td>Település</td>
                                <td><select id="telepulesek" class="form-control"><option></option></select></td>
                                <td>Kategória</td>
                                <td><select id="kategoriak" class="form-control"></select></td>
                            </tr>
                            <tr>
                                <td>Alapterület (m2)</td>
                                <td>
                                    <select class="form-control">
                                        <option></option>
                                        <option>0 - 1000</option>
                                        <option>1000 - 2000</option>
                                        <option>2000 - 5000</option>
                                        <option>5000 - 10000</option>
                                    </select>
                                </td>
                                <td>Állapot</td>
                                <td><select id="allapotok" class="form-control"></select></td>
                            </tr>
                            <tr>
                                <td>Szobaszám</td>
                                <td>
                                    <select class="form-control">
                                        <option></option>
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
                                <td>Ár (Forint)</td>
                                <td>
                                    <select class="form-control">
                                        <option></option>                                    
                                        <option>0 - 500 000</option>                                    
                                        <option>500 000 - 2 000 000</option>                                    
                                        <option>2 000 000 - 5 000 000</option>
                                        <option>5 000 000 - 10 000 000</option>
                                        <option>10 000 000 - 20 000 000</option>
                                        <option>20 000 000 - 50 000 000</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><button class="btn btn-primary" id="keresIngatlan">Mehet</button></td>
                            </tr>
                        </table> 
                    </fieldset>
                    <div id="ingatlanok"></div>
                </div>
            </div>
        </div>
    </body>
</html>
