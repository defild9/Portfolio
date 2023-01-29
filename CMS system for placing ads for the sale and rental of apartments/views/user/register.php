<?php
/** @var array $errors */
/** @var array $model */
/** @var array $types */
\core\Core::getInstance()->pageParams['title'] = 'Реєстрація';
?>

<section style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5">Реєстрація</h3>
                            <form action="" method="post" enctype="multipart/form-data">
                                <div class="row">
                                    <div class="col-md-6 mb-4">
                                        <div class="form-outline">
                                            <?php if (!empty($errors['firstname'])): ?>
                                                <div id="firstnameHelp" class="form-text message_error pt-3"><?= $errors['firstname']; ?></div>
                                            <?php endif; ?>
                                            <input type="text" name="firstname" id="firstname" value="<?= $model['firstname'] ?>" aria-describedby="firstnameHelp" class="form-control form-control-lg"/>
                                            <label class="form-label" for="firstname">Ім'я</label>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <?php if (!empty($errors['lastname'])): ?>
                                            <div id="lastnameHelp" class="form-text message_error pt-3"><?= $errors['lastname']; ?></div>
                                        <?php endif; ?>
                                        <div class="form-outline">
                                            <input type="text" name="lastname" id="lastname" value="<?= $model['lastname'] ?>" aria-describedby="lastnameHelp" class="form-control form-control-lg"/>
                                            <label class="form-label" for="lastName">Призвіще</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 mb-4 pb-2">
                                        <?php if (!empty($errors['email'])): ?>
                                            <div id="emailHelp" class="form-text message_error pt-3"><?= $errors['email']; ?></div>
                                        <?php endif; ?>
                                        <div class="form-outline">
                                            <input type="email" name="email" id="email" value="<?= $model['email'] ?>" aria-describedby="emailHelp" class="form-control form-control-lg"/>
                                            <label class="form-label" for="emailAddress">Електронна адресса</label>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-4 pb-2">
                                        <div class="form-outline">
                                            <?php if (!empty($errors['phone_number'])): ?>
                                                <div id="phone_numberHelp" class="form-text message_error pt-3"><?= $errors['phone_number']; ?></div>
                                            <?php endif; ?>
                                            <input type="tel" name="phone_number" id="phone_number" value="<?= $model['phone_number'] ?>" aria-describedby="phone_numberHelp" class="form-control form-control-lg"/>
                                            <label class="form-label" for="phoneNumber">Номер телефону</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 w-100  pb-3">
                                        <?php if (!empty($errors['id_user_type'])): ?>
                                            <div id="titleHelp" class="form-text message_error pt-3"><?= $errors['id_user_type']; ?></div>
                                        <?php endif; ?>
                                        <select class="form-select form-control-lg" name="id_user_type" id="id_user_type">
                                            <?php foreach ($types as $item) : ?>
                                                <option value="<?= $item['id_user_type'] ?>"><?= $item["type"] ?></option>
                                            <?php endforeach; ?>
                                        </select>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 pb-3">
                                        <input type="file" class="form-control" name="avatar" id="avatar" accept="image/jpeg"/>
                                        <label for="file" class="form-label">Файл для профілю</label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 pb-3">
                                        <?php if (!empty($errors['password'])): ?>
                                            <div id="passwordHelp" class="form-text message_error pt-3"><?= $errors['password']; ?></div>
                                        <?php endif; ?>
                                        <input type="password" name="password" id="password" class="form-control" aria-describedby="passwordHelp">
                                        <lable for="password" class="form-label">Пароль</lable>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12 pb-3">
                                        <?php if (!empty($errors['password2'])): ?>
                                            <div id="password2Help" class="form-text message_error pt-3"><?= $errors['password2']; ?></div>
                                        <?php endif; ?>
                                        <input type="password" name="password2" id="password2" class="form-control" aria-describedby="password2Help">
                                        <lable for="password2" class="form-label">Пароль (ще раз):</lable>
                                    </div>
                                </div>
                                <div class="mt-4 pt-2">
                                    <input class="btn btn-primary btn-lg form-control" type="submit" value="Зареєструватися"/>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</section>

