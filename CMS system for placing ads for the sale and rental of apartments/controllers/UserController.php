<?php

namespace controllers;

use core\Controller;
use core\Core;
use core\Utils;
use models\Category;
use models\Houses;
use models\Messages;
use models\User;
use models\UserType;

class UserController extends Controller
{
    public function indexAction()
    {

    }

    public function registerAction()
    {
        $userTypeList = UserType::getUserType();
        if (User::isUserAuthenticated()) {
            $this->redirect('/');
        }

        if (Core::getInstance()->requestMethod === 'POST') {
            $errors = [];
            if (!filter_var($_POST['email'], FILTER_VALIDATE_EMAIL)) {
                $errors['email'] = 'Помилка введення електроної адреси';
            } else {
                if (User::isLoginExists($_POST['email'])) {
                    $errors['email'] = 'Данна електрона адреса вже заєрестрована';
                }
            }
            if (empty($_POST['password']) and empty($_POST['password2'])) {
                $errors['password'] = 'Пароль не був ведений';
                $errors['password2'] = 'Підтвердіть пароль ще раз';
            } else {
                if ($_POST['password'] != $_POST['password2']) {
                    $errors['password'] = 'Паролі не співпадають';
                } else {
                    if (strlen($_POST['password']) < 6) {
                        $errors['password'] = 'Пароль не може бути меньше ніж 6 символів';
                    }
                }
            }
            if (empty($_POST['firstname'])) {
                $errors['firstname'] = "Ім'я не вказане";
            }
            if (empty($_POST['lastname'])) {
                $errors['lastname'] = "Прізвище не вказане";
            }
            if (empty($_POST['phone_number'])) {
                $errors['phone_number'] = 'Телефон не вказаний';
            } else {
                if (!preg_match("/^\+380\d{3}\d{2}\d{2}\d{2}$/", $_POST['phone_number'])) {
                    $errors['phone_number'] = 'Номер телефону заданий не коректно';
                }
            }
            if (count($errors) > 0) {
                $model = $_POST;
                return $this->render(null, [
                    'errors' => $errors,
                    'model' => $model,
                    'types' => $userTypeList
                ]);
            } else {
                if (!empty($_FILES['avatar']['tmp_name'])) {
                    $photo = Utils::photoSever($_FILES['avatar']['tmp_name']);
                    User::addUser($_POST['email'], $_POST['password'], $_POST['firstname'], $_POST['lastname'], $_POST['phone_number'], $_POST['id_user_type'], $photo);
                } else {
                    User::addUser($_POST['email'], $_POST['password'], $_POST['firstname'], $_POST['lastname'], $_POST['phone_number'], $_POST['id_user_type']);
                }

                return $this->renderView('register-success');
            }
        } else
            return $this->render(null, [
                'types' => $userTypeList
            ]);
    }

    public function loginAction()
    {
//        $userVerifyResult = User::verifyUser($_POST['email'], $_POST['password']);
        if (User::isUserAuthenticated()) {
            $this->redirect('/');
        }

        if (Core::getInstance()->requestMethod === 'POST') {
            $user = User::getUserByLoginAndPassword($_POST['email'], $_POST['password']);
            $error = null;
            if (empty($user)) {
                $error = 'Неправильний логін або пароль';
            } else {
                User::authenticateUser($user);
                $this->redirect('/');
            }
        }
        return $this->render(null, [
            'error' => $error
        ]);
    }

    public function logoutAction()
    {
        User::logoutUser();
        $this->redirect('/user/login');
    }

    public function dashboardAction()
    {
        if (!User::isUserAuthenticated()) {
            return $this->error(403);
        } else {
            $user = User::getCurrentAuthenticatedUser();
            $userData = User::getUserById($user['id_user']);
            $userType = UserType::getUserTypeById($user['id_user_type']);
            $sellCount = Houses::getCountSellHousesByUser(User::getCurrentUserId(), 1);
            $rentCount = Houses::getCountSellHousesByUser(User::getCurrentUserId(), 2);
            $newHouses = Houses::getCountSellHousesByUser(User::getCurrentUserId(), 3);
            //chat
            $MyMessage = array_reverse(Messages::getMessageUserFrom($user['id_user']));
            $ForMeMessage = array_reverse(Messages::getMessageUserTo($user['id_user']));

            return $this->render(null, [
                'user' => $user,
                'userType' => $userType,
                'countSell' => $sellCount,
                'rentCount' => $rentCount,
                'newHouses' => $newHouses,
                'userData' => $userData,
                'myMessage' => $MyMessage,
                'fromMassage' => $ForMeMessage
            ]);
        }
    }

