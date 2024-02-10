
let thumbnails = document.getElementsByClassName('thumbnails')[0];
thumbnails.addEventListener("mouseenter", ()=>{
    if(thumbnails.lastChild.outerHTML === '<img src="Icons/plus.png" id="edit-addPhoto">'){
        return;
    }
    thumbnails.innerHTML += 
        `<img src="Icons/plus.png" id="edit-addPhoto">`;
})
thumbnails.addEventListener("mouseleave", ()=>{
    if(thumbnails.lastChild.outerHTML === '<img src="Icons/plus.png" id="edit-addPhoto">'){
        thumbnails.removeChild(thumbnails.lastElementChild);
    }
})

let editPhoto = document.getElementsByClassName('edit-photo')[0];
editPhoto.addEventListener("mouseenter", ()=>{
    if(editPhoto.childElementCount !== 1) return;
    editPhoto.innerHTML += 
        `<img class="editBtn" id="edit-deletePhoto" src="Icons/deleteIcon.png">
        <img class="editBtn" id="edit-changePhoto" src="Icons/editIcon.svg">`
})
editPhoto.addEventListener("mouseleave", ()=>{
    if(editPhoto.childElementCount !== 3) return;
    let photo = editPhoto.children[0].outerHTML;
    editPhoto.innerHTML = photo;
})

let textarea = document.forms['editDescription'][0];
textarea.innerHTML =
'This image is a black ceramic plate with orange artwork in the style of ancient Greece. ' +
"It shows two human figures and a helmet in a scene that could be related to war or mythology. " +
"The figures are censored to respect their privacy. " +
"The plate has a geometric border and two handles on the sides."