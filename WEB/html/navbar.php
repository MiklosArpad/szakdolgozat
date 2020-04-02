<?php

session_start();

if (isset($_SESSION['user'])) {
    echo file_get_contents('html/navbar_login.html');
} else {
    echo file_get_contents('html/navbar_logout.html');
}
