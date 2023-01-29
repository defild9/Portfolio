<?php
/** @var string $title */
/** @var string $Content */
/** @var string $siteName */

use models\User;
if(User::isUserAuthenticated()){
    $user = User::getCurrentAuthenticatedUser();
}
else{
    $user = null;
}
$userphoto = User::getUserById($_SESSION['user']['id_user']);
$categories = \models\Category::getAllCategory();

?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="https://cdn.maptiler.com/maplibre-gl-js/v2.4.0/maplibre-gl.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <link href="https://cdn.maptiler.com/maplibre-gl-js/v2.4.0/maplibre-gl.css" rel="stylesheet" />
    <link rel="stylesheet" href="/themes/css/main.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <title><?=$siteName?> | <?=$title?></title>
</head>
<body>
<header class="p-3 bg-light bg-gradient text-black">
    <div class="container">
        <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
            <a href="/" class="d-flex align-items-center mb-2 mb-lg-0 text-dark text-decoration-none">
                <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="currentColor" class="bi bi-house-fill" viewBox="0 0 16 16">
                    <path d="M8.707 1.5a1 1 0 0 0-1.414 0L.646 8.146a.5.5 0 0 0 .708.708L8 2.207l6.646 6.647a.5.5 0 0 0 .708-.708L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293L8.707 1.5Z"/>
                    <path d="m8 3.293 6 6V13.5a1.5 1.5 0 0 1-1.5 1.5h-9A1.5 1.5 0 0 1 2 13.5V9.293l6-6Z"/>
                </svg>
            </a>

            <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                <?php foreach ($categories as $category) : ?>
                    <li><a href="/category/view/<?=$category['id_category']?>" class="nav-link px-2 text-black"><?=$category['name_category']?></a></li>
                <?php endforeach;?>
            </ul>
            <div class="text-end">
              <div class="row"></div>
                <?php if(User::isUserAuthenticated()) : ?>
                    <?php if(!empty($userphoto['photo'])) : ?>
                        <div class="dropdown text-end">
                            <a href="#" class="d-block link-dark text-decoration-none dropdown-toggle" id="dropdownUser1" data-bs-toggle="dropdown" aria-expanded="false">
                                <img src="/files/users/<?=$userphoto['photo']?>" alt="mdo" width="50" height="50" class="rounded-circle">
                            </a>
                            <ul class="dropdown-menu text-small" aria-labelledby="dropdownUser1">
                                <li><a class="dropdown-item" href="/houses/add">Додати оголошення</a></li>
                                <li><a class="dropdown-item" href="/user/dashboard">Особистий кабінет</a></li>
                                <?php if(User::isAdmin()) :?>
                                    <li><a class="dropdown-item" href="/category/add">Додати категорію</a></li>
                                    <li><a class="dropdown-item" href="/category/">Список категорій</a></li>
                                <?php endif;?>
                                <li><a class="dropdown-item" href="/wishlist/"><i class="bi bi-heart-fill"></i>&nbsp;Обране</a></li>
                                <li><hr class="dropdown-divider"></li>
                                <li><a class="dropdown-item" href="/user/logout">Вийти</a></li>
                            </ul>
                        </div>
                    <?php else:?>
                        <div class="dropdown text-end">
                            <a href="#" class="d-block link-dark text-decoration-none dropdown-toggle" id="dropdownUser1" data-bs-toggle="dropdown" aria-expanded="false">
                                <img src="https://mdbootstrap.com/img/Photos/Others/placeholder-avatar.jpg" alt="mdo" width="50" height="50" class="rounded-circle">
                            </a>
                            <ul class="dropdown-menu text-small" aria-labelledby="dropdownUser1">
                                <li><a class="dropdown-item" href="/user/dashboard">Особистий кабінет</a></li>
                                <li><a class="dropdown-item" href="/wishlist/"><i class="bi bi-heart-fill"></i>&nbsp;Обране</a></li>
                                <li><hr class="dropdown-divider"></li>
                                <li><a class="dropdown-item" href="/user/logout">Вийти</a></li>
                            </ul>
                        </div>
                    <?php endif; ?>
                <?php else:?>
                    <a href="/user/login" class="btn btn-outline-dark me-2">Увійти</a>
                    <a href="/user/register" class="btn btn-warning">Реєстрація</a>
                <?php endif; ?>
            </div>
        </div>
    </div>
</header>
<div class="">
    <?=$Content?>
</div>
<div class="container mt-5">
    <footer class="py-3 my-4">
        <ul class="nav justify-content-center border-bottom pb-3 mb-3">
            <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">Home</a></li>
            <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">Features</a></li>
            <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">Pricing</a></li>
            <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">FAQs</a></li>
            <li class="nav-item"><a href="#" class="nav-link px-2 text-muted">About</a></li>
        </ul>
        <p class="text-center text-muted">© 2023 DreamHome, Inc</p>
    </footer>
</div>
</body>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
</html>
