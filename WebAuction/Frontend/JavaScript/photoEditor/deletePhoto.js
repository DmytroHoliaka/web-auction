import { pageFromLocalStorage } from "../serverInteraction/pageFromLocalStorage.js";

let photoDeletion = {}

photoDeletion.main = () => {
    let deleteBtn = document.querySelector('#deletePhoto');
    deleteBtn.onclick = (event) => {
        event.preventDefault();
        let thumbnailsBlock = document.querySelector('.thumbnails');
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

export { photoDeletion }