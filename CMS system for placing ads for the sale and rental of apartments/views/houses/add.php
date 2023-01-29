<?php
/** @var array $model */
/** @var array $errors */
/** @var array $categories */
/** @var array $citys */
?>

<!--<div class="container">-->
<!--    <h2>Додавання оголошення</h2>-->
<!--    <form action="" method="post" enctype="multipart/form-data">-->
<!--        <div class="mb-3">-->
<!--            <label for="title" class="form-label">Назва</label>-->
<!--            <input type="text" class="form-control" name="title" id="title" aria-describedby="titleHelp">-->
<!--            --><?php //if (!empty($errors['title'])): ?>
<!--                <div id="titleHelp" class="form-text">--><?//= $errors['title']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="file" class="form-label">Файли оголошення</label>-->
<!--            <input multiple type="file" class="form-control" name="photos[]" id="photos" accept="image/jpeg">-->
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="id_category" class="form-label">Категорія</label>-->
<!--            <select class="form-control" name="id_category" id="id_category">-->
<!--                --><?php //foreach ($categories as $category) : ?>
<!--                    <option value="--><?//= $category['id_category'] ?><!--">--><?//= $category['name_category'] ?><!--</option>-->
<!--                --><?php //endforeach; ?>
<!--            </select>-->
<!--            --><?php //if (!empty($errors['id_category'])): ?>
<!--                <div id="titleHelp" class="form-text">--><?//= $errors['id_category']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="price" class="form-label">Ціна</label>-->
<!--            <input type="number" class="form-control" name="price" id="price" aria-describedby="priceHelp">-->
<!--            --><?php //if (!empty($errors['price'])): ?>
<!--                <div id="priceHelp" class="form-text">--><?//= $errors['price']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="count_of_room" class="form-label">Кількість кімнат</label>-->
<!--            <input type="number" class="form-control" name="count_of_room" id="count_of_room"-->
<!--                   aria-describedby="count_of_roomHelp">-->
<!--            --><?php //if (!empty($errors['count_of_room'])): ?>
<!--                <div id="count_of_roomHelp" class="form-text">--><?//= $errors['count_of_room']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="total_area" class="form-label">Загальна площа</label>-->
<!--            <input type="number" class="form-control" name="total_area" id="total_area"-->
<!--                   aria-describedby="total_areaHelp">-->
<!--            --><?php //if (!empty($errors['total_area'])): ?>
<!--                <div id="total_areaHelp" class="form-text">--><?//= $errors['total_area']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="living_area" class="form-label">Житлова площа</label>-->
<!--            <input type="number" class="form-control" name="living_area" id="living_area"-->
<!--                   aria-describedby="living_areaHelp">-->
<!--            --><?php //if (!empty($errors['living_area'])): ?>
<!--                <div id="living_areaHelp" class="form-text">--><?//= $errors['living_area']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="kitchen_area" class="form-label">Площа кухні</label>-->
<!--            <input type="number" class="form-control" name="kitchen_area" id="kitchen_area"-->
<!--                   aria-describedby="kitchen_areaHelp">-->
<!--            --><?php //if (!empty($errors['kitchen_area'])): ?>
<!--                <div id="kitchen_areaHelp" class="form-text">--><?//= $errors['kitchen_area']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="street" class="form-label">Вулиця</label>-->
<!--            <input type="text" class="form-control" name="street" id="street" aria-describedby="streetHelp">-->
<!--            --><?php //if (!empty($errors['street'])): ?>
<!--                <div id="streetHelp" class="form-text">--><?//= $errors['street']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="city" class="form-label">Місто</label>-->
<!--            <input type="text" class="form-control" name="city" id="city" list="citys" aria-describedby="cityHelp"-->
<!--                   placeholder="Введіть місто">-->
<!--            <datalist id="citys">-->
<!--                --><?php //foreach ($citys as $city) : ?>
<!--                    <option value="--><?//= $city ?><!--">--><?//= $city ?><!--</option>-->
<!--                --><?php //endforeach; ?>
<!--            </datalist>-->
<!--            --><?php //if (!empty($errors['city'])): ?>
<!--                <div id="cityHelp" class="form-text">--><?//= $errors['city']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="street_num" class="form-label">Номер вулиці</label>-->
<!--            <input type="text" class="form-control" name="street_num" id="street_num" aria-describedby="street_numHelp">-->
<!--            --><?php //if (!empty($errors['street_num'])): ?>
<!--                <div id="street_numHelp" class="form-text">--><?//= $errors['street_num']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="house_num" class="form-label">Номер квартири/будинку</label>-->
<!--            <input type="number" class="form-control" name="house_num" id="house_num" aria-describedby="house_numHelp">-->
<!--            --><?php //if (!empty($errors['house_num'])): ?>
<!--                <div id="house_numHelp" class="form-text">--><?//= $errors['house_num']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <label for="description" class="form-label">Опис</label>-->
<!--            <textarea class="editor form-control" name="description" id="description"-->
<!--                      aria-describedby="descriptionHelp"></textarea>-->
<!--            --><?php //if (!empty($errors['description'])): ?>
<!--                <div id="descriptionHelp" class="form-text">--><?//= $errors['description']; ?><!--</div>-->
<!--            --><?php //endif; ?>
<!--        </div>-->
<!--        <button type="submit" class="btn btn-primary">Додати</button>-->
<!--    </form>-->
<!--</div>-->

