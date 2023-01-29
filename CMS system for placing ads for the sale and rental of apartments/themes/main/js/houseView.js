$(document).ready(function (){
    var adress = document.querySelector('#adress').getAttribute('data-adress');
    let userFrom = document.querySelector('#chat').getAttribute('data-user-from');
    let userTo = document.querySelector('#chat').getAttribute('data-user-to');
    let itemId = document.querySelector('#chat').getAttribute('data-item-id');

    //Написать повідомлення
    function make_chat_dialog_box(to_user_id)
    {
        var modal_content = '<div id="user_dialog_'+to_user_id+'" class="user_dialog mb-4" title="Задати питання">';
        modal_content += '<div class="form-group">';
        modal_content += '<textarea name="chat_message_'+to_user_id+'" id="message" class="form-control mb-4"></textarea>';
        modal_content += '</div><div class="form-group" align="right">';
        modal_content+= '<button type="button" name="send_chat" id="send-but" class="btn btn-info w-100 send_chat">Send</button></div></div>';
        $('#chat').html(modal_content);
    }

    $(document).on('click', '.send_chat', function (){
        let message = $("#message").val();
        if(!message){
            alert("Повідомлення немає")
        }
        else{
            $.ajax({
                url: '/message/add',
                method: "POST",
                data:{
                    ajaxMes: 1,
                    user_from: userFrom,
                    user_to: userTo,
                    message: message,
                    id_item: itemId
                },
                success:function (responce){
                    $('#user_dialog_'+userTo).dialog('close');
                    alert(responce)
                }
            })
        }
    })

    $(document).on('click', '.write', function(){
        var to_user_id = userTo;
        make_chat_dialog_box(to_user_id);
        $("#user_dialog_"+to_user_id).dialog({
            autoOpen:false,
            width:400,
        });
        $('#user_dialog_'+to_user_id).dialog('open');
    });
    //Список вподобань
    let houseId = document.querySelector('.like').getAttribute('data-id');
    let userId = document.querySelector('.like').getAttribute('data-user-id');
    let buttonStatu = document.querySelector('.like').getAttribute('data-wish-status');
    let wilshlistr = document.querySelector('.like')
    if(buttonStatu == 1){
        wilshlistr.innerHTML = "x";
    }
    else {
        wilshlistr.innerHTML = "В обране ❤";
    }
    $(".like").click(function (){
        let buttonStatus = document.querySelector('.like').getAttribute('data-wish-status');
        if(buttonStatus == 1){
            $.ajax({
                url: '/wishlist/delete',
                method: "POST",
                data:{
                    ajaxAddToList: 1,
                    houseId: houseId,
                },
                success:function (){
                    let wilshlist = document.querySelector('.like')
                    wilshlist.setAttribute('data-wish-status',0)
                    wilshlist.innerHTML = "В обране ❤"
                }
            })
        }
        else {
            $.ajax({
                url: '/wishlist/add',
                method: "POST",
                data:{
                    ajaxAddToList: 1,
                    houseId: houseId,
                    userId: userId
                },
                success:function (){
                    let wilshlist = document.querySelector('.like')
                    wilshlist.setAttribute('data-wish-status',1)
                    wilshlist.innerHTML = "x"
                }
            })
        }
    })
    //Карта
    fetch(`https://maps.googleapis.com/maps/api/geocode/json?address=${adress}&key=AIzaSyDZuCJ6TjLkgvfLxLXpJeDBhfmflJf3iPk`).then(
        (responce) => responce.json()
    ).then(cord => {
        let lat = cord.results[0].geometry.location.lat
        let lng = cord.results[0].geometry.location.lng
        const key = 'SAAAfCOcZFCoOYmzNfDY';
        const map = new maplibregl.Map({
            container: 'map', // container's id or the HTML element in which MapLibre GL JS will render the map
            style: `https://api.maptiler.com/maps/aa2370d2-f89f-4365-b0a3-bf1444db4552/style.json?key=${key}`, // style URL
            center: [lng, lat], // starting position [lng, lat]
            zoom: 17, // starting zoom
            pitch: 45
        });

        map.addControl(new maplibregl.NavigationControl(), 'top-right');
        const marker = new maplibregl.Marker().setLngLat([lng, lat]).addTo(map);
    })
});