<?php
/** @var string|null $error */
/** @var array $model */
\core\Core::getInstance()->pageParams['title'] = 'Вхід'
?>
<div class="conatiner">
    <section  style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col col-xl-10">
                    <div class="card" style="border-radius: 1rem;">
                        <div class="row g-0">
                            <div class="col-md-6 col-lg-5 d-none d-md-block">
                                <img src="/static/images/for-log.jfif" alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
                            </div>
                            <div class="col-md-6 col-lg-7 d-flex align-items-center">
                                <div class="card-body p-4 p-lg-5 text-black">

                                    <form action="" method="post">

                                        <div class="d-flex align-items-center mb-3 pb-1">
                                            <div class="text-center h1 fw-bold mb-0">DreamHome</div>
                                        </div>

                                        <h5 class="fw-normal mb-3 pb-3 " style="letter-spacing: 1px;">Увійти до аккаунту</h5>
                                        <?php if(!empty($error)) : ?>
                                            <div class="message_error fw-normal mb-3 pb-3">
                                                <?=$error?>
                                            </div>
                                        <?php endif; ?>

                                        <div class="form-outline mb-4">
                                            <input type="email" class="form-control form-control-lg" name="email" id="email" value="<?=$model['email']?>" placeholder="Електронна адреса" />
                                            <label class="form-label" for="email">Електронна адреса</label>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <input type="password" class="form-control form-control-lg" name="password" id="password" placeholder="Пароль" />
                                            <label class="form-label" for="form2Example27">Пароль</label>
                                        </div>

                                        <div class="pt-1 mb-4 ">
                                            <button class="btn btn-dark btn-lg btn-block" type="submit">Увійти</button>
                                        </div>

                                        <p class="mb-5 pb-lg-2" style="color: #393f81;">Немає аккаунту?
                                            <a href="/user/register" style="color: #393f81;">Зареєструватися</a>
                                        </p>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
