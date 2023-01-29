<?php

namespace models;

use core\Core;
use core\Utils;

class User
{
    protected static $tableName ='User';
    protected static $secondTableName = 'User_Type';
    public static function addUser($email, $password, $firstname, $lastname, $phoneNumber, $userType, $userPhoto = null){
        \core\Core::getInstance()->db->insert(
            self::$tableName, [
                'firstname' => $firstname,
                'lastname' => $lastname,
                'phone_number' => $phoneNumber,
                'email' => $email,
                'id_user_type' => $userType,
                'password' => self::hashPassword($password),
                'photo'=> $userPhoto
            ]
        );
    }
    public static function hashPassword($password){
        return md5($password);
    }
    public static function updateUser($id, $updateArray){
        $updateArray = Utils::filterArray($updateArray, ['lastname', 'firstname', 'email', 'phone_number']);

        \core\Core::getInstance()->db->update(self::$tableName, $updateArray,[
            'id_user' => $id,
        ]);
    }
    public static function changePassword($id, $password){
        Core::getInstance()->db->update(self::$tableName,[
            'password' => self::hashPassword($password)
        ],[
            'id_user' => $id
        ]);
    }

    public static function deleteUser($id){
        Core::getInstance()->db->delete(self::$tableName,[
            'id_user' => $id
        ]);
    }

    public static function isLoginExists($login){
        $user = \core\Core::getInstance()->db->select(self::$tableName,'*', [
            'email' => $login
        ]);
        return !empty($user);
    }
    public static function verifyUser($login, $password){
        $user = \core\Core::getInstance()->db->select(self::$tableName,'*', [
            'email' => $login,
            'password' => $password
        ]);
        return !empty($user);
    }

    public static function getUserByLoginAndPassword($login, $password){
        $user = \core\Core::getInstance()->db->select(self::$tableName,'*', [
            'email' => $login,
            'password' => self::hashPassword($password)
        ]);
        if(!empty($user)){
            return $user[0];
        }
        return null;
    }
    public static function getUserById($id){
        $rows =  Core::getInstance()->db->select(self::$tableName,'*',[
            'id_user' => $id
        ]);
        if(!empty($rows)){
            return $rows[0];
        }
        else{
            return null;
        }
    }
    public static function getTypeUser($id){
        $rows = Core::getInstance()->db->select(self::$secondTableName,['type'],[
            'id_user_type' => $id
        ]);
        if(!empty($rows)){
            return implode('',$rows[0]);
        }
        else{
            return null;
        }
    }

    public static function authenticateUser($user){
        $_SESSION['user'] = $user;
    }
    public static function logoutUser(){
        unset($_SESSION['user']);
    }
    public static function isUserAuthenticated(){
        return isset($_SESSION['user']);
    }
    public static function getCurrentAuthenticatedUser(){
        return $_SESSION['user'];
    }
    public static function isAdmin(){
        $user = self::getCurrentAuthenticatedUser();
        return $user['isAdmin'] == 1;
    }
    public static function getCurrentUserId(){
        return intval($_SESSION['user']['id_user']);
    }
    public static function updatePhoto($id, $newPhoto){
        $row = self::getUserById($id);
        $photoPath = 'files/users/'.$row['photo'];
        if(is_file($photoPath)){
            unlink($photoPath);
        }
        do{
            $fileName = uniqid() . '.jpg';
            $newPath = "files/users/{$fileName}";
        }while(file_exists($newPath));
        move_uploaded_file($newPhoto, $newPath);
        Core::getInstance()->db->update(self::$tableName,[
            'photo' => $fileName
        ],[
            'id_user' => $id
        ]);
    }
    public static function getAllUsers(){
        $rows = Core::getInstance()->db->select(self::$tableName);
        return $rows;
    }
    public static function setAdmin($email){
        Core::getInstance()->db->update(self::$tableName,['isAdmin'=>1],[
            'email' => $email
        ]);
    }
    public static function removeAdmin($email){
        Core::getInstance()->db->update(self::$tableName,['isAdmin'=>null],[
            'email' => $email
        ]);
    }
}