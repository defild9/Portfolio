<?php
/** @var array $errors */
?>
<!--<h1 class="text-center">Зміна паролю</h1>-->
<!--<main class="form-signin w-100 m-auto">-->
<!--    <form action="" method="post">-->
<!--        <div class="mb-3">-->
<!--            <lable for="password" class="form-label">Новий пароль:</lable>-->
<!--            <input type="password" name="passwordNew" id="passwordNew" class="form-control" aria-describedby="passwordHelp">-->
<!--            --><?php //if(!empty($errors['passwordNew'])):?>
<!--                <div id="passwordHelp" class="form-text">--><?//=$errors['passwordNew'];?><!--</div>-->
<!--            --><?php //endif;?>
<!--        </div>-->
<!--        <div class="mb-3">-->
<!--            <lable for="password" class="form-label">Пароль:</lable>-->
<!--            <input type="password" name="password" id="password" class="form-control" aria-describedby="passwordHelp">-->
<!--            --><?php //if(!empty($errors['password'])):?>
<!--                <div id="passwordHelp" class="form-text">--><?//=$errors['password'];?><!--</div>-->
<!--            --><?php //endif;?>
<!--        </div>-->
<!---->
<!--        <button class="w-100 btn btn-lg btn-primary" type="submit">Увійти</button>-->
<!--    </form>-->
<!--</main>-->

<section class="vh-100" style="background-color: #eee;">
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card shadow-2-strong" style="border-radius: 1rem;">
                    <div class="card-body p-5">
                        <div class="text-center">
                            <h3 class="mb-5">Змінити пароль</h3>
                            <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                <strong>Увага!</strong> Після зміни паролю ви вийдете з аккаунту.
                            </div>
                        </div>
                        <form action="" method="post">
                            <div class="form-outline mb-4">
                                <label class="form-label" for="typeEmailX-2">Новий пароль</label>
                                <input type="password" name="passwordNew" id="passwordNew" aria-describedby="passwordHelp" class="form-control form-control-lg" />
                                <?php if(!empty($errors['passwordNew'])):?>
                                    <div id="passwordHelp" class="form-text"><?=$errors['passwordNew'];?></div>
                                <?php endif;?>
                            </div>
                            <div class="form-outline mb-4">
                                <label class="form-label" for="typePasswordX-2">Старий пароль</label>
                                <input type="password" name="password" id="password" aria-describedby="passwordHelp" class="form-control form-control-lg" />
                                <?php if(!empty($errors['password'])):?>
                                    <div id="passwordHelp" class="form-text"><?=$errors['password'];?></div>
                                <?php endif;?>
                            </div>
                            <button class="btn btn-primary btn-lg w-100" type="submit">Змінити</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
