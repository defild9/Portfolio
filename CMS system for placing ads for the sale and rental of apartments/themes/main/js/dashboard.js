var firstname = document.querySelector('.user-info').getAttribute('data-firstname');
var lastname = document.querySelector('.user-info').getAttribute('data-lastname');

function createEditProfile($click) {
    var content = "" +
        "<div class='card'><div class=\"card-body text-center\"><a href='/user/update' class='btn border border-primary rounded-pill'>Обновини загальні данні</a><br><a href='/user/change_password' class='btn border border-primary rounded-pill mt-5'>Змінити пароль</a></div></div>"
    $("#action").html(content);

}

function generateDeleteProfile() {
    var content = "" +
        "<div class='card'><div class=\"card-body text-center\"><a href='/user/delete' class='btn border border-primary rounded-pill'>Удалити аккаунт</a></div></div>"
    $("#action").append(content);
}

function getAllUsers() {
    $.ajax({
        url: "/user/showalluser",
        method: "POST",
        data: {
            ajax: 1
        },
        success: function (responce) {
            let objs = JSON.parse(responce);
            for (let obj of objs) {
                let option = document.createElement('option');
                option.setAttribute('value', obj['email']);
            }
        }
    })
}

function generateAddAdmin() {
    let users = getAllUsers();
    var content = "<div class='card w-100 h-auto'>"
    content += "<div class=\"card-body\">"
    content += "<h1 class='h3 text-center'>Додати адміністратора</h1>"
    content += '<div class="text-center">'
    content += "<input class='text-center' list='users' name='userEmail' id='userEmail'>"
    content += "<datalist id='users'>"
    content += $.ajax({
        url: "/user/showalluser",
        method: "POST",
        data: {
            ajax: 1
        },
        success: function (responce) {
            let objs = JSON.parse(responce);
            for (let obj of objs) {
                let option = document.createElement('option');
                option.setAttribute('value', obj.email);
                $("#users").append(option)
            }
        }
    })
    content += "</datalist>"
    content += "<button class='btn btn-primary' id='addAdminn'>Додати</button>"
    content += "<button class='btn btn-primary' id='removeAdminn'>Додати</button>"
    content += "</div>"
    content += "</div>"
    content += "</div>"
    $("#action").html(content);

}

