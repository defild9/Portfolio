<?php
/** @var array $model */
/**@var array $errors */
?>

<section class="vh-100" style="background-color: #eee;">
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                <div class="card shadow-2-strong" style="border-radius: 1rem;">
                    <div class="card-body p-5">
                        <div class="text-center">
                            <h3 class="mb-4 ">Додати категорію</h3>
                            <form action="" method="post">
                                <div class="form-outline mb-4">
                                    <label for="name_category" class="form-label fw-bold">Назва категорії</label>
                                    <input type="text" class="form-control" name="name_category" id="name_category"
                                           aria-describedby="name_categoryHelp">
                                    <?php if (!empty($errors['name_category'])): ?>
                                        <div id="name_categoryHelp" class="form-text"><?= $errors['name_category']; ?></div>
                                    <?php endif; ?>
                                </div>
                                <button type="submit" class="btn btn-primary w-100">Додати</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
