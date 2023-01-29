<?php
/** @var array $recentlyHouses */
?>
<link rel="stylesheet" href="/themes/css/style.css">
<div>
    <div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center bg-light">
        <div class="col-md-5 p-lg-5 mx-auto my-5">
            <h1 class="display-4 fw-normal">DreamHome</h1>
            <p class="lead fw-normal">DreamHome - це сайт, де продається і здається в оренду нерухомість в Україні.</p>
            <a class="btn btn-outline-dark" href="/houses/add">Розмістити оголошення</a>
        </div>
        <div class="product-device shadow-sm d-none d-md-block"></div>
        <div class="product-device product-device-2 shadow-sm d-none d-md-block"></div>
    </div>
</div>
<div class="container">
    <div>
        <h1 class="h2 text-center">Недавно додані</h1>
    </div>
    <div id="carouselExample" class="carousel carousel-dark slide">
        <div class="carousel-inner">
            <?php for($i = 0; $i < 3; $i++) : ?>
                <div class="carousel-item">
                    <div class="cards-wrapper">
                        <?php if ($i == 0) : ?>
                            <?php for ($j = 0; $j < 3; $j++) : ?>
                                <div class="card">
                                    <?php $photo = explode(',', $recentlyHouses[$j]['photos']) ?>
                                    <img src="/files/houses/<?=$photo[0]?>" class="card-img-top img-wrapper" alt="..." style="width: 600px; height: 250px;">
                                    <div class="card-body">
                                        <h4 class="card-title"><?= $recentlyHouses[$j]['title'] ?></h4>
                                        <h3><?=$recentlyHouses[$j]['price']?> ₴</h3>
                                        <p class="card-text fs-2""><?=$recentlyHouses[$j]['description']?></p>
                                        <a href="/houses/view/<?=$recentlyHouses[$j]['id_house']?>" class="btn btn-primary">Перейти</a>
                                    </div>
                                </div>
                            <?php endfor; ?>
                        <?php endif; ?>
                        <?php if ($i == 1) : ?>
                            <?php for ($j = 3; $j < 6; $j++) : ?>
                                <?php $photo = explode(',',$recentlyHouses[$j]['photos'])?>
                                <div class="card">
                                    <img src="/files/houses/<?=$photo[0]?>" class="card-img-top img-wrapper" alt="...">
                                    <div class="card-body">
                                        <h4 class="card-title"><?= $recentlyHouses[$j]['title'] ?></h4>
                                        <h3><?=$recentlyHouses[$j]['price']?> ₴</h3>
                                        <p class="card-text fs-2""><?=$recentlyHouses[$j]['description']?></p>
                                        <a href="/houses/view/<?=$recentlyHouses[$j]['id_house']?>" class="btn btn-primary">Перейти</a>
                                    </div>
                                </div>
                            <?php endfor; ?>
                        <?php endif; ?>
                        <?php if ($i == 2) : ?>
                            <?php for ($j = 6; $j < 9; $j++) : ?>
                                <?php $photo = explode(',',$recentlyHouses[$j]['photos']) ?>
                                <div class="card">
                                    <img src="/files/houses/<?=$photo[0]?>" class="card-img-top img-wrapper" alt="..." >
                                    <div class="card-body">
                                        <h4 class="card-title"><?= $recentlyHouses[$j]['title'] ?></h4>
                                        <h3><?=$recentlyHouses[$j]['price']?> ₴</h3>
                                        <p class="card-text fs-2""><?=$recentlyHouses[$j]['description']?></p>
                                        <a href="/houses/view/<?=$recentlyHouses[$j]['id_house']?>" class="btn btn-primary">Перейти</a>
                                    </div>
                                </div>
                            <?php endfor; ?>
                        <?php endif; ?>
                    </div>
                </div>
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
<html>
<script src="/themes/main/js/mainIndex.js" defer></script>