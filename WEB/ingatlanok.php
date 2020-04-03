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
                    <h4>Üdvözöljük <?php echo $_SESSION['username']; ?>!</h4>
                    <fieldset id="keresofelulet">
                        <legend>Keresés</legend>
                        <table class="table table-striped">
                            <tr>
                                <td>Település</td>
                                <td><select id="telepulesek" class="form-control"><option></option></select></td>
                                <td></td>
                                <td>Kategória</td>
                                <td><select id="kategoriak" class="form-control"></select></td>
                            </tr>
                            <tr>
                                <td>Alapterület (m2)</td>
                                <td>
                                    <select id="min_alapterulet" class="form-control">
                                        <option></option>
                                        <option>0</option>
                                        <option>1000</option>
                                        <option>2000</option>
                                        <option>5000</option>
                                    </select>
                                </td>
                                <td>
                                    <select id="max_alapterulet" class="form-control">
                                        <option></option>
                                        <option>1000</option>
                                        <option>2000</option>
                                        <option>5000</option>
                                        <option>10000</option>
                                    </select>
                                </td>
                                <td>Állapot</td>
                                <td><select id="allapotok" class="form-control"></select></td>
                            </tr>
                            <tr>
                                <td>Ár (Forint)</td>
                                <td>
                                    <select id="min_ar" class="form-control">
                                        <option></option>                                    
                                        <option>0</option>                                    
                                        <option>500000</option>                                    
                                        <option>2000000</option>
                                        <option>5000000</option>
                                        <option>10000000</option>
                                        <option>20000000</option>
                                    </select>
                                </td>
                                <td>
                                    <select id="max_ar" class="form-control">
                                        <option></option>                                    
                                        <option>500000</option>                                    
                                        <option>2000000</option>                                    
                                        <option>5000000</option>
                                        <option>10000000</option>
                                        <option>20000000</option>
                                        <option>50000000</option>
                                    </select>
                                </td>
                                <td>Szobaszám</td>
                                <td>
                                    <select id="szobaszam" class="form-control">
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
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td><button class="btn btn-primary" id="keresIngatlan">Keresés</button></td>
                            </tr>
                        </table> 
                    </fieldset>
                    <div id="ingatlanok"></div>
                </div>
            </div>
        </div>
    </body>
</html>
