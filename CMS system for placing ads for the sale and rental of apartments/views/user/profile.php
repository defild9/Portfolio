<?php
/** @var array $user */
/** @var array $userCategory*/
/** @var array $userItem */

?>
<section style="background-color: #eee;">
    <div class="container py-5">
        <div class="row">
            <div class="col-lg-4">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="text-center">
                            <?php
                            $filepath = 'files/users/'. $user['photo'];
                            ?>
                            <?php if(is_file($filepath)) : ?>
                                <img src="/<?=$filepath?>" alt="avatar"
                                     class="rounded-circle img-fluid" style="width: 150px; height:150px ">
                            <?php else : ?>
                                <img src="https://mdbootstrap.com/img/Photos/Others/placeholder-avatar.jpg" alt="avatar"
                                     class="rounded-circle img-fluid" style="width: 150px; height:150px ">
                            <?php endif; ?>
                            <h5 class="my-3"><?=$user['firstname']?> <?=$user['lastname']?></h5>
                            <p class="text-secondary mb-1"><?=$userCategory['type']?></p>
                        </div>
                    </div>
                    <div class="row text-center mb-4">
                        <div class="col-12">
                            <p><strong>Номер телефону:</strong> <?=$user['phone_number']?></p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8">
                <div class="card mb-4">
                    <div class="card-body">
                        <?php if (empty($userItem)) : ?>
                            <h1 class="text-center">Користувач не додав еще оголошення</h1>
                        <?php else: ?>
                            <?php foreach ($userItem as $item) : ?>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-12 col-lg-3 col-xl-3 mb-4 mb-lg-0">
                                            <div class="bg-image hover-zoom ripple rounded ripple-surface">
                                                <?php
                                                    $photos = explode(',', $item['photos']);
                                                    $filepathItem = 'files/houses/'. $photos[0];
                                                    $category = \models\Category::getCategoryById($item['id_category']);
                                                ?>
                                                <?php if(file_exists($filepathItem)) : ?>
                                                    <img src="/<?=$filepathItem?>" class="w-100">
                                                <?php else: ?>
                                                    <img src="/static/images/no-image.jpg" class="w-100">
                                                <?php endif; ?>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-lg-6 col-xl-6">
                                            <h5><?=$item['title']?></h5>
                                            <div class="d-flex flex-row">
                                                <span></span>
                                            </div>
                                            <div class="mt-1 mb-0 text-muted small">
                                                <span><?=$item['city']?></span>
                                                <span class="text-primary"> • </span>
                                                <span><?=$item['street']?></span>
                                                <span class="text-primary"> • </span>
                                                <span><?=$item['street_num']?><br></span>
                                            </div>
                                            <div class="mb-2 text-muted small">
                                                <span><?=$category['name_category']?></span>
                                            </div>
                                            <p class="text-truncate mb-4 mb-md-0">
                                                <?=$item['description']?>
                                            </p>
                                        </div>
                                        <div class="col-md-6 col-lg-3 col-xl-3 border-sm-start-none border-start">
                                            <div class="d-flex flex-row align-items-center mb-1">
                                                <h4 class="mb-1 me-1"><?=$item['price']?> ₴</h4>
                                            </div>
                                            <div class="d-flex flex-column mt-4">
                                                <a href="/houses/view/<?=$item['id_house']?>" class="btn btn-primary btn-sm">Детальніше</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr>
                            <?php endforeach; ?>
                        <?php endif; ?>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>