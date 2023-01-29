<?php
/** @var array $category */
?>
<section class="vh-100" style="background-color: #eee;">
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col-12 col-md-8 col-lg-6 col-xl-5 ">
                <div class="card shadow-2-strong alert alert-danger" style="border-radius: 1rem;">
                    <div class="card-body p-5">
                        <div class="text-center">
                            <h3 class="mb-4">Видалити категорію <strong>"<?=$category['name_category']?>"</strong>?</h3>
                            <hr>
                            <div class="mb-3" role="alert">
                                <strong>Увага!</strong> Після видалення категорії всі оголошення данної категорії будуть видалені.
                            </div>
                            <div class="row">
                                <div class="col-6">
                                    <a href="/category/delete/<?=$category['id_category']?>/yes" class="btn w-100 btn-danger">Видалити</a>
                                </div>
                                <div class="col-6">
                                    <a href="/category" class="btn w-100 btn-warning">Відмінити</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>