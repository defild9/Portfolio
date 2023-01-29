<?php
/** @var array $errors */
/** @var array $user */
/** @var array $types */
?>
<section style="background-color: #eee;">
    <form action="" method="post" enctype="multipart/form-data">
        <div class="container py-5 h-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5 text-center">Оновлення Профілю</h3>
                            <div class="text-center  mb-4">
                                <div>
                                    <div class="d-flex justify-content-center mb-4">
                                        <?php if(!empty($user['photo'])) : ?>
                                            <img src="/files/users/<?=$user['photo']?>"
                                             class="rounded-circle" alt="example placeholder" style="width: 200px; height: 200px" />
                                        <?php else:?>
                                            <img src="https://mdbootstrap.com/img/Photos/Others/placeholder-avatar.jpg"
                                             class="rounded-circle" alt="example placeholder" style="width: 200px;" />
                                        <?php endif; ?>
                                    </div>
                                    <div class="d-flex justify-content-center">
                                        <div class="btn btn-primary btn-rounded">
                                            <label class="form-label text-white m-1" for="avatar">Завантажити нову фотографію</label>
                                            <input type="file" class="form-control d-none" name="avatar" id="avatar" accept="image/jpeg" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <form>
                                <div class="row">
                                    <div class="col-md-6 mb-4">
                                        <div class="form-outline">
                                            <?php if(!empty($errors['firstname'])):?>
                                                <div id="firstnameHelp" class="form-text"><?=$errors['firstname'];?></div>
                                            <?php endif;?>
                                            <input type="text" name="firstname" id="firstname" class="form-control form-control-lg" value="<?=$user['firstname']?>" aria-describedby="firstnameHelp">
                                            <lable for="firstname" class="form-label">Ім'я</lable>
                                        </div>
                                    </div>
                                    <div class="col-md-6 mb-4">
                                        <?php if(!empty($errors['lastname'])):?>
                                            <div id="lastnameHelp" class="form-text"><?=$errors['lastname'];?></div>
                                        <?php endif;?>
                                        <input type="text" name="lastname" id="lastname" class="form-control form-control-lg" value="<?=$user['lastname']?>" aria-describedby="lastnameHelp">
                                        <lable for="lastname" class="form-label">Призвіще</lable>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6 mb-4 pb-2">
                                        <?php if(!empty($errors['email'])):?>
                                            <div id="emailHelp" class="form-text"><?=$errors['email'];?></div>
                                        <?php endif;?>
                                        <input type="email" name="email" id="email" class="form-control form-control-lg" value="<?=$user['email']?>" aria-describedby="emailHelp">
                                        <lable for="email" class="form-label">Електронна адресса</lable>
                                    </div>
                                    <div class="col-md-6 mb-4 pb-2">
                                        <div class="form-outline">
                                            <?php if(!empty($errors['phone_number'])):?>
                                                <div id="phone_numberHelp" class="form-text"><?=$errors['phone_number'];?></div>
                                            <?php endif;?>
                                            <input type="text" name="phone_number" id="phone_number" class="form-control form-control-lg" value="<?=$user['phone_number']?>" aria-describedby="phone_numberHelp">
                                            <lable for="phone_number" class="form-label">Номер телефону</lable>
                                        </div>
                                    </div>
                                </div>
                                <div class="mt-4 pt-2">
                                    <input class="btn btn-primary btn-lg form-control" type="submit" value="Обновити"/>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</section>
