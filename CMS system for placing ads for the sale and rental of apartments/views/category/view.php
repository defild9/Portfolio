<?php
/** @var array $category */
/** @var array $houses */
/** @var array $citys */

?>
<div class="container mt-4 wh-100">
    <div class="row">
        <h1 class="mb-3 text-center"><?=$category['name_category'] ?></h1>
        <div class="col-lg-3">
            <div class="card mb-4">
                <div class="card-body">
                    <form action="" method="post">
                        <div class="h4 text-center">
                            Фільтр
                        </div>
                        <div class="col-lg-12 mb-3">
                            <div class="row">
                                <div class="col-lg-12">
                                    <select class="form-select d-none" name="parametr">
                                        <option value="" selected="true" class="disabled" disabled="disabled">Без сортурування
                                        </option>
                                        <option value="1">Ціна за спаданням</option>
                                        <option value="2">Ціна по возрастанию</option>
                                        <option value="3">Кількість кімнат за спаданням</option>
                                        <option value="3">Кулькість кумнат по возрастанию</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-lg-6">
                                <label for="count_room" class="form-label">Кількість кімнат</label>
                            </div>
                            <div class="col-lg-6">
                                <input type="number" id="count_room" name="count_of_room" class="form-control w-100" aria-describedby="count_room">
                            </div>
                        </div>
                        <div class="row md-3">
                            <div class="col-lg-6"><label for="city" class="form-label">Місто</label></div>
                            <div class="col-lg-6">
                                <input type="text" class="form-control" name="city" id="city" list="citys" aria-describedby="cityHelp"
                                                         placeholder="Введіть місто">
                                <datalist id="citys">
                                    <?php foreach ($citys as $city) : ?>
                                        <option value="<?= $city ?>"><?= $city ?></option>
                                    <?php endforeach; ?>
                                </datalist>
                            </div>
                        </div>
                        <div class="row mt-3 md-3">
                            <div class="col-lg-12">
                                <input type="submit" class="btn btn-primary w-100">
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div class="col-lg-9">
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <?php foreach ($houses as $house) : ?>
                    <?php
                    $photos = explode(',',$house['photos']);
                    $filepath = 'files/houses/'. $photos[0];
                    ?>
                    <div class="col">
                        <a href="/houses/view/<?=$house['id_house']?>" class="card-link text-decoration-none">
                            <div class="card">
                                <?php if(is_file($filepath)) : ?>
                                    <img src="/<?=$filepath?>" class="card-img-top img-fluid" alt="..." style="height: 200px; width: 400px">
                                <?php else: ?>
                                    <img src="/static/images/no-image.jpg" class="card-img-top img-fluid" alt="..." style="height: 200px; width: 400px">
                                <?php endif; ?>
                                <div class="card-body">
                                    <h4 class="text-center"><?=$house['title']?></h4>
                                    <h5><?=$house['price']?> ₴</h5>
                                    <p class="card-text"><?=$house['city']?>,&nbsp<?=$house['street']?>&nbsp<?=$house['street_num']?></p>
                                    <p class="card-text"><?=$house['description']?></p>
                                </div>
                            </div>
                        </a>
                    </div>
                <?php endforeach; ?>
            </div>
        </div>
    </div>
</div>
<script>
    let dataset = document.getElementById('citys');


    fetch('https://developers.ria.com/dom/states?api_key=ANyN1lIwTFKQeavggXo6FfNp5DaO5sgVfZE1212Y').then(
        (response)=> response.json()).then(citys => {
        for(let city of citys){
            let option = document.createElement("option");
            option.value = city.region_name;
            option.text = city.region_name;
            dataset.appendChild(option);
        }
    });
</script>