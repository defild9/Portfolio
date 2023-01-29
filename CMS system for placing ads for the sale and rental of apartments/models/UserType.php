<?php

namespace models;

use core\Core;

class UserType
{
    protected static $tableName = 'User_Type';
    public static function addUserType($type){
        Core::getInstance()->db->insert(self::$tableName, [
            'type' => $type
        ]);
    }
    public static function updateUserType($id,$newNameUserType){
        Core::getInstance()->db->update(self::$tableName,[
            'type' => $newNameUserType
        ],[
            'id_user_type' => $id
        ]);
    }
    public static function deleteUserType($id){
        Core::getInstance()->db->delete(self::$tableName,[
            'id_user_type' => $id
        ]);
    }
    public static function getUserTypeById($id){
        $rows =  Core::getInstance()->db->select(self::$tableName,'*',[
            'id_user_type' => $id
        ]);
        if(!empty($rows)){
            return $rows[0];
        }
        else{
            return null;
        }
    }
    public static function getUserType(){
        $rows = Core::getInstance()->db->select(self::$tableName);
        return $rows;
    }
}