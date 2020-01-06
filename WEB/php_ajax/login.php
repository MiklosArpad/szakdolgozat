<?php

require_once '../config/connect.php';

if (isset($_POST['ugynok_id']) && isset($_POST['jelszo'])) {

    $ugynok_id = $_POST['ugynok_id'];
    $jelszo = $_POST['jelszo'];

    $sql = "SELECT ugynokID, jelszo FROM ugynokok WHERE ugynokID = ? AND jelszo = ?;"; // SQL-injeckió kivédése paraméterezett lekérdezéssel

    $statement = $connection->prepare($sql);
    $statement->bind_param('ss', $ugynok_id, $jelszo); // paraméter kötés: ? -hez változó (ha string akkor 's', ha integer akkor 'i'
    $statement->execute(); // megtörént a kötés és a lekérdezés
    $statement->store_result(); // eredmény letárolás



    if ($statement->num_rows == 1) {

        $statement->bind_result($ugynok_id, $jelszo);
        $statement->fetch();

        $_SESSION['bejelentkezes'] = $ugynok_id; // felhasználói munakmenet követése (ügynök ID szolgál erre)

        $statement->close();

        echo "Sikeres";
    } else {
        echo "Sikertelen";
        $statement->close();
    }
}
