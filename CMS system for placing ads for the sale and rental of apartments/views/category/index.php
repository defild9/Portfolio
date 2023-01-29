<?php
/** @var array $rows*/
/** @var array $citys */
var_dump($_POST);
use models\User;
?>
<section class="vh-100" style="background: #eee">
    <div class="container py-5 h-100">
        <h2 class="text-center fw-bold m-3">Список категорій</h2>
        <div class="text-end mb-3">
            <?php if (User::isAdmin()) : ?>
                <div>
                    <a href="/category/add" class="btn btn-success">Додати категорію</a>
                </div>
            <?php endif; ?>
        </div>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <?php foreach ($rows as $row) : ?>
                <div class="col">
                    <a href="/category/view/<?=$row['id_category']?>" class="card-link">
                        <div class="card categories-list">
                            <div class="card-body">
                                <h5 class="card-title text-center"><?=$row['name_category']?></h5>
                            </div>
                            <?php if (User::isAdmin()) : ?>
                                <div class="card-body text-center">
                                    <a href="/category/edit/<?=$row['id_category']?>" class="btn btn-primary">Редугувати</a>
                                    <a href="/category/delete/<?=$row['id_category']?>" class="btn btn-danger">Видалити</a>
                                </div>
                            <?php endif; ?>
                        </div>
                    </a>
                </div>
            <?php endforeach; ?>
        </div>
    </div>
</section>
