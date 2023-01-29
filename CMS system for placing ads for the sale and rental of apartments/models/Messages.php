<?php

namespace models;

use core\Core;
use core\Utils;

class Messages
{
    protected static $tableName = 'messages';

    public static function addMessage($arr){
        $fildSet = ['user_from','user_to','message','id_item'];
        $row = Utils::filterArray($arr,$fildSet);
        Core::getInstance()->db->insert(self::$tableName,$row);
    }
    public static function getMessageUserFrom($id){
        $rows = Core::getInstance()->db->select(self::$tableName,'*',[
            'user_from' => $id
        ]);
        return $rows;
    }
    public static function getMessageUserTo($id){
        $rows = Core::getInstance()->db->select(self::$tableName,'*',[
            'user_to' => $id
        ]);
        return $rows;
    }
    public static function setAnswer($answer, $message, $id_from, $id_item){
        Core::getInstance()->db->update(self::$tableName,['Answer' => $answer],[
            'message' => $message,
            'user_from' => $id_from,
            'id_item' => $id_item
        ]);
    }
}