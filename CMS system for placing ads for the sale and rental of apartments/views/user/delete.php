<?php
/** @var array $errors */
?>

<section class="vh-100" style="background-color: #eee;">
    <div class="container h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="text-center card shadow-2-strong alert alert-danger alert-dismissible" style="border-radius: 1rem;">
                    <div class="card-body p-4">
                        <h4 class="alert-heading"><strong>Видалити?</strong></h4>
                        <p>Після видалення всі ваші оголошення будуть видалені!</p>
                        <hr>
                        <form action="" method="post">
                            <div class="mb-3">
                                <lable for="password" class="form-label">Підтвердіть пароль:</lable>
                                <input type="password" name="password" id="password" class="form-control" aria-describedby="passwordHelp">
                                <?php if(!empty($errors['password'])):?>
                                    <div id="passwordHelp" class="form-text"><?=$errors['password'];?></div>
                                <?php endif;?>
                            </div>
                            <div class="row">
                                <div class="col-6 pl-3">
                                    <button class="w-100 btn btn-lg btn-primary" type="submit">Удалити</button>
                                </div>
                                <div class="col-6">
                                    <a href="/dashboard" class="btn w-100  btn-lg btn-warning">Відмінити</a>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
