let dataset = document.getElementById('citys');


fetch('https://developers.ria.com/dom/states?api_key=ANyN1lIwTFKQeavggXo6FfNp5DaO5sgVfZE1212Y').then(
    (response)=> response.json()).then(citys => {
    for(let city of citys){
        let option = document.createElement("option");
        option.value = city.region_name;
        option.text = city.region_name;
        dataset.appendChild(option);
    }
});