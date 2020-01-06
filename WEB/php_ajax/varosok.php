<?php

require_once '../config/connect.php';

$sql = "SELECT nev FROM telepulesek;";
$result = $connection->query($sql);

if (!$result) {
    die("Hiba a lekérdezésben!");
}

$keresVarosHTML = '';

while ($row = $result->fetch_row()) {
    $keresVarosHTML .= "<option>{$row[0]}</option>";
}

echo $keresVarosHTML;
