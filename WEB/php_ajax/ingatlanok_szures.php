<?php

require_once '../config/connect.php';

$sql = 'SELECT hirdetesek.azonosito, hirdetesek.cim, hirdetesek.leiras, '
        . 'ingatlanok.telepules, ingatlanok.alapterulet, ingatlanok.szobak_szama, ingatlanok.kategoria, ingatlanok.allapot, '
        . 'hirdetesek.ar FROM hirdetesek, ingatlanok WHERE hirdetesek.ingatlan = ingatlanok.helyrajzi_szam';

if (empty($_POST['telepules'])) {
    $telepules = "";
} else {
    $telepules = $_POST['telepules'];
}

if (empty($_POST['kategoria'])) {
    $kategoria = "";
} else {
    $kategoria = $_POST['kategoria'];
}

if (empty($_POST['alapterulet'])) {
    $alapterulet = "";
} else {
    $alapterulet = $_POST['alapterulet'];
}

if (empty($_POST['allapot'])) {
    $allapot = "";
} else {
    $allapot = $_POST['allapot'];
}

if (empty($_POST['szobaszam'])) {
    $szobaszam = "";
} else {
    $szobaszam = $_POST['szobaszam'];
}

if (empty($_POST['ar'])) {
    $ar = "";
} else {
    $ar = $_POST['ar'];
}

$sql .= ';';

$result = $connection->query($sql);

if (!$result) {
    die("Hiba a lekérdezésben!");
}

$szuresHirdetes = '<table class="table table-striped">'
        . '<thead>'
        . '<tr>'
        . '<td>Cím</td>'
        . '<td>Leírás</td>'
        . '<td>Település</td>'
        . '<td>Alapterület (m2)</td>'
        . '<td>Szobaszám</td>'
        . '<td>Kategória</td>'
        . '<td>Állapot</td>'
        . '<td>Ár</td>'
        . '</tr>'
        . '</thead>';

while ($row = $result->fetch_row()) {
    $szuresHirdetes .= "<tr id='{$row[0]}'>";
    $szuresHirdetes .= "<td>{$row[1]}</td>";
    $szuresHirdetes .= "<td>{$row[2]}</td>";
    $szuresHirdetes .= "<td>{$row[3]}</td>";
    $szuresHirdetes .= "<td>{$row[4]}</td>";
    $szuresHirdetes .= "<td>{$row[5]}</td>";
    $szuresHirdetes .= "<td>{$row[6]}</td>";
    $szuresHirdetes .= "<td>{$row[7]}</td>";
    $szuresHirdetes .= "<td>{$row[8]}</td>";
}

$szuresHirdetes .= "</table>";


echo $szuresHirdetes;
