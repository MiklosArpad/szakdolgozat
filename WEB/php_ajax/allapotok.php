<?php

require_once '../config/connect.php';

$sql = "SELECT elnevezes FROM ingatlan_allapotok;";
$result = $connection->query($sql);

if (!$result) {
    die("Hiba a lekérdezésben!");
}

$keresIngatlanAllapotHTML = '<option></option>';

while ($row = $result->fetch_row()) {
    $keresIngatlanAllapotHTML .= "<option>{$row[0]}</option>";
}

echo $keresIngatlanAllapotHTML;
