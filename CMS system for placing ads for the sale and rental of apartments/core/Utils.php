<?php

namespace core;

use models\User;

class Utils
{
    public static function filterArray($array, $fieldsList)
    {
        $newArray = [];
        foreach ($array as $key => $value)
            if (in_array($key, $fieldsList))
                $newArray[$key] = $value;
        return $newArray;
    }
    public static function photoSever($photoPath){
        do{
            $fileName = uniqid() . '.jpg';
            $newPath = "files/users/{$fileName}";
        }while(file_exists($newPath));
        move_uploaded_file($photoPath, $newPath);

        return $fileName;
    }
    public static function photosSever($photoArr){
        $nameArr = [];
        foreach ($photoArr as $photo){
            do{
                $fileName = uniqid().'.jpg';
                $newPath = "files/houses/{$fileName}";
            }while(file_exists($newPath));

            move_uploaded_file($photo, $newPath);
            array_push($nameArr,$fileName);
        }
        $fileNames = join(',',$nameArr);
        return $fileNames;
    }
}