let tempContainer = document.createElement('div');
tempContainer.innerHTML =
`
<form><!--add necessary attrs for Федя-->
<input type="file" id="addPhoto" accept="image/*" >
<label for="addPhoto" class="editBtn">
<img id="edit-addPhoto" src="Icons/plus.png">
</label>
</form>
`; let thumbnailForm = tempContainer.firstElementChild;

tempContainer.innerHTML =
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
`; let editPhotoForm = tempContainer.firstElementChild;

let thumbnails = document.getElementsByClassName('thumbnails')[0];
thumbnails.addEventListener("mouseenter", () => {
    if (thumbnails.lastElementChild.tagName === 'FORM') {
        return;
    }
    thumbnails.appendChild(thumbnailForm);
})
thumbnails.addEventListener("mouseleave", () => {
    if (thumbnails.lastElementChild.tagName === 'FORM') {
        thumbnails.removeChild(thumbnails.lastElementChild);
    }
})

let editPhoto = document.getElementsByClassName('edit-photo')[0];
editPhoto.addEventListener("mouseenter", () => {
    if (editPhoto.lastElementChild.tagName === 'FORM') return;
    editPhoto.appendChild(editPhotoForm);
})
editPhoto.addEventListener("mouseleave", () => {
    if (editPhoto.lastElementChild.tagName !== 'FORM') return;
    // let photo = editPhoto.children[0].outerHTML;
    // editPhoto.innerHTML = photo;
    editPhoto.removeChild(editPhoto.lastElementChild);
})
