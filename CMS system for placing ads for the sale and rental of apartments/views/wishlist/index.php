<?php
/** @var array|null $wishlists */
?>
<div class="container">
    <div class="row">
        <?php if(empty($wishlists)) :?>
        <section>
            <div class="container py-5 h-100 mt-lg-5">
                <div class="row justify-content-center align-items-center h-100">
                    <div class="col-12 col-lg-9 p-4 col-xl-7">
                        <div class="p-5">
                            <div class="p-4 p-md-5">
                                <div class="row">
                                    <div class="col-sm-12 text-center p-5 empty-page mb-5">
                                        <i class="icon an an-cart-arrow-down"></i>
                                        <h2>Списку вподобань пустий!</h2>
                                        <p class="mb-3 pb-1">У вас немає вибраних оголошень.</p>
                                        <a href="/houses/" class="btn btn-primary">Дивитися оголошення</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <?php else: ?>
            <h1 class="h1 fs-3 text-center mt-lg-5">Список вподобань</h1>
            <?php foreach ($wishlists as $item) : ?>
                <?php $house = \models\Houses::getHousesById($item['id_house']);
                    $category = \models\Category::getCategoryById($house['id_category']);
                    $photo = explode(',', $house['photos'])
                ?>
                <div class="card rounded-3 mb-1 mt-4">
                    <a href="/houses/view/<?=$house['id_house']?>">
                        <div class="card-body p-4">
                            <div class="row d-flex justify-content-between align-items-center">
                                <div class="col-md-2 col-lg-2 col-xl-2">
                                    <?php if(!empty($house['photos'])) : ?>
                                        <img src="/files/houses/<?=$photo[0]?>" class="img-fluid rounded-3" alt="Cotton T-shirt">
                                    <?php else: ?>
                                        <img src="/static/images/no-image.jpg" class="img-fluid rounded-3" alt="Cotton T-shirt">
                                    <?php endif; ?>
                                </div>
                                <div class="col-md-5 col-lg-5 col-xl-5">
                                    <p class=" mb-2 h4"><?=$house['title']?></p>
                                    <p><span class="fw-normal"><?=$house['street']?> <?=$house['street_num']?>, <?=$house['city']?></p>
                                    <p><span class="fw-light"><?=$category['name_category']?></span></p>
                                </div>
                                <div class="col-md-4 col-lg-3 col-xl-3 offset-lg-1">
                                    <h5 class="mb-0">Ціна: <?=$house['price']?>$</h5>
                                </div>
                                <div class="col-md-1 col-lg-1 col-xl-1 text-end remove" data-id-house="<?=$item['id_house']?>">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" class="bi bi-trash3-fill text-danger" viewBox="0 0 16 16">
                                        <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"/>
                                    </svg>
                                </div>
                            </div>
                        </div>
                    </div>
                </a>
            <?php endforeach; ?>
        <?php endif;?>
    </div>
</div>
<script src="/themes/main/js/wishlist.js" defer></script>