    public function updateAction()
    {
        if (!User::isUserAuthenticated()) {
            return $this->error(403);
        } else {
            $userId = User::getCurrentAuthenticatedUser();
            $user = User::getUserById($userId['id_user']);
            if (Core::getInstance()->requestMethod === 'POST') {
                $errors = [];
                if (!filter_var($_POST['email'], FILTER_VALIDATE_EMAIL)) {
                    $errors['email'] = 'Помилка введення електроної адреси';
                }
                if (empty($_POST['firstname'])) {
                    $errors['firstname'] = "Ім'я не вказане";
                }
                if (empty($_POST['lastname'])) {
                    $errors['lastname'] = "Прізвище не вказане";
                }
                if (empty($_POST['phone_number'])) {
                    $errors['phone_number'] = 'Телефон не вказаний';
                } else {
                    if (!preg_match("/^\+380\d{3}\d{2}\d{2}\d{2}$/", $_POST['phone_number'])) {
                        $errors['phone_number'] = 'Номер телефону заданий не коректно';
                    }
                }
                if (empty($errors)) {
                    User::updateUser($user['id_user'], $_POST);
                    if (!empty($_FILES['avatar']['tmp_name'])) {
                        User::updatePhoto($user['id_user'], $_FILES['avatar']['tmp_name']);
                    }
                    return $this->redirect('/user/dashboard');
                } else {
                    return $this->render(null, [
                        'user' => $user,
                        'errors' => $errors
                    ]);
                }
            }
            return $this->render(null, [
                'user' => $user
            ]);
        }
    }

    public function change_passwordAction()
    {
        if (!User::isUserAuthenticated()) {
            return $this->error(403);
        } else {
            $user = User::getCurrentAuthenticatedUser();
            $userData = User::getUserById($user['id_user']);
            if (Core::getInstance()->requestMethod === 'POST') {
                $errors = [];
                if (empty($_POST['password'])) {
                    $errors['password'] = 'Пароль не заданий';
                } else {
                    if (User::hashPassword($_POST['password']) != $userData['password']) {
                        $errors['password'] = 'Не вірний пароль';
                    }
                }
                if (empty($_POST['passwordNew'])) {
                    $errors['passwordNew'] = 'Новий пароль не заданий';
                } else {
                    if (strlen($_POST['passwordNew']) < 6) {
                        $errors['passwordNew'] = 'Пароль не може бути меньше ніж 6 символів';
                    }
                }
                if (empty($errors)) {
                    User::changePassword($userData['id_user'], $_POST['passwordNew']);
                    User::logoutUser();
                    $this->redirect('/user/login');
                } else {
                    return $this->render(null, [
                        'errors' => $errors
                    ]);
                }
            }
        }
        return $this->render();
    }

    public function deleteAction()
    {
        if (!User::isUserAuthenticated()) {
            return $this->error('403');
        } else {
            if (Core::getInstance()->requestMethod === 'POST') {
                $errors = [];
                $user = User::getCurrentAuthenticatedUser();
                $userData = User::getUserById($user['id_user']);

                if (empty($_POST['password'])) {
                    $errors['password'] = 'Пароль не заданий';
                } else {
                    if (User::hashPassword($_POST['password']) != $userData['password']) {
                        $errors['password'] = 'Не вірний пароль';
                    }
                }
                if (empty($errors)) {
                    User::deleteUser($userData['id_user']);
                    User::logoutUser();
                    return $this->redirect('/');
                } else {
                    return $this->render(null, [
                        'errors' => $errors
                    ]);
                }
            }
        }
        return $this->render();
    }

    public function showAllUserAction()
    {
        if (!User::isAdmin()) {
            $this->error('403');
        } else {
            if (isset($_POST['ajax'])) {
                $users = User::getAllUsers();
                exit(json_encode($users));
            }
        }
    }

    public function addAdminAction()
    {
        if (isset($_POST['ajaxAddAdmin'])) {
            User::setAdmin($_POST['userEmail']);
            exit('Адміна додано');
        }
    }

    public function deleteAdminAction()
    {
        if (isset($_POST['ajaxDeleteAdmin'])) {
            User::removeAdmin($_POST['Email']);
            exit('Адміна видалено');
        }
    }


    public function profileAction($param)
    {
        $id = intval($param[0]);
        if ($id > 0) {
            $user = User::getUserById($id);
            $userCategory = UserType::getUserTypeById($user['id_user']);
            $userItems = Houses::getAllHousesByUser($user['id_user']);
            if (empty($user)) {
                return $this->error('404');
            } else {
                return $this->render(null, [
                    'user' => $user,
                    'userCategory' => $userCategory,
                    'userItem' => $userItems
                ]);
            }
        } else {
            return $this->error('404');
        }
    }

    public function testAction()
    {

    }
}