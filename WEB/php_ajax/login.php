<?php

session_start();
require_once '../config/connect.php';

if (isset($_POST['username']) && isset($_POST['password'])) {

    $username = $_POST['username'];
    $password = $_POST['password'];

    $sql = "SELECT azonosito, jelszo FROM ugynokok WHERE azonosito = ? AND jelszo = ?;";
    
    $statement = $connection->prepare($sql);
    $statement->bind_param('ss', $username, $password);
    $statement->execute();
    $statement->store_result();
    
    if ($statement->num_rows == 1) {

        $statement->bind_result($username, $password);
        $statement->fetch();

        $_SESSION['user'] = $username;
        
        $statement->close();

        echo "Sikeres";
    } else {
        echo "Sikertelen";
        $statement->close();
    }
}
