<?php

namespace controllers;

use core\Core;
use core\DataBase;
use core\Utils;
use http\Exception\BadMethodCallException;
use models\Category;
use models\Houses;
use models\User;

class HousesController extends \core\Controller
{
    public function addAction(){
        $categoriesList = Category::getAllCategory();
        $citys = [
            'Житомир','Київ','Львів','Херсон','Вінниця','Тернопіль','Рівне','Харків','Одеса',
            'Суми','Миколаїв','Тернопіль','Полтава','Черкаси','Луцьк'
        ];
        if(!User::isUserAuthenticated()){
            return $this->redirect('/user/login');
        }
        if(Core::getInstance()->requestMethod === 'POST'){
            $errors = [];
            $_POST['title'] = trim($_POST['title']);
            if(empty($_POST['title'])){
                $errors['title'] = 'Назва оголошення не вказана';
            }
            if(empty($_POST['id_category'])){
                $errors['id_category'] = 'Категорія не вибрана';
            }
            if(empty($_POST['price'])){
                $errors['price'] = 'Ціна не задана';
            }
            else{
                if($_POST['price'] <= 0){
                    $errors['price'] = 'Ціна некоректно задана';
                }
            }
            if(empty($_POST['total_area'])){
                $errors['total_area'] = 'Площа квартири не задана';
            }
            else{
                if($_POST['total_area'] <= 0){
                    $errors['total_area'] = 'Площа квартири задана некоректно';
                }
            }
            if(empty($_POST['living_area'])){
                $errors['living_area'] = 'Житлова площа не задана';
            }
            else{
                if($_POST['living_area'] <= 0){
                    $errors['living_area'] = 'Житлова площа задана некоректно';
                }
            }
            if(empty($_POST['kitchen_area'])){
                $errors['living_area'] = 'Площа кухні не задана';
            }
            else{
                if($_POST['kitchen_area'] <= 0){
                    $errors['living_area'] = 'Площа кухні задана некоректно';
                }
            }
            if(empty($_POST['street'])){
                $errors['street'] = 'Назва вулиці не задана';
            }
            if(empty($_POST['street_num'])){
                $errors['street_num'] = 'Номер вулиці не задана';
            }
            if(empty($_POST['city'])){
                $errors['city'] = 'Місто не задане';
            }
            if(empty($_POST['count_of_room'])){
                $errors['count_of_room'] = 'Кількість кімнат не задана';
            }
            else{
                if($_POST['count_of_room'] <= 0){
                    $errors['count_of_room'] = 'Кількість кімнат не може бути меньше 0 чи йому дорівнювати';
                }
            }
            if(empty($errors)){
                $_POST['photos'] = Utils::photosSever($_FILES['photos']['tmp_name']);
                Houses::addHouses($_POST);
                return $this->redirect('/houses');
            }
            else{
                $model = $_POST;
                return $this->render(null, [
                    'errors' => $errors,
                    'model' => $model,
                    'categories' => $categoriesList,
                    'citys' => $citys
                ]);
            }
        }
        return $this->render(null,[
            'categories' => $categoriesList,
            'citys' => $citys
        ]);
    }
    public function viewAction($params){
        $id = intval($params[0]);
        $house = Houses::getHousesById($id);
        $user = User::getUserById($house['id_user']);
        $userType = User::getTypeUser(intval($user['id_user_type']));
        $isInWishlistUser = Houses::isHouseInUserWishlist($user['id_user'],$id);
        if(!empty($house)){
            $photos = explode(',',$house['photos']);
            return $this->render(null, [
                'house' => $house,
                'photos' => $photos,
                'user' => $user,
                'userType' => $userType,
                'isInWithlist' => $isInWishlistUser
            ]);
        }
        else{
            return $this->error(404);
        }
    }

