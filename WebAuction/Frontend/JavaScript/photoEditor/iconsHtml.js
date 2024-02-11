function createNode(html) {
    let surrogate = document.createElement('div');
    surrogate.innerHTML = html;
    return surrogate.firstElementChild;
}

let iconsHtml = {};
iconsHtml.thumbnails = () => createNode(`
<form>
    <input type="file" id="addPhoto" accept="image/*" >
    <label for="addPhoto" class="editBtn">
        <img id="edit-addPhoto" src="Icons/plus.png">
    </label>
</form>
`)
iconsHtml.editPhoto = () => createNode(`
    <form>
        <button id="deletePhoto" accept="image/*" class="editBtn">
            <img id="edit-deletePhoto" src="Icons/deleteIcon.png">
        </button>
        <input type="file" id="changePhoto" accept="image/*" >
        <label for="changePhoto" class="editBtn">
            <img id="edit-changePhoto" src="Icons/editIcon.svg">
        </label>
    </form>
`);

export { iconsHtml }