<?php
/** @var array $userType */
/** @var array $user */
/** @var int $countSell */
/** @var int $rentCount */
/** @var int $newHouses */
/** @var array $userData */
/** @var array $myMessage */
/** @var array $fromMassage */
\core\Core::getInstance()->pageParams['title'] = 'Особистий кабінет';
//var_dump($user);
//var_dump($userType);
//echo $countSell;
?>
<div class="user-info" data-firstname="<?=$userData['firstname']?>" data-lastname = '<?=$user['lastname']?>'></div>
<body>
    <h1 class="text-center py-5">Особистий кабінет</h1>
    <div class="container">
        <div class="row d-flex justify-content-md-center">
            <div class="col-lg-4">
                <div class="shadow">
                    <div class="card mb-3 w-100 h-auto align-items-stretch">
                        <div class="card-body p-3">
                            <div class="row">
                                <div class="col-4">
                                    <?php if(isset($userData['photo'])) : ?>
                                        <img src="/files/users/<?=$userData['photo']?>" class="rounded-circle" height="80" alt="Avatar" loading="lazy" />
                                    <?php else:?>
                                        <img src="/static/images/no-image.jpg" class="rounded-circle" height="50" alt="Avatar" loading="lazy" />
                                    <?php endif; ?>
                                </div>
                            </div>
                            <div class="row">
                                <div>
                                    <h4><?=$userData['firstname']?> <?=$userData['lastname']?></h4>
                                </div>
                                <div class="row">
                                    <div class="col-5">
                                        <h6><?=$userType['type']?></h6>
                                    </div>
                                    <div class="col-7"><?=$userData['phone_number']?></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8 mb-3">
                <div class="row">
                    <div class="col-lg-4 mb-3">
                        <div class="shadow">
                            <div class="card">
                                <div class="card-body p-4">
                                    <div class="row">
                                        <div class="col col-lg-10">
                                            <b>
                                                <p>Квартир в продажі</p>
                                            </b>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <p><?=$countSell?></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 mb-3">
                        <div class="shadow">
                            <div class="card">
                                <div class="card-body p-4">
                                    <div class="row">
                                        <div class="col col-lg-10">
                                            <b>
                                                <p>Квартир для оренди</p>
                                            </b>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <p><?=$rentCount?></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="shadow">
                            <div class="card">
                                <div class="card-body p-4">
                                    <div class="row">
                                        <div class="col col-lg-10">
                                            <b>
                                                <p>Новобудов в продажі</p>
                                            </b>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <p><?=$newHouses?></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row d-flex justify-content-md-center mb-3">
            <div class="col-lg-4">
                <div class="shadow">
                    <div class="card">
                        <div class="card-body">
                            <div class="list-group list-group-light">
                                <div class="list-group-item list-group-item-action px-3 border-0 mt-2" id="edit">Редагувати профіль</div>
                                <div class="list-group-item list-group-item-action px-3 border-0 mt-2" id="delete">Видалити профіль</div>
                                <?php if(\models\User::isAdmin()) : ?>
                                    <div class="list-group-item list-group-item-action px-3 border-0 mt-2" id="addAdmin">Адміністрування</div>
                                <?php endif; ?>
                                <a href="/user/profile/<?=$user['id_user']?>" class="text-decoration-none">
                                    <div class="list-group-item list-group-item-action px-3 border-0 mt-2">Мої оголошення</div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8">
                <div id="action"></div>
                <div class="shadow">
                    <div class="card">
                        <div class="card-body">
                            <div class="row text-center">
                                <div class="col-lg-6 mb-3">
                                    <button type="button" class="btn btn-outline-info" id="toMess">Мої повідомлення</button>
                                </div>
                                <div class="col-lg-6 mb-3">
                                    <button type="button" class="btn btn-outline-info" id="forMess">Повідомлення до мене</button>
                                </div>
                                <div class="row">
                                    <div id="myMess">
                                        <table class="table">
                                            <thead>
                                            <tr>
                                                <th scope="col">#</th>
                                                <th scope="col">Кому</th>
                                                <th scope="col">Оголошення</th>
                                                <th scope="col">Питання</th>
                                                <th scope="col">Відповідь</th>
                                            </tr>
                                            </thead>
                                            <tbody>
                                            <?php if(empty($myMessage)) : ?>
                                                <h2>Повідомлень немає</h2>
                                            <?php else: ?>
                                                <?php for($i = 0; $i<count($myMessage); $i++) : ?>
                                                    <?php
                                                    $userTo = \models\User::getUserById($myMessage[$i]['user_to']);
                                                    $item = \models\Houses::getHousesById($myMessage[$i]['id_item']);
                                                    ?>
                                                    <tr>
                                                        <th scope="row"><?=$i+1?></th>
                                                        <td><a href="/user/profile/<?=$userTo['id_user']?>" class="text-decoration-none"><?=$userTo['firstname']?> <?=$userTo['lastname']?></a></td>
                                                        <td><a href="/houses/view/<?=$item['id_house']?>"><?=$item['title']?></a></td>
                                                        <td><?=$myMessage[$i]['message']?></td>
                                                        <td><textarea class="form-control" readonly><?=$myMessage[$i]['Answer']?></textarea></td>
                                                    </tr>
                                                <?php endfor; ?>
                                            <?php endif;?>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id="forMeMess" class="d-none">
                                        <table class="table">
                                            <thead>
                                            <tr>
                                                <th scope="col">#</th>
                                                <th scope="col">Відкого</th>
                                                <th scope="col">Оголошення</th>
                                                <th scope="col">Питання</th>
                                                <th scope="col">Відповідь</th>
                                                <th scope="col"></th>
                                            </tr>
                                            </thead>
                                            <tbody>
                                            <?php if(empty($fromMassage)) : ?>
                                                <h2>Повідомлень немає</h2>
                                            <?php else: ?>
                                                <?php for($i = 0; $i<count($fromMassage); $i++) : ?>
                                                    <?php
                                                    $userFrom = \models\User::getUserById($fromMassage[$i]['user_from']);
                                                    $itemFrom = \models\Houses::getHousesById($fromMassage[$i]['id_item']);
                                                    ?>
                                                    <tr>
                                                        <th scope="row"><?=$i+1?></th>
                                                        <td><a href="/user/profile/<?=$userFrom['id_user']?>" class="text-decoration-none"><?=$userFrom['firstname']?> <?=$userFrom['lastname']?></a></td>
                                                        <td><a href="/houses/view/<?=$itemFrom['id_house']?>"><?=$itemFrom['title']?></a></td>
                                                        <td><div class="messss"><?=$fromMassage[$i]['message']?></div></td>
                                                        <div class="answer">
                                                            <td><textarea class="form-control" chat="<?=$fromMassage[$i]['message']?>" data-from-chat="<?=$fromMassage[$i]['user_from']?>" data-item-chat="<?=$itemFrom['id_house']?>"><?=$fromMassage[$i]['Answer']?></textarea></td>
                                                            <td><button class="btn btn btn-outline-info button">Відповісти</button></td>
                                                        </div>
                                                    </tr>
                                                <?php endfor; ?>
                                            <?php endif;?>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="/themes/main/js/dashboard.js" defer></script>


