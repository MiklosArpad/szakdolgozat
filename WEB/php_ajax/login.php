<?php

require_once '../config/connect.php';

if (isset($_POST['username']) && isset($_POST['password'])) {

    $username = $_POST['username'];
    $password = $_POST['password'];

    $sql = "SELECT ugynokID, jelszo FROM ???????? WHERE ugynokID = ? AND jelszo = ?;";
    
    $statement = $connection->prepare($sql);
    $statement->bind_param('ss', $username, $password);
    $statement->execute();
    $statement->store_result();
    
    if ($statement->num_rows == 1) {

        $statement->bind_result($ugynok_id, $jelszo);
        $statement->fetch();

        $_SESSION['bejelentkezes'] = $username;
        
        $statement->close();

        echo "Sikeres";
    } else {
        echo "Sikertelen";
        $statement->close();
    }
}
