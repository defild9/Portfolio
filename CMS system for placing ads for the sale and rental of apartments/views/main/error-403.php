<?php
    use core\Core;
    Core::getInstance()->pageParams['title'] = 'Помилка 404'
?>

<body>
<div class="d-flex align-items-center justify-content-center vh-100 alert alert-danger ">
    <div class="text-center">
        <h1 class="display-1 fw-bold">403</h1>
        <p class="fs-3"> <span><strong>Вибач,</strong></span> але у тебе немає доступу<br>до цієї сторінки</p>
        <a href="/" class="btn btn-outline-danger">На головну</a>
    </div>
</div>
</body>