<?php
    use core\Core;
    Core::getInstance()->pageParams['title'] = 'Помилка 404'
?>

<body>
<div class="d-flex align-items-center justify-content-center vh-100 alert alert-danger ">
    <div class="text-center">
        <h1 class="display-1 fw-bold">404</h1>
        <p class="fs-3"> <span><strong>Ой!!</strong></span>Схоже ми не можемо знайти сторінку<br>яку ви шукаєте.</p>
        <a href="/" class="btn btn-outline-danger">На головну</a>
    </div>
</div>
</body>
