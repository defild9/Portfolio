<?php

namespace controllers;

use core\Core;
use models\Category;
use models\Houses;
use models\User;

class CategoryController extends \core\Controller
{
    public function indexAction(){
        $citys = [
            'Житомир','Київ','Львів','Херсон','Вінниця','Тернопіль','Рівне','Харків','Одеса',
            'Суми','Миколаїв','Тернопіль','Полтава','Черкаси','Луцьк'
        ];
        $rows = Category::getAllCategory();
        return $this->render(null,[
            'rows' => $rows,
        ]);
    }
    public function addAction(){
        if(!User::isAdmin()){
            return $this->error(403);
        }
        if(Core::getInstance()->requestMethod === 'POST'){
            $_POST['name_category'] = trim($_POST['name_category']);
            $errors = [];
            if(empty($_POST['name_category'])){
                $errors['name_category'] = 'Назва категорії не вказана';
            }
            if(empty($errors)){
                Category::addCategory($_POST['name_category']);
                return $this->redirect('/category/index');
            }
            else{
                $model = $_POST;
                return $this->render(null, [
                   'errors' => $errors,
                   'model' => $model
                ]);
            }
        }
        return $this->render();
    }
    public function editAction($params){
        $id = intval($params[0]);
        if(!User::isAdmin()){
            return $this->error(403);
        }
        if($id > 0){
            $category = Category::getCategoryById($id);
            if(Core::getInstance()->requestMethod === 'POST'){
                $_POST['name_category'] = trim($_POST['name_category']);
                $errors = [];

                if(empty($_POST['name_category'])){
                    $errors['name_category'] = 'Назва категорії не вказана';
                }
                if(empty($errors)){
                    Category::updateCategory($id, $_POST['name_category']);
                    return $this->redirect('/category/index');
                }
                else{
                    $model = $_POST;
                    return $this->render(null, [
                        'errors' => $errors,
                        'model' => $model,
                        'category'=> $category
                    ]);
                }

            }
            return $this->render(null,[
                'category'=> $category
            ]);
        }
        else{
            return $this->error(403);
        }
        return $this->render();
    }
    public function deleteAction($params){
        $id = intval($params[0]);
        $yes = boolval($params[1] === 'yes');
        if(!User::isAdmin()){
            return $this->error(403);
        }
        if ($id>0){
            if($yes){
                Category::deleteCategory($id);
                return $this->redirect('/category/index');
            }
            $category = Category::getCategoryById($id);
            return $this->render(null,[
                'category'=> $category
            ]);
        }
        else{
            return $this->error(403);
        }
    }
    public function viewAction($param){
        $id = intval($param[0]);
        $citys = [
            'Житомир','Київ','Львів','Херсон','Вінниця','Тернопіль','Рівне','Харків','Одеса',
            'Суми','Миколаїв','Тернопіль','Полтава','Черкаси','Луцьк'
        ];
        $category = Category::getCategoryById($id);
        $houses = Houses::getAllInfoHousesInCategory($id);

        if(Core::getInstance()->requestMethod === "POST"){
            if(empty($_POST['parametr'])){
                if(empty($_POST['city'] and empty($_POST['']))){
                    $houses = Houses::getAllInfoHousesInCategory($id);
                    return $this->render(null, [
                        'category' => $category,
                        'houses' => $houses,
                        'citys' => $citys
                    ]);
                }
                else{
                    $houses = Houses::getAllInfoHousesByParametr($_POST);
                    return $this->render(null, [
                        'category' => $category,
                        'houses' => $houses,
                        'citys' => $citys,
                    ]);
                }
            }
        }

        return $this->render(null, [
           'category' => $category,
            'houses' => $houses,
            'citys' => $citys
        ]);
    }
}