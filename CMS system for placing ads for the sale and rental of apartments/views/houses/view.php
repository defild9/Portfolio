<?php
/** @var array $house */
/** @var array $photos */
/** @var array $user */
/** @var string $userType */
/** @var bool $isInWithlist */
//var_dump($house);
//var_dump($user);
//var_dump($userType);
$curentUser = \models\User::getCurrentUserId();
?>
<div class="container">
    <div class="row d-flex justify-content-center">
        <div class="col-12">
            <?php if(count($photos) > 1) :?>
                <div id="carouselExample" class="carousel slide">
                    <div class="carousel-inner">
                        <?php for($i = 0; $i<count($photos); $i++) : ?>
                            <?php $filePath = 'files/houses/'. $photos[$i];?>
                            <?php if(is_file($filePath)) : ?>
                                <?php if($i == 0)  : ?>
                                    <div class="carousel-item active">
                                        <img src="/<?= $filePath ?>" class="d-block w-100 img-fluid" style="width: 640px; height: 560px">
                                    </div>
                                <?php else: ?>
                                    <div class="carousel-item">
                                        <img src="/<?= $filePath ?>" class="d-block w-100 img-fluid" style="width: 640px; height: 560px" >
                                    </div>
                                <?php endif;?>
                            <?php else: ?>
                                <div class="carousel-item">
                                    <img src="/static/images/no-image.jpg" class="d-block w-100 img-fluid" style="width: 640px; height: 560px">
                                </div>
                            <?php endif;?>
                        <?php endfor; ?>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            <?php else: ?>
                <?php $filePath = 'files/houses/'. $photos[0];?>
                <?php if(is_file($filePath)) : ?>
                    <img src="/<?= $filePath ?>" class="img-thumbnail">
                <?php else: ?>
                    <img src="/static/images/no-image.jpg" class="img-thumbnail">
                <?php endif;?>
            <?php endif;?>
        </div>
    </div>
    <div class="row d-flex justify-content-center mt-2">
        <div class="col-9">
            <div class="row">
                <h3 class="h1 mb-3 fw-normal"><?=$house['title']?></h3>
                <div class="col-9">
                    <div class="position-relative">
                        <b class="h2 fw-bolder fs-2"><?=$house['price']?>₴</b>
                        <span class="fw-normal fs-5">&nbsp; за об'єкт</span>
                        <span>За квадрат: <strong><?=intval($house['price']/$house['total_area'])?></strong>₴</span>
                    </div>
                </div>
                <div class="col-3 text-end">
                    <div class="btn border border-dark rounded-pill like" data-id="<?=$house['id_house']?>" data-user-id="<?=\models\User::getCurrentUserId()?>" data-wish-status="<?=$isInWithlist?>"><div id="text"></div></div>
                </div>
            </div>
            <div>
                <div id="adress" data-adress="<?=$house['street']?> <?=$house['street_num']?>, <?=$house['city']?>">
                    <strong>Адреса: вулиця:</strong> <?=$house['street']?> <?=$house['street_num']?>, <?=$house['city']?>
                </div>
                <div>
                    <strong>Загальна площа:</strong> <?=$house['total_area']?> м²
                </div>
                <div>
                    <strong>Житлова:</strong> <?=$house['living_area']?> м²
                </div>
                <div>
                    <strong>Кухня:</strong> <?=$house['kitchen_area']?> м²
                </div>
                <div>
                    <strong> Кількість кімнат:</strong> <?=$house['count_of_room']?>
                </div>
            </div>
        </div>
        <div class="col-3">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-4">
                            <?php
                                $path = "files/users/".$user['photo'];
                            ?>
                            <?php if(is_file($path)) : ?>
                                <img src="/<?=$path?>" class="rounded-circle" height="80" alt="Avatar" loading="lazy" style="height: 80px; width: 80px" />
                            <?php else:?>
                                <img src="https://mdbootstrap.com/img/Photos/Others/placeholder-avatar.jpg" class="rounded-circle" height="60" width="60" alt="Avatar" loading="lazy" />
                            <?php endif; ?>
                        </div>
                        <div class="col-8">
                            <div class="fw-light fs-6"><?=$userType?></div>
                            <div class="fw-bold fs-6" id="nameUserForChat"><?=$user['firstname']?>&nbsp;<?=$user['lastname']?></div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="btn btn-warning rounded-pill"><?=$user['phone_number']?></div>
                    </div>
                    <?php if(!$house['id_user'] == \models\User::getCurrentUserId()) : ?>
                    <div class="row mt-2">
                        <input type='button' class="btn border border-primary rounded-pill write" id="write" value="Написати"></input>
                    </div>
                    <?php endif; ?>
                </div>
                <div class="card-body">
                    <?php if($house['id_user'] == \models\User::getCurrentUserId()) : ?>
                        <div class="row">
                            <div class="col-6 ">
                                <a class="btn btn-warning btn-lg" href="/houses/edit/<?=$house['id_house']?>">Редагувати</a>
                            </div>
                            <div class="col-6">
                                <a class="btn btn-danger btn-lg" href="/houses/delete/<?=$house['id_house']?>">Видалити </a>
                            </div>
                        </div>
                    <?php elseif (\models\User::isAdmin()): ?>
                        <div class="row">
                            <div class="col-12 text-center">
                                <a class="btn btn-danger" href="/houses/delete/<?=$house['id_house']?>">Видалити</a>
                            </div>
                        </div>
                    <? endif;?>
                </div>
            </div>
        </div>
    </div>
    <div class="row d-flex justify-content-center mt-2">
        <div class="col-12">
            <p class="h4 text-start">Опис</p>
            <?=$house['description']?>
        </div>
    </div>
    <div class="row d-flex justify-content-center mt-2">
        <div id="map"></div>
    </div>
</div>
<div id="chat" data-user-from="<?=$curentUser?>" data-user-to="<?=$house['id_user']?>" data-item-id="<?=$house['id_house']?>"></div>
<script src="/themes/main/js/houseView.js" defer></script>
<style>
    #map {
        top: 0;
        bottom: 0;
        width: 1500px;
        height: 400px;
    }
</style>
