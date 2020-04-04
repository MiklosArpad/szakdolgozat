<?php

require_once '../config/connect.php';

$sql = 'SELECT hirdetesek.azonosito, hirdetesek.cim, hirdetesek.leiras, '
        . 'ingatlanok.telepules, ingatlanok.alapterulet, ingatlanok.szobak_szama, ingatlanok.kategoria, ingatlanok.allapot, '
        . 'hirdetesek.ar FROM hirdetesek, ingatlanok WHERE hirdetesek.ingatlan = ingatlanok.helyrajzi_szam';

if (!empty($_POST['telepules'])) {
    $telepules = $_POST['telepules'];
    $sql .= " AND ingatlanok.telepules = '{$telepules}'";
}

if (!empty($_POST['kategoria'])) {
    $kategoria = $_POST['kategoria'];
    $sql .= " AND ingatlanok.kategoria = '{$kategoria}'";
}

if (!empty($_POST['min_alapterulet']) && !empty($_POST['max_alapterulet'])) {
    $min_alapterulet = $_POST['min_alapterulet'];
    $max_alapterulet = $_POST['max_alapterulet'];
    $sql .= " AND ingatlanok.alapterulet BETWEEN {$min_alapterulet} AND {$max_alapterulet}";
}

if (!empty($_POST['allapot'])) {
    $allapot = $_POST['allapot'];
    $sql .= " AND ingatlanok.allapot = '{$allapot}'";
}

if (!empty($_POST['szobaszam'])) {
    $szobaszam = $_POST['szobaszam'];
    $sql .= " AND ingatlanok.szobak_szama = '{$szobaszam}'";
}

if (!empty($_POST['min_ar']) && !empty($_POST['max_ar'])) {
    $min_ar = $_POST['min_ar'];
    $max_ar = $_POST['max_ar'];
    $sql .= " AND hirdetesek.ar BETWEEN {$min_ar} AND {$max_ar}";
}

$sql .= ' AND hirdetesek.aktiv = 1;';

$result = $connection->query($sql);

if (!$result) {
    die("Nincs találat!");
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