    public function editAction($param){
        $id = intval($param[0]);
        $house = Houses::getHousesById($id);
        $categoriesList = Category::getAllCategory();
        $citys = [
            'Житомир','Київ','Львів','Херсон','Вінниця','Тернопіль','Рівне','Харків','Одеса',
            'Суми','Миколаїв','Тернопіль','Полтава','Черкаси','Луцьк'
        ];
        if($id > 0){
            if(User::isUserAuthenticated()){
                if($house['id_user'] == User::getCurrentUserId()){
                    if(Core::getInstance()->requestMethod === 'POST'){
                        $errors = [];
                        $_POST['title'] = trim($_POST['title']);
                        if(empty($_POST['title'])){
                            $errors['title'] = 'Назва оголошення не вказана';
                        }
                        if(empty($_POST['id_category'])){
                            $errors['id_category'] = 'Категорія не вибрана';
                        }
                        if(empty($_POST['price'])){
                            $errors['price'] = 'Ціна не задана';
                        }
                        else{
                            if($_POST['price'] <= 0){
                                $errors['price'] = 'Ціна некоректно задана';
                            }
                        }
                        if(empty($_POST['total_area'])){
                            $errors['total_area'] = 'Площа квартири не задана';
                        }
                        else{
                            if($_POST['total_area'] <= 0){
                                $errors['total_area'] = 'Площа квартири задана некоректно';
                            }
                        }
                        if(empty($_POST['living_area'])){
                            $errors['living_area'] = 'Житлова площа не задана';
                        }
                        else{
                            if($_POST['living_area'] <= 0){
                                $errors['living_area'] = 'Житлова площа задана некоректно';
                            }
                        }
                        if(empty($_POST['kitchen_area'])){
                            $errors['living_area'] = 'Площа кухні не задана';
                        }
                        else{
                            if($_POST['kitchen_area'] <= 0){
                                $errors['living_area'] = 'Площа кухні задана некоректно';
                            }
                        }
                        if(empty($_POST['street'])){
                            $errors['street'] = 'Назва вулиці не задана';
                        }
                        if(empty($_POST['street_num'])){
                            $errors['street_num'] = 'Номер вулиці не задана';
                        }
                        if(empty($_POST['city'])){
                            $errors['city'] = 'Місто не задане';
                        }
                        if(empty($_POST['count_of_room'])){
                            $errors['count_of_room'] = 'Кількість кімнат не задана';
                        }
                        else{
                            if($_POST['count_of_room'] <= 0){
                                $errors['count_of_room'] = 'Кількість кімнат не може бути меньше 0 чи йому дорівнювати';
                            }
                        }
                        if(empty($errors)){
                            $fieldsListFirst = ['street', 'street_num','house_num','city'];
                            $fieldsListSecond = ['price', 'total_area','living_area','kitchen_area','description','id_category','title','count_of_room'];
                            $row1 = Utils::filterArray($_POST,$fieldsListFirst);
                            $row2 = Utils::filterArray($_POST,$fieldsListSecond);
                            Houses::updateHouses($id, $row2, $row1);
                            if(!empty($_FILES['file']['tmp_name'][0])){
                                Houses::updatePhotos($id, $_FILES['file']['tmp_name']);

                            }
                            return $this->redirect("/houses/view/{$id}");
                        }
                        else{
                            return $this->render(null, [
                                'errors' => $errors,
                                'house'=>$house,
                                'categories' => $categoriesList,
                                'citys' => $citys
                            ]);
                        }
                    }
                    return $this->render(null, [
                        'house'=>$house,
                        'categories' => $categoriesList,
                        'citys' => $citys
                    ]);
                }
                else{
                    return $this->error(403);
                }
            }
            else{
                return $this->error(403);
            }
        }
        else{
            return $this->error(404);
        }
    }
    public function deleteAction($param){
        $id = intval($param[0]);
        $agreeToDelete = boolval($param[1] === 'yes');
        $house = Houses::getHousesById($id);
        if($id>0){
            if(User::isUserAuthenticated() or User::isAdmin()){
                if($house['id_user'] == User::getCurrentUserId() or User::isAdmin()){
                    if($agreeToDelete){
                        Houses::deleteHouses($id);
                        return $this->redirect('/houses');
                    }
                    $house = Houses::getHousesById($id);
                    $user = User::getUserById($house['id_user']);
                    $userType = User::getTypeUser(intval($user['id_user_type']));
                    $isInWishlistUser = Houses::isHouseInUserWishlist($user['id_user'],$id);
                    $photos = explode(',',$house['photos']);
                    return $this->render(null, [
                        'house' => $house,
                        'photos' => $photos,
                        'user' => $user,
                        'userType' => $userType,
                        'isInWithlist' => $isInWishlistUser
                    ]);
                }
                else{
                    return $this->error(403);
                }
            }
            else{
                return $this->error(403);
            }
        }
        else{
            return $this->error(404);
        }
    }
    public function testAction(){
        return $this->render('update');
    }
}