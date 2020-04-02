<?php

require_once '../config/connect.php';

$sql = "SELECT elnevezes FROM ingatlan_kategoriak;";
$result = $connection->query($sql);

if (!$result) {
    die("Hiba a lekérdezésben!");
}

$keresIngatlanKategoriaHTML = '<option></option>';

while ($row = $result->fetch_row()) {
    $keresIngatlanKategoriaHTML .= "<option>{$row[0]}</option>";
}

echo $keresIngatlanKategoriaHTML;
