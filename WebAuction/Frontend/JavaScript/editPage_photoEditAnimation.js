let thumbnailFormHtml = 
`
<form><!--add necessary attrs for Федя-->
    <input type="file" id="addPhoto" accept="image/*" >
        <label for="addPhoto" class="editBtn">
            <img id="edit-addPhoto" src="Icons/plus.png">
        </label>
</form>
`

let editPhotoFormHtml =
`
<form> <!--add necessary attrs for Федя-->
    <button id="deletePhoto" accept="image/*" class="editBtn">
        <img id="edit-deletePhoto" src="Icons/deleteIcon.png">
    </button>
    <input type="file" id="changePhoto" accept="image/*" >
    <label for="changePhoto" class="editBtn">
        <img id="edit-changePhoto" src="Icons/editIcon.svg">
    </label>
</form>
`

let thumbnails = document.getElementsByClassName('thumbnails')[0];
thumbnails.addEventListener("mouseenter", ()=>{
    if(thumbnails.lastElementChild.tagName === 'FORM'){
        return;
    }
    thumbnails.innerHTML += 
        thumbnailFormHtml;
})
thumbnails.addEventListener("mouseleave", ()=>{
    if(thumbnails.lastElementChild.tagName === 'FORM'){
        thumbnails.removeChild(thumbnails.lastElementChild);
    }
})

let editPhoto = document.getElementsByClassName('edit-photo')[0];
editPhoto.addEventListener("mouseenter", ()=>{
    if(editPhoto.lastElementChild.tagName === 'FORM') return;
    editPhoto.innerHTML += editPhotoFormHtml;
})
editPhoto.addEventListener("mouseleave", ()=>{
    if(editPhoto.lastElementChild.tagName !== 'FORM') return;
    let photo = editPhoto.children[0].outerHTML;
    editPhoto.innerHTML = photo;
})

let textarea = document.forms['editDescription'][0];
textarea.innerHTML =
'This image is a black ceramic plate with orange artwork in the style of ancient Greece. ' +
"It shows two human figures and a helmet in a scene that could be related to war or mythology. " +
"The figures are censored to respect their privacy. " +
"The plate has a geometric border and two handles on the sides."