let buttons = document.querySelectorAll(".remove");
for(let i = 0; i<buttons.length; i++){
    buttons[i].addEventListener('click',function (){
        let houseId = this.getAttribute('data-id-house')
        $.ajax({
            url: '/wishlist/delete',
            method: "POST",
            data:{
                ajaxAddToList: 1,
                houseId: houseId,
            },
            success:function (){
                document.location.reload()
            }
        })
    });
}