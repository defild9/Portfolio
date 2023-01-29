<?php

namespace models;


use core\Core;

class Wishlist
{
    protected static $tableName = "Wishlists";
    public static function addHouseToWishlist($id_user, $id_house){
        Core::getInstance()->db->insert(self::$tableName,[
            'id_user' => $id_user,
            'id_house' => $id_house
        ]);
    }
    public static function getAllWishHousesByUserId($id_user){
        $rows = Core::getInstance()->db->select(self::$tableName,['id_house'],[
           'id_user' => $id_user
        ]);
        if(!empty($rows)){
            return $rows;
        }
        else{
            return null;
        }
    }
    public static function deleteWishHouse($id_house){
        Core::getInstance()->db->delete(self::$tableName,[
            'id_house' => $id_house
        ]);
    }
}