function AdminSetings() {
    let content = '<div class="card">'
    content += '<div class="card-body">'
    content += '<h1 class="h3 text-center">Додати адміністратора</h1>'
    content += '<div class="row">'
    content += '<div class="text-center">'
    content += ' <input class="text-center" list="userslist" name="userEmail" id="userEmail">'
    content += '<datalist id=\'userslist\'>'
    content += $.ajax({
        url:"/user/showalluser",
        method: "POST",
        data:{
            ajax:1
        },
        success: function (responce){
            let objs = JSON.parse(responce);
            for(let obj of objs){
                let option = document.createElement('option');
                option.setAttribute('value', obj.email);
                $("#userslist").append(option)
            }
        }
    })
    content += '</datalist>'
    content += "<button class='btn btn-primary m-1' id='addAdminn'>Додати</button>"
    content += "<button class='btn btn-danger m-1' id='removeAdminn'>Удалити</button>"
    content += '</div>'
    content += '</div>'
    content += '<table class="table">'
    content += '<thead>'
    content += '<tr>'
    content += '<th scope="col">#</th>'
    content += '<th scope="col">Ім\'я</th>'
    content += '<th scope="col">Призвіще</th>'
    content += '<th scope="col">Електронна адреса</th>'
    content += '<th scope="col">Адмін</th>'
    content += '</tr>'
    content += '</thead>'
    content += '<tbody id="body">'
    content += '</tbody>'
    content += '</table>'
    content += '</div>'
    content += '</div>'
    content += $.ajax({
        url: "/user/showalluser",
        method: "POST",
        data: {
            ajax: 2
        },
        success: function (responce) {
            let users = JSON.parse(responce);
            for (let i = 0; i < users.length; ++i) {
                let tr = document.createElement('tr');
                let thNum = document.createElement('th');
                let thName = document.createElement('td');
                let thLastname = document.createElement('td');
                let thEmail = document.createElement('td');
                let thIsAdmin = document.createElement('td');
                thNum.appendChild(document.createTextNode(`${i + 1}`));
                thName.appendChild(document.createTextNode(`${users[i].firstname}`));
                thLastname.appendChild(document.createTextNode(`${users[i].lastname}`));
                thEmail.appendChild(document.createTextNode(`${users[i].email}`))
                if (users[i].isAdmin == 1) {
                    thIsAdmin.appendChild(document.createTextNode('Так'));
                } else {
                    thIsAdmin.appendChild(document.createTextNode('Ні'));
                }
                tr.appendChild(thNum)
                tr.appendChild(thName)
                tr.appendChild(thLastname)
                tr.appendChild(thEmail)
                tr.appendChild(thIsAdmin)
                $("#body").append(tr)
            }
        }
    })
    $("#action").html(content);
    $(document).ready(function () {
        let add = document.getElementById('addAdminn');
        add.addEventListener('click', function () {
            let emailToAdd = document.getElementById('userEmail').value;
            $.ajax({
                url: "/user/addadmin",
                method: "POST",
                data: {
                    ajaxAddAdmin: 1,
                    userEmail: emailToAdd
                },
                success: function (responce) {
                    $('#action').empty();
                    AdminSetings()
                }
            })
        })
        let remove = document.getElementById('removeAdminn')
        remove.addEventListener('click',function (){
            let email = document.getElementById('userEmail').value;
            $.ajax({
                url: "/user/deleteadmin",
                method: "POST",
                data: {
                    ajaxDeleteAdmin: 1,
                    Email: email
                },
                success: function (responce) {
                    $('#action').empty();
                    AdminSetings()
                }
            })
        })
    });
}


$(document).ready(function () {
    let clk = 0;
    $('#edit').click(function () {
        $('#action').empty();
        if (clk == 0) {
            $('#delete').removeClass("active");
            createEditProfile();
            $(this).addClass('active');
            clk++;
        } else {
            $('#action').empty();
            $('#edit').removeClass("active");
            clk = 0;
        }
    });
    $('#delete').click(function () {
        $('#action').empty();
        if (clk == 0) {
            generateDeleteProfile();
            $('#edit').removeClass("active");
            $(this).addClass('active');
            clk++;
        } else {
            $('#action').empty();
            $('#delete').removeClass("active");
            clk = 0;
        }
    });
    $('#addAdmin').click(function () {
        $('#action').empty();
        AdminSetings()
    })
})
$(document).ready(function (){
    let myMessage = document.getElementById('myMess')
    let forMessge = document.getElementById('forMeMess')
    $('#toMess').click(function (){
        myMessage.classList.toggle('d-none')
        forMessge.classList.toggle('d-none')
    })
    $('#forMess').click(function (){
        myMessage.classList.toggle('d-none')
        forMessge.classList.toggle('d-none')
    })
})

$(document).ready(function (){


})
$(".button").click(function(){
    var textAreaValueAnswer = $(this).closest("tr").find("textarea").val();
    var textAreaChat = $(this).closest("tr").find("textarea").attr("chat");
    var textAreaFrom = $(this).closest("tr").find("textarea").attr("data-from-chat");
    var textAreaItem = $(this).closest("tr").find("textarea").attr("data-item-chat");
    console.log(textAreaValueAnswer);
    console.log(textAreaChat);
    console.log(textAreaFrom);
    console.log(textAreaItem);
    $.ajax({
        url: '/message/answer',
        method: "POST",
        data:{
            ajaxAnswer: 1,
            answerChat:textAreaValueAnswer,
            messageChat:textAreaChat,
            fromChat: textAreaFrom,
            itemChat: textAreaItem
        },
        success:function (res){
            alert(res)
            document.location.reload()
        }
    })
});



