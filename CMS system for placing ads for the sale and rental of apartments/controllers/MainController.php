<?php

namespace controllers;

use core\Controller;
use models\Houses;

class MainController extends Controller
{
    public function indexAction(){
        $resHouses = Houses::getHouseByTime();
       return $this->render(null,[
           'recentlyHouses' => $resHouses
       ]);
    }
    public function errorAction($code){
        switch ($code){
            case 404:
                return $this->render('views/main/error-404.php');
                break;
            case 403:
                return $this->render('views/main/error-403.php');
        }
    }
}