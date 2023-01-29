<?php

use core\DataBase;

include('config/database.php');
include ('config/params.php');
//Автозавантажувач класів
spl_autoload_register(function ($className){
    $path = $className.'.php';
    if(is_file($path))
        include ($path);
});

$core = core\Core::getInstance();
$core ->Initialize();
$core ->Run();
$core ->Done();