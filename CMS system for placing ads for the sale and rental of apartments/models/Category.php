<?php

namespace models;

use core\Core;
use core\Utils;

class Category
{
    protected static  $tableName = 'Category';
    public static function addCategory($categoryName){
        Core::getInstance()->db->insert(self::$tableName, [
            'name_category' => $categoryName
        ]);
    }
    public static function getCategoryById($id){
        $rows =  Core::getInstance()->db->select(self::$tableName,'*',[
           'id_category' => $id
        ]);
        if(!empty($rows)){
            return $rows[0];
        }
        else{
            return null;
        }
    }
    public static function deleteCategory($id){
        Core::getInstance()->db->delete(self::$tableName,[
            'id_category' => $id
        ]);
    }
    public static function updateCategory($id,$newNameCategory){
        Core::getInstance()->db->update(self::$tableName,[
            'name_category'=> $newNameCategory
        ],['id_category'=>$id]);
    }
    public static function getAllCategory(){
        $rows =  Core::getInstance()->db->select(self::$tableName);
        return $rows;
    }
}