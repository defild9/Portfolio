<?php

namespace controllers;

use core\Controller;
use models\Messages;
use models\User;

class MessageController extends Controller
{
    public function addAction(){
        if(!User::isUserAuthenticated()){
            return $this->error(403);
        }
        else{
            if(isset($_POST['ajaxMes'])){
                Messages::addMessage($_POST);
                exit('Повідомлення відправленне');
            }
        }
    }

    public function userfromAction(){
        if(!User::isUserAuthenticated()){
            return $this->error(403);
        }
        else{
            if(isset($_POST['ajaxFrom'])){
                $from = Messages::getMessageUserFrom($_POST['from_id']);
                exit(json_encode($from));
            }
        }
    }

    public function usertoAction(){
        if(!User::isUserAuthenticated()){
            return $this->error(403);
        }
        else{
            if(isset($_POST['ajaxFrom'])){
                $to = Messages::getMessageUserTo($_POST['to_id']);
                exit(json_encode($to));
            }
        }
    }

    public function answerAction(){
        if(!User::isUserAuthenticated()){
            return $this->error(403);
        }
        else{
            if($_POST['ajaxAnswer']){
                Messages::setAnswer($_POST['answerChat'],$_POST['messageChat'],$_POST['fromChat'],$_POST['itemChat']);
                exit("Відправленно");
            }
        }
    }
}