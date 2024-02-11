import { pageFromLocalStorage } from "../serverInteraction/pageFromLocalStorage.js";
import { dataSaveInLocalStorage } from "../serverInteraction/create/saveDataInLocalStorage.js"

let photoDeletion = {}

photoDeletion.main = () => {
    let deleteBtn = document.querySelector('#deletePhoto');
    deleteBtn.onclick = (event) => {
        event.preventDefault();
        let thumbnailsBlock = document.querySelector('.thumbnails');

        if (thumbnailsBlock.children.length == 1) {
            localStorage.setItem('photos', JSON.stringify([]));
            let auctionPhotos = document.querySelector('.auctionPhotos');
            auctionPhotos.innerHTML = emptyPhotosHtml.get().outerHTML;
            dataSaveInLocalStorage.addPhoto();
            return;
        }

        let currentPhoto = document.querySelector('.currentPhoto');
        let curThumbnailIndex = pageFromLocalStorage.getCurrentPhotoIndex();
        let curElement = thumbnailsBlock.children[curThumbnailIndex];

        let newChosenThumbnail;
        if (curThumbnailIndex === 0) {
            newChosenThumbnail = curElement.nextElementSibling;
        }
        else {
            newChosenThumbnail = curElement.previousElementSibling;
        }

        curElement.remove();
        let newList =
            JSON.parse(localStorage.getItem('photos')).splice(curThumbnailIndex-1, 1);
        localStorage.setItem('photos', JSON.stringify(newList));

        console.log(localStorage);

        newChosenThumbnail.setAttribute('class', 'currentPhotoThumbnail');
        currentPhoto.src = newChosenThumbnail.src;
    }
}

export { photoDeletion };

let emptyPhotosHtml = {};

emptyPhotosHtml.get = () => createNode(`
<div class="add-photo"> 
    <form action="/upload" name="addPhoto">
        <input type="file" id="addPhoto" accept="image/*">
        <label for="addPhoto">
            <img class="currentPhoto" src="Icons/plus.png" alt="add photo">
        </label>
        <div>
            Images are necessary
        </div>
    </form>
</div>
`)

function createNode(html) {
    let surrogate = document.createElement('div');
    surrogate.innerHTML = html;
    return surrogate.firstElementChild;
}