<?php

namespace controllers;

use core\Controller;
use models\User;
use models\Wishlist;

class WishlistController extends Controller
{
    public function indexAction(){
        if(!User::isUserAuthenticated()){
            return $this->error(403);
        }
        else{
            $user = User::getCurrentAuthenticatedUser();
            $wishlist = Wishlist::getAllWishHousesByUserId($user['id_user']);
            return $this->render(null,[
                'wishlists' => $wishlist
            ]);
        }
    }
    public function addAction(){
        if(!User::isUserAuthenticated()){
            return $this->error(403);
        }
        else{
            if(isset($_POST['ajaxAddToList'])){
                Wishlist::addHouseToWishlist($_POST['userId'], $_POST['houseId']);
                exit();
            }
        }
    }
    public function deleteAction(){
        if(!User::isUserAuthenticated()){
            return $this->error(403);
        }
        if(isset($_POST['ajaxAddToList'])){
            Wishlist::deleteWishHouse($_POST['houseId']);
            exit();
        }
    }
}