<section class="wh-100" style="background-color: #eee;">
    <div class="container py-5 h-100">
        <div class="row justify-content-center align-items-center h-100">
            <div class="col-12 col-lg-9 col-xl-7">
                <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                    <div class="card-body p-4 p-md-5">
                        <form action="" method="post" enctype="multipart/form-data">
                            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5 text-center">Створити оголошення</h3>
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <div class="form-outline">
                                        <label for="title" class="form-label">Назва оголошення</label>
                                        <input type="text" class="form-control" name="title" id="title"
                                               aria-describedby="titleHelp">
                                        <?php if (!empty($errors['title'])): ?>
                                            <div id="titleHelp" class="form-text"><?= $errors['title']; ?></div>
                                        <?php endif; ?>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <label for="file" class="form-label">Файли оголошення</label>
                                    <input multiple type="file" class="form-control" name="photos[]" id="photos"
                                           accept="image/jpeg">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <label for="id_category" class="form-label">Категорія</label>
                                    <select class="form-control" name="id_category" id="id_category">
                                        <option value="" selected="true" class="disabled" disabled="disabled">Виберіть
                                            категорію
                                        </option>
                                        <?php foreach ($categories as $category) : ?>
                                            <option value="<?= $category['id_category'] ?>"><?= $category['name_category'] ?></option>
                                        <?php endforeach; ?>
                                    </select>
                                    <?php if (!empty($errors['id_category'])): ?>
                                        <div id="titleHelp" class="form-text"><?= $errors['id_category']; ?></div>
                                    <?php endif; ?>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <label for="price" class="form-label">Ціна</label>
                                    <div class="input-group">
                                        <input type="number" class="form-control" name="price" id="price"
                                               aria-describedby="priceHelp">
                                        <div class="fw-bold m-lg-3">грн</div>
                                    </div>
                                    <?php if (!empty($errors['price'])): ?>
                                        <div id="priceHelp" class="form-text"><?= $errors['price']; ?></div>
                                    <?php endif; ?>
                                </div>
                            </div>
                            <fieldset>
                                <legend>Загальна інформація</legend>
                                <div class="row">
                                    <div class="col-md-3 mb-4">
                                        <label for="count_of_room" class="form-label">Кількість кімнат</label>
                                        <input type="number" class="form-control" name="count_of_room"
                                               id="count_of_room"
                                               aria-describedby="count_of_roomHelp">
                                        <?php if (!empty($errors['count_of_room'])): ?>
                                            <div id="count_of_roomHelp"
                                                 class="form-text"><?= $errors['count_of_room']; ?></div>
                                        <?php endif; ?>
                                    </div>
                                    <div class="col-md-3 mb-4">
                                        <label for="total_area" class="form-label">Загальна площа</label>
                                        <input type="number" class="form-control" name="total_area" id="total_area"
                                               aria-describedby="total_areaHelp">
                                        <?php if (!empty($errors['total_area'])): ?>
                                            <div id="total_areaHelp"
                                                 class="form-text"><?= $errors['total_area']; ?></div>
                                        <?php endif; ?>
                                    </div>
                                    <div class="col-md-3 mb-4">
                                        <label for="living_area" class="form-label">Житлова площа</label>
                                        <input type="number" class="form-control" name="living_area" id="living_area"
                                               aria-describedby="living_areaHelp">
                                        <?php if (!empty($errors['living_area'])): ?>
                                            <div id="living_areaHelp"
                                                 class="form-text"><?= $errors['living_area']; ?></div>
                                        <?php endif; ?>
                                    </div>
                                    <div class="col-md-3 mb-4">
                                        <label for="kitchen_area" class="form-label">Площа кухні</label>
                                        <input type="number" class="form-control" name="kitchen_area" id="kitchen_area"
                                               aria-describedby="kitchen_areaHelp">
                                        <?php if (!empty($errors['kitchen_area'])): ?>
                                            <div id="kitchen_areaHelp"
                                                 class="form-text"><?= $errors['kitchen_area']; ?></div>
                                        <?php endif; ?>
                                    </div>
                                </div>
                            </fieldset>
                            <fieldset>
                                <legend>Адреса</legend>
                                <div class="row">
                                    <div class="col-md-12 mb-4">
                                        <label for="city" class="form-label">Місто</label>
                                        <input type="text" class="form-control" name="city" id="city" list="citys" aria-describedby="cityHelp"
                                               placeholder="Введіть місто">
                                        <datalist id="citys">
                                            <?php foreach ($citys as $city) : ?>
                                                <option value="<?= $city ?>"><?= $city ?></option>
                                            <?php endforeach; ?>
                                        </datalist>
                                        <?php if (!empty($errors['city'])): ?>
                                            <div id="cityHelp" class="form-text"><?= $errors['city']; ?></div>
                                        <?php endif; ?>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 mb-4">
                                            <label for="street" class="form-label">Вулиця</label>
                                            <input type="text" class="form-control" name="street" id="street" aria-describedby="streetHelp">
                                            <?php if (!empty($errors['street'])): ?>
                                                <div id="streetHelp" class="form-text"><?= $errors['street']; ?></div>
                                            <?php endif; ?>
                                        </div>
                                        <div class="col-md-4 mb-4">
                                            <label for="street_num" class="form-label">Номер вулиці</label>
                                            <input type="text" class="form-control" name="street_num" id="street_num" aria-describedby="street_numHelp">
                                            <?php if (!empty($errors['street_num'])): ?>
                                                <div id="street_numHelp" class="form-text"><?= $errors['street_num']; ?></div>
                                            <?php endif; ?>
                                        </div>
                                        <div class="col-md-4 mb-4">
                                            <label for="house_num" class="form-label">Номер квартири/будинку</label>
                                            <input type="number" class="form-control" name="houses_num" id="houses_num" aria-describedby="house_numHelp">
                                            <?php if (!empty($errors['house_num'])): ?>
                                                <div id="house_numHelp" class="form-text"><?= $errors['houses_num']; ?></div>
                                            <?php endif; ?>
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                            <div class="row">
                                <div class="col-md-12 mb-4">
                                    <label for="description" class="form-label">Опис</label>
                                    <textarea class="editor form-control" name="description" id="description"
                                              aria-describedby="descriptionHelp"></textarea>
                                    <?php if (!empty($errors['description'])): ?>
                                        <div id="descriptionHelp" class="form-text"><?= $errors['description']; ?></div>
                                    <?php endif; ?>
                                </div>
                            </div>
                            <div class="mt-4 pt-2">
                                <button type="submit" class="btn btn-primary btn-lg form-control">Додати</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
</section>

<script src="https://cdn.ckeditor.com/ckeditor5/35.4.0/classic/ckeditor.js"></script>
<script>
    ClassicEditor
        .create(document.querySelector('.editor'))
        .catch(error => {
            console.error(error);
        });
</script>
<script src="/themes/main/js/addHouses.js" defer></script>
