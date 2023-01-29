<?php

namespace models;

use core\Core;
use core\Utils;

class Houses
{
    protected static  $firstTableName = 'Adress';
    protected static  $secondTableName = 'House';
    public static function addHouses($row){
        $fieldsListFirst = ['street', 'street_num','houses_num','city'];
        $fieldsListSecond = ['price','total_area','living_area','kitchen_area','description','id_adress','id_user','id_category','title','count_of_room','photos'];
        $row['id_user'] = User::getCurrentUserId();
        $row1 = Utils::filterArray($row,$fieldsListFirst);
        $row2 = Utils::filterArray($row,$fieldsListSecond);
        Core::getInstance()->db->transactionInsert(self::$firstTableName, $row1, self::$secondTableName, $row2);
    }

//    public static function addHouses($row1, $row2){
//        Core::getInstance()->db->transactionInsert(self::$firstTableName, $row1, self::$secondTableName, $row2);
//    }

    public static function deleteHouses($id){
        Core::getInstance()->db->transactionDelete(self::$secondTableName,['id_house'=>$id],$id,self::$firstTableName);
    }

    public static function getHousesById($id){
        $row = Core::getInstance()->db->selectWithJoin(self::$secondTableName,self::$firstTableName, "*",[
            'id_house'=>$id
        ],'id_adress','id_adress');
        if(!empty($row)){
            return $row[0];
        }
        else{
            return null;
        }
    }

    public  static function getHousesInCategory($id_category){
        $rows = Core::getInstance()->db->select(self::$secondTableName,'*',[
           'id_category' => $id_category
        ]);
        return $rows;
    }

    public static function test($id){
        $res = Core::getInstance()->db->selectWithJoin(self::$secondTableName,self::$firstTableName, "*",[
            'id_house' => $id
        ],'id_adress','id_adress');
        var_dump($res);
    }

    public static function updateHouses($id, $newRowFirst, $newRowSecond){
        Core::getInstance()->db->transactionUpdate(self::$secondTableName, $newRowFirst, ['id_house'=>$id], $id, self::$firstTableName, $newRowSecond);
    }
    public static function testHouses(){
        var_dump($_SESSION['user']["id_user"]);
    }
    public static function getCountSellHousesByUser($user_id, $category_id){
        $rows = Core::getInstance()->db->select(self::$secondTableName,'*',[
            'id_user' => $user_id,
            'id_category' => $category_id
        ]);
        if(empty($rows)){
            return 0;
        }
        return count($rows);
    }
    public static function isHouseInUserWishlist($id_user,$id_house){
        $rows = Wishlist::getAllWishHousesByUserId($id_user);
        $res = [];
        if(empty($rows)){
            return false;
        }
        else{
            foreach ($rows as $row){
                array_push($res, $row['id_house']);
            }
            if(in_array($id_house,$res)){
                return true;
            }
            else{
                return false;
            }
        }
    }
    public static function updatePhotos($id, $newPhoto){
        if(empty($flag)){
            $row = self::getHousesById($id);
            $photos = explode(',',$row['photos']);
            $nameArr =[];
            foreach ($photos as $photo){
                $photoPath = 'files/houses/'.$photo;
                if(is_file($photoPath)){
                    unlink($photoPath);
                }
            }
            foreach ($newPhoto as $item){
                do{
                    $fileName = uniqid() . '.jpg';
                    $newPath = "files/houses/{$fileName}";
                }while(file_exists($newPath));
                move_uploaded_file($item, $newPath);
                array_push($nameArr,$fileName);
            }
            $fileName = join(',',$nameArr);
            Core::getInstance()->db->update(self::$secondTableName,[
                'photos' => $fileName
            ],[
                'id_house' => $id
            ]);
        }
    }
    public static function getHouseByTime(){
        $rows = Core::getInstance()->db->selectWithSort(self::$secondTableName,'*',null, 'date_of_create');
        return $rows;
    }
    public static function getAllHousesByUser($id){
        $rows = Core::getInstance()->db->selectWithJoin(self::$secondTableName,self::$firstTableName,'*',[
            'id_user' => $id
        ],'id_adress','id_adress');
        return $rows;
    }
    public static function getAllInfoHousesInCategory($id){
        $rows = Core::getInstance()->db->selectWithJoin(self::$secondTableName,self::$firstTableName,'*',[
            'id_category' => $id
        ],'id_adress','id_adress');
        return $rows;
    }
    public static function getAllInfoHousesByParametr($arr){
        $searchFild = ['count_of_room', 'city'];
        $condition = Utils::filterArray($arr,$searchFild);
        $rows = Core::getInstance()->db->selectWithJoin(self::$secondTableName,self::$firstTableName,'*', $condition,'id_adress','id_adress');
        return $rows;
    